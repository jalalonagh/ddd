using DDD.Framework.Domain.ValueObjects;
using DDD.Framework.Domain.ValueObjects.Base.Text;

namespace DDD.DomainModels.ValueObjects.Personality.Naming
{
    public class FullName : BaseTextValueObject<FullName>, IValueObject
    {
        #region Properties
        protected readonly string firstName;
        protected readonly string middleName;
        protected readonly string lastName;
        #endregion

        #region Constructors
        public FullName() : this("", "", "")
        {

        }

        public FullName(string first, string middle, string last)
        {
            AddException(Validation());
            ThrowExceptions();
            firstName = first;
            middleName = middle;
            lastName = last;
        }
        #endregion

        #region Methods
        public static FullName CreateFactoryMethod(string first, string middle, string last)
        {
            return new FullName(first, middle, last);
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return $"{firstName} {middleName} {lastName}";
        }

        public override byte IsLike(FullName other)
        {
            return 100;
        }

        public override bool IsLongerThan(FullName other)
        {
            return this.ToString().Length > other.ToString().Length;
        }

        protected override int GetValueObjectHashCode()
        {
            return GetHashCode();
        }

        protected override bool IsEqual(FullName other)
        {
            return this.ToString() == other.ToString();
        }

        protected override IEnumerable<string> Validation()
        {
            if (string.IsNullOrEmpty(firstName))
                yield return GenerateErrorMessage(typeof(FullName), nameof(firstName));
            if (string.IsNullOrEmpty(lastName))
                yield return GenerateErrorMessage(typeof(FullName), nameof(lastName));
        }
        #endregion
    }
}
