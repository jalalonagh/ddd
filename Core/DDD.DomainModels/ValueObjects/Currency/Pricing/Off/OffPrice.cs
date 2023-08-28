using DDD.Framework.Domain.ValueObjects;
using DDD.Framework.Domain.ValueObjects.Base.Number;

namespace DDD.DomainModels.ValueObjects.Currency.Pricing.Off
{
    public class OffPrice : BaseNumberValueObject<OffPrice>, IValueObject
    {
        protected readonly Price value;

        public OffPrice() : this(0m)
        {

        }

        public OffPrice(decimal offPrice)
        {
            AddException(Validation());
            ThrowExceptions();
            value = new Price(offPrice);
        }

        public static OffPrice CreateFactoryMethod(decimal money)
        {
            return new OffPrice(money);
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public override bool IsEqualOrGreater(OffPrice other)
        {
            return value.IsEqualOrGreater(other.value);
        }

        public override bool IsEqualOrSmaller(OffPrice other)
        {
            return value.IsEqualOrSmaller(other.value);
        }

        public override bool IsGreater(OffPrice other)
        {
            return value.IsGreater(other.value);
        }

        public override bool IsSmaller(OffPrice other)
        {
            return value.IsSmaller(other.value);
        }

        protected override int GetValueObjectHashCode()
        {
            return GetHashCode();
        }

        protected override bool IsEqual(OffPrice other)
        {
            return value == other.value;
        }

        protected override IEnumerable<string> Validation()
        {
            if (value.IsEqualOrGreater(new Price(0)))
                yield return GenerateErrorMessage(typeof(OffPrice), nameof(value));
        }
    }
}
