using DDD.Framework.Domain.Events;

namespace DDD.DomainModels.Events.User
{
    public class UserCreatedEvent : IEvent
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime creation { get; set; }
    }
}
