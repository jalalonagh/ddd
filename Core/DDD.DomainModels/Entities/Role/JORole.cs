using DDD.Framework.Domain.Entities;
using DDD.Framework.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.DomainModels.Entities.Role
{
    public class JORole : RoleIdentityBaseEntity<int>, IEntity
    {
        public JORole()
        {

        }

        public string description { get; set; }
        public bool? isActive { get; set; }
        public DateTime creation { get; set; }
        public int? priority { get; set; }
        public string access { get; set; }

        #region Events
        public List<IEvent> entityEvents { get; private set; }
        protected override void SetStateByEvent(IEvent @event)
        {
            //switch (@event)
            //{
            //    case UserCreatedEvent e:
            //        Id = e.Id;
            //        UserName = e.UserName;
            //        PhoneNumber = e.PhoneNumber;
            //        creation = DateTime.Now;
            //        break;
            //    default:
            //        break;
            //}
        }
        protected override IEnumerable<string> ValidateInvariants(IEvent? @event)
        {
            yield return string.Empty;
            //if (@event == null)
            //    yield return string.Empty;
            //switch (@event)
            //{
            //    case UserCreatedEvent:
            //        if (string.IsNullOrEmpty(UserName))
            //            yield return $"{this.GetType().Namespace}-{typeof(JOUser).Name}-{nameof(JOUser.UserName)}";
            //        if (string.IsNullOrEmpty(PhoneNumber))
            //            yield return $"{this.GetType().Namespace}-{typeof(JOUser).Name}-{nameof(JOUser.PhoneNumber)}";
            //        if (string.IsNullOrEmpty(UserName))
            //            yield return $"{this.GetType().Namespace}-{typeof(JOUser).Name}-{nameof(JOUser.creation)}";
            //        if (string.IsNullOrEmpty(UserName))
            //            yield return $"{this.GetType().Namespace}-{typeof(JOUser).Name}-{nameof(JOUser.Id)}";
            //        if (string.IsNullOrEmpty(UserName))
            //            yield return $"{this.GetType().Namespace}-{typeof(JOUser).Name}-{nameof(JOUser.UserName)}";

            //        break;
            //    default:
            //        break;
            //}
        }
        #endregion
    }


    public class RoleConfiguration : IEntityTypeConfiguration<JORole>
    {
        public void Configure(EntityTypeBuilder<JORole> builder)
        {
            builder.ToTable(nameof(JORole), "UserManager");
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
