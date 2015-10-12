//-----------------------------------------------------------------------
// <copyright file="AuditEntityEventListener.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System;

using FubarDev.Lexware.Database.Shared;

using NHibernate.Event;
using NHibernate.Persister.Entity;

namespace FubarDev.Lexware.Database
{
    /// <summary>
    /// Eine <see cref="IPreUpdateEventListener"/>- and <see cref="IPreInsertEventListener"/>-Implementation
    /// für Entitäten, die <see cref="IAuditEntity"/> implementieren.
    /// </summary>
    public class AuditEntityEventListener : IPreUpdateEventListener, IPreInsertEventListener
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="AuditEntityEventListener"/> Klasse.
        /// </summary>
        /// <param name="userId">Die ID des Users, der in der <see cref="IAuditEntity"/>-Instanz eingetragen wird</param>
        public AuditEntityEventListener(string userId)
        {
            CurrentUser = userId;
        }

        /// <summary>
        /// Holt die ID des Users, der in der <see cref="IAuditEntity"/>-Instanz eingetragen wird
        /// </summary>
        public string CurrentUser { get; }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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
