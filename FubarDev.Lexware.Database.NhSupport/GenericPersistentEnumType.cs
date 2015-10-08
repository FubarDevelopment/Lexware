//-----------------------------------------------------------------------
// <copyright file="GenericPersistentEnumType.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System;

using NHibernate.Type;

namespace FubarDev.Lexware.Database.NhSupport
{
    /// <summary>
    /// Eine generische Variante von <see cref="PersistentEnumType"/>
    /// </summary>
    /// <typeparam name="T">Der Enum-Typ</typeparam>
    public class GenericPersistentEnumType<T> : PersistentEnumType
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="GenericPersistentEnumType{T}"/> Klasse.
        /// </summary>
        public GenericPersistentEnumType()
            : base(typeof(T))
        {
        }
    }
}
