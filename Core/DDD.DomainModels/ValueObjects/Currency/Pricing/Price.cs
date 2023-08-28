using DDD.DomainModels.ValueObjects.Currency.Pricing.Off;
using DDD.Framework.Domain.ValueObjects;
using DDD.Framework.Domain.ValueObjects.Base.Number;

namespace DDD.DomainModels.ValueObjects.Currency.Pricing
{
    public class Price : BaseNumberValueObject<Price>, IValueObject
    {
        protected readonly Money value;

        public Price() : this(0m)
        { }

        public Price(decimal price)
        {
            AddException(Validation());
            ThrowExceptions();
            this.value = new Money(price);
        }

        public static Price CreateFactoryMethod(decimal money)
        {
            return new Price(money);
        }

        public override string ToString()
        {
            return value.ToString();
        }

        protected override IEnumerable<string> Validation()
        {
            if (value.IsEqualOrGreater(new Money(0)))
                yield return GenerateErrorMessage(typeof(Price), nameof(value));
        }

        public override bool IsEqualOrGreater(Price other)
        {
            return value.IsEqualOrGreater(other.value);
        }

        public override bool IsEqualOrSmaller(Price other)
        {
            return value.IsEqualOrSmaller(other.value);
        }

        public override bool IsGreater(Price other)
        {
            return value.IsGreater(other.value);
        }

        public override bool IsSmaller(Price other)
        {
            return value.IsSmaller(other.value);
        }

        protected override int GetValueObjectHashCode()
        {
            return GetHashCode();
        }

        protected override bool IsEqual(Price other)
        {
            return value == other.value;
        }
    }
}
