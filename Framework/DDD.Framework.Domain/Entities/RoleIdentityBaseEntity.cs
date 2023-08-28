using DDD.Framework.Domain.Events;
using Microsoft.AspNetCore.Identity;

namespace DDD.Framework.Domain.Entities
{
    public abstract class RoleIdentityBaseEntity<TKey> : IdentityRole<TKey>, IIdentityEntity
        where TKey : System.IEquatable<TKey>
    {
        public RoleIdentityBaseEntity()
        {
        }

        #region Events
        private readonly List<IEvent> entityEvents;
        private IEnumerable<string> exceptions;
        public IEnumerable<IEvent> GetEventChanges() => entityEvents.AsEnumerable();
        public void ClearEventChanges() => entityEvents.Clear();
        private void AddNewEvent(IEvent @event) => entityEvents.Add(@event);
        protected abstract void SetStateByEvent(IEvent @event);
        protected abstract IEnumerable<string> ValidateInvariants(IEvent? @event);
        private void ThrowExceptions()
        {
            var exs = exceptions.Where(w => w != string.Empty && w != "").ToList();
            if (exs.Any())
            {
                var ex = new Exception(string.Join(", ", exs));
                exceptions = Enumerable.Empty<string>();
                throw ex;
            }
        }
        protected void HandleEvent(IEvent @event)
        {
            SetStateByEvent(@event);
            exceptions = ValidateInvariants(@event);
            ThrowExceptions();
            AddNewEvent(@event);
        }
        #endregion

        public DateTime creation { get; set; }
        public int? priority { get; set; }
    }

    public abstract class RoleIdentityBaseEntity : RoleIdentityBaseEntity<int>
    {
    }
}
