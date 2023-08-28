namespace DDD.Framework.Domain.ValueObjects.Base.Text
{
    public abstract class BaseTextValueObject<T> : BaseValueObject<T>
        where T : class, IValueObject
    {
        #region AbstractMethods
        public abstract byte IsLike(T other);
        public abstract bool IsLongerThan(T other);
        #endregion
    }
}
