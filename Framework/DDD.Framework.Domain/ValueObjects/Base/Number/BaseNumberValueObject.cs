namespace DDD.Framework.Domain.ValueObjects.Base.Number
{
    public abstract class BaseNumberValueObject<T> : BaseValueObject<T>
        where T : class, IValueObject
    {
        #region AbstractMethods
        public abstract bool IsSmaller(T other);
        public abstract bool IsEqualOrSmaller(T other);
        public abstract bool IsGreater(T other);
        public abstract bool IsEqualOrGreater(T other);
        #endregion
    }
}
