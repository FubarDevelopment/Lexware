//-----------------------------------------------------------------------
// <copyright file="UserMap.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using FluentNHibernate.Mapping;

namespace FubarDev.Lexware.Database.Global.Mappings
{
    /// <summary>
    /// Das Mapping für einen Lexware-Benutzer
    /// </summary>
    public class UserMap : ClassMap<User>
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="UserMap"/> Klasse.
        /// </summary>
        public UserMap()
        {
            Schema("LEXGLOBAL");
            Table("LXG_USER");
            Id(x => x.Id, "USER_ID");
            Map(x => x.Name, "USER_NAME");
            Map(x => x.Password, "PASSWORD");
        }
    }
}
