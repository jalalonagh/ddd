using DDD.Framework.Domain.Events;
using DDD.Framework.Domain.Exceptions;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDD.Framework.Domain.Entities
{
    public abstract class IdentityBaseEntity<TKey> : BaseThrowException, IIdentityEntity
    {
        public IdentityBaseEntity()
        {
        }

        #region Events
        private readonly List<IEvent> entityEvents;
        public IEnumerable<IEvent> GetEventChanges() => entityEvents.AsEnumerable(); 
        public void ClearEventChanges() => entityEvents.Clear();
        private void AddNewEvent(IEvent @event) => entityEvents.Add(@event);
        protected abstract void SetStateByEvent(IEvent @event);
        protected abstract IEnumerable<string> ValidateInvariants(IEvent? @event);
        protected void HandleEvent(IEvent @event)
        {
            SetStateByEvent(@event);
            AddException(ValidateInvariants(@event));
            ThrowExceptions();
            AddNewEvent(@event);
        }
        #endregion

        public DateTime creation { get; set; }
        public int? priority { get; set; }
    }

    public abstract class IdentityBaseEntity : IdentityBaseEntity<int>
    {
    }
}
