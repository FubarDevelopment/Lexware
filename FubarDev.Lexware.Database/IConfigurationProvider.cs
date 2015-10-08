//-----------------------------------------------------------------------
// <copyright file="IConfigurationProvider.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Net;
using System.Reflection;

using FubarDev.Lexware.Database.Global;

using JetBrains.Annotations;

using NHibernate.Cfg;

namespace FubarDev.Lexware.Database
{
    public interface IConfigurationProvider
    {
        List<Assembly> MappingAssemblies { get; }

        string GetConnectionString([NotNull] NetworkCredential credential, [CanBeNull] Firma company);

        Configuration CreateConfiguration([NotNull] NetworkCredential credential, [CanBeNull] Firma company);
    }
}
