using DDD.Framework.Domain.Exceptions;

namespace DDD.Framework.Domain.ValueObjects.Base
{
    public abstract class BaseValueObject<T> : BaseThrowException
        where T : class, IValueObject
    {
        #region AbstractMethods
        protected abstract bool IsEqual(T other);

        protected abstract int GetValueObjectHashCode();

        protected abstract IEnumerable<string> Validation();
        #endregion

        #region Overrides
        public override bool Equals(object? obj)
        {
            var vo = obj as T;
            if (ReferenceEquals(vo, null))
                return false;

            return IsEqual(vo);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #region Operators
        public static bool operator ==(BaseValueObject<T> a, BaseValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(BaseValueObject<T> a, BaseValueObject<T> b)
        {
            return !(a == b);
        }
        #endregion
    }
}
