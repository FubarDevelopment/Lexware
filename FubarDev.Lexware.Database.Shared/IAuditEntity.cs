using System;
using System.Diagnostics.Contracts;

namespace FubarDev.Lexware.Database.Shared
{
    public interface IAuditEntity
    {
        DateTime? Created { get; set; }
        string CreatedBy { get; set; }
        DateTime? Updated { get; set; }
        string UpdatedBy { get; set; }
    }
}
