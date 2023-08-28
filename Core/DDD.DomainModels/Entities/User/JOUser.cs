using DDD.DomainModels.Events.User;
using DDD.DomainModels.ValueObjects.Personality.Naming;
using DDD.Framework.Domain.Entities;
using DDD.Framework.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.DomainModels.Entities.User
{
    public class JOUser : UserIdentityBaseEntity<int>, IEntity
    {
        public JOUser()
        {

        }

        public FullName fullname { get; set; }
        public string avatar { get; set; }
        public bool? isActive { get; set; }
        public DateTime? birthday { get; set; }

        #region Behavier Methods
        public void CreateNewUser(string mobile)
        {
            base.HandleEvent(new UserCreatedEvent()
            {
                Id = 0,
                UserName = mobile,
                creation = DateTime.Now,
                PhoneNumber = mobile
            });
        }
        #endregion

        #region Events
        public List<IEvent> entityEvents { get; private set; }
        protected override void SetStateByEvent(IEvent @event)
        {
            switch (@event)
            {
                case UserCreatedEvent e:
                    Id = e.Id;
                    UserName = e.UserName;
                    PhoneNumber = e.PhoneNumber;
                    creation = DateTime.Now;
                    break;
                default:
                    break;
            }
        }
        protected override IEnumerable<string> ValidateInvariants(IEvent? @event)
        {
            if (@event == null)
                yield return string.Empty;
            switch (@event)
            {
                case UserCreatedEvent:
                    if (string.IsNullOrEmpty(UserName))
                        yield return $"{this.GetType().Namespace}-{typeof(JOUser).Name}-{nameof(JOUser.UserName)}";
                    if (string.IsNullOrEmpty(PhoneNumber))
                        yield return $"{this.GetType().Namespace}-{typeof(JOUser).Name}-{nameof(JOUser.PhoneNumber)}";
                    if (string.IsNullOrEmpty(UserName))
                        yield return $"{this.GetType().Namespace}-{typeof(JOUser).Name}-{nameof(JOUser.creation)}";
                    if (string.IsNullOrEmpty(UserName))
                        yield return $"{this.GetType().Namespace}-{typeof(JOUser).Name}-{nameof(JOUser.Id)}";
                    if (string.IsNullOrEmpty(UserName))
                        yield return $"{this.GetType().Namespace}-{typeof(JOUser).Name}-{nameof(JOUser.UserName)}";

                    break;
                default:
                    break;
            }
        }
        #endregion
    }

    public class UserConfiguration : IEntityTypeConfiguration<JOUser>
    {
        public void Configure(EntityTypeBuilder<JOUser> builder)
        {
            builder.ToTable(nameof(JOUser), "UserManager");

            builder.OwnsOne(p => p.fullname);

            builder.Property(p => p.UserName).IsRequired().HasMaxLength(100).IsUnicode();
            builder.Property(p => p.PhoneNumber).IsRequired().IsUnicode();
        }
    }
}
