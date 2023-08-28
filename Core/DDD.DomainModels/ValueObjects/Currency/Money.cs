using DDD.Framework.Domain.ValueObjects;
using DDD.Framework.Domain.ValueObjects.Base.Number;

namespace DDD.DomainModels.ValueObjects.Currency
{
    public class Money : BaseNumberValueObject<Money>, IValueObject
    {
        protected readonly decimal value;

        #region ctor
        public Money() : this(0m)
        {

        }

        public Money(decimal money)
        {
            AddException(Validation());
            ThrowExceptions();
            value = money;
        }
        #endregion

        public static Money CreateFactoryMethod(decimal money)
        {
            return new Money(money);
        }

        public override string ToString()
        {
            return value.ToString();
        }

        protected override IEnumerable<string> Validation()
        {
            return new List<string>();
        }

        protected override int GetValueObjectHashCode()
        {
            return value.GetHashCode();
        }

        protected override bool IsEqual(Money other)
        {
            return value == other.value;
        }

        public override bool IsEqualOrGreater(Money other)
        {
            return value >= other.value;
        }

        public override bool IsEqualOrSmaller(Money other)
        {
            return value <= other.value;
        }

        public override bool IsGreater(Money other)
        {
            return value > other.value;
        }

        public override bool IsSmaller(Money other)
        {
            return value < other.value;
        }
    }
}
