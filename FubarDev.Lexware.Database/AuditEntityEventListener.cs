using System;

using FubarDev.Lexware.Database.Shared;

using NHibernate.Event;
using NHibernate.Persister.Entity;

namespace FubarDev.Lexware.Database
{
    public class AuditEntityEventListener : IPreUpdateEventListener, IPreInsertEventListener
    {
        public AuditEntityEventListener(string userId)
        {
            CurrentUser = userId;
        }

        public string CurrentUser { get; }

        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            var audit = @event.Entity as IAuditEntity;
            if (audit == null)
                return false;

            var time = DateTime.Now;

            Set(@event.Persister, @event.State, "Updated", time);
            Set(@event.Persister, @event.State, "UpdatedBy", CurrentUser);

            audit.Updated = time;
            audit.UpdatedBy = CurrentUser;
            
            return false;
        }

        public bool OnPreInsert(PreInsertEvent @event)
        {
            var audit = @event.Entity as IAuditEntity;
            if (audit == null)
                return false;

            var time = DateTime.Now;

            Set(@event.Persister, @event.State, "Created", time);
            Set(@event.Persister, @event.State, "CreatedBy", CurrentUser);
            Set(@event.Persister, @event.State, "Updated", time);
            Set(@event.Persister, @event.State, "UpdatedBy", CurrentUser);

            audit.Created = time;
            audit.CreatedBy = CurrentUser;
            audit.Updated = time;
            audit.UpdatedBy = CurrentUser;

            return false;
        }

        private void Set(IEntityPersister persister, object[] state, string propertyName, object value)
        {
            var index = Array.IndexOf(persister.PropertyNames, propertyName);
            if (index == -1)
                return;
            state[index] = value;
        }
    }
}
