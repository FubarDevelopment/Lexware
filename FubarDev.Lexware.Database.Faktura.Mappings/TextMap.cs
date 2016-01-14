//-----------------------------------------------------------------------
// <copyright file="TextMap.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using FluentNHibernate.Mapping;

using FubarDev.Lexware.Database.NhSupport;

namespace FubarDev.Lexware.Database.Faktura.Mappings
{
    /// <summary>
    /// NHibernate-Mapping für <see cref="Text"/>
    /// </summary>
    public class TextMap : ClassMap<Text>
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="PreisMap"/> Klasse.
        /// </summary>
        public TextMap()
        {
            Table("FK_Text");

            Id(m => m.Id, "lID").GeneratedBy.Custom<LexwareIdTableGenerator>(p =>
            {
                p.AddParam(LexwareIdTableGenerator.TargetTableNameParam, "FK_Text")
                    .AddParam(LexwareIdTableGenerator.TargetTableIdColumnNameParam, "lID");
            });

            Map(m => m.Typ, "lTyp");
            Map(m => m.Kennung, "lKennung");
            Map(m => m.Wert, "szText").Nullable().Length(32000);
        }
    }
}
