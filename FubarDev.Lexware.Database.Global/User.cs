//-----------------------------------------------------------------------
// <copyright file="User.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System.Net;

namespace FubarDev.Lexware.Database.Global
{
    /// <summary>
    /// Diese Klasse repräsentiert einen Lexware-Benutzer
    /// </summary>
    public class User
    {
        /// <summary>
        /// Holt oder setzt die ID des Benutzers
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Holt oder setzt den Namen des Benutzers
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Holt oder setzt das Passwort des Benutzers
        /// </summary>
        public virtual string Password { get; set; }

        /// <summary>
        /// Erstellt ein <see cref="NetworkCredential"/> aus den Anmeldedaten
        /// </summary>
        /// <returns>Das <see cref="NetworkCredential"/> das aus den Anmeldedaten erstellt wurde</returns>
        public virtual NetworkCredential CreateCredential()
        {
            return new NetworkCredential($"U{Id}", Password);
        }
    }
}
