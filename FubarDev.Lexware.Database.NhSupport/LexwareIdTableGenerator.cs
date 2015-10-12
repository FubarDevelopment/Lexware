//-----------------------------------------------------------------------
// <copyright file="LexwareIdTableGenerator.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Data;

using NHibernate.Dialect;
using NHibernate.Engine;
using NHibernate.Id;
using NHibernate.Type;

namespace FubarDev.Lexware.Database.NhSupport
{
    /// <summary>
    /// ID-Generator der die LX_GETID_2()-SQL-Funktion verwendet
    /// </summary>
    public class LexwareIdTableGenerator : TransactionHelper, IIdentifierGenerator, IConfigurable
    {
        /// <summary>
        /// Parameter-Name für die SQL-Funktion über die die neue ID ermittelt wird
        /// </summary>
        public const string IdGenFunctionNameParam = "id_gen_function_name";

        /// <summary>
        /// Standard-Name für die SQL-Funktion über die die neue ID ermittelt wird
        /// </summary>
        public const string DefaultIdGenFunctionName = "LX_GETID_2";

        /// <summary>
        /// Parameter-Name für die Tabelle für die die ID ermittelt werden soll
        /// </summary>
        public const string TargetTableNameParam = "target_table_name";

        /// <summary>
        /// ID-Spaltenname für die Tabelle für die die ID ermittelt werden soll
        /// </summary>
        public const string TargetTableIdColumnNameParam = "target_table_id_column_name";

        private string _idGenFunctionName;

        private string _targetTableName;

        private string _targetTableIdColumnName;

        /// <inheritdoc/>
        public override object DoWorkInCurrentTransaction(ISessionImplementor session, IDbConnection conn, IDbTransaction transaction)
        {
            using (var cmd = CreateSelectCommand(conn, transaction))
            {
                cmd.Parameters["tableName"] = _targetTableName;
                cmd.Parameters["columnName"] = _targetTableIdColumnName;
                return cmd.ExecuteScalar();
            }
        }

        /// <inheritdoc/>
        public object Generate(ISessionImplementor session, object obj)
        {
            return DoWorkInNewTransaction(session);
        }

        /// <inheritdoc/>
        public void Configure(IType type, IDictionary<string, string> parms, Dialect dialect)
        {
            if (!parms.TryGetValue(IdGenFunctionNameParam, out _idGenFunctionName))
                _idGenFunctionName = DefaultIdGenFunctionName;
            _targetTableName = parms[TargetTableNameParam];
            _targetTableIdColumnName = parms[TargetTableIdColumnNameParam];
        }

        private IDbCommand CreateSelectCommand(IDbConnection connection, IDbTransaction transaction)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT {_idGenFunctionName}(@tableName, @columnName)";
            if (transaction != null)
                cmd.Transaction = transaction;
            {
                var param = cmd.CreateParameter();
                param.ParameterName = "tableName";
                cmd.Parameters.Add(param);
            }
            {
                var param = cmd.CreateParameter();
                param.ParameterName = "columnName";
                cmd.Parameters.Add(param);
            }
            return cmd;
        }
    }
}
