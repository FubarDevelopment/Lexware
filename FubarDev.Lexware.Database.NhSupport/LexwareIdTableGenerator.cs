using System;
using System.Collections.Generic;
using System.Data;

using NHibernate.Dialect;
using NHibernate.Engine;
using NHibernate.Id;
using NHibernate.Type;

namespace FubarDev.Lexware.Database.NhSupport
{
    public class LexwareIdTableGenerator : TransactionHelper, IIdentifierGenerator, IConfigurable
    {
        public const string IdGenFunctionNameParam = "id_gen_function_name";
        public const string DefaultIdGenFunctionName = "LX_GETID_2";

        public const string TargetTableNameParam = "target_table_name";

        public const string TargetTableIdColumnNameParam = "target_table_id_column_name";

        private string _idGenFunctionName;

        private string _targetTableName;

        private string _targetTableIdColumnName;

        public override object DoWorkInCurrentTransaction(ISessionImplementor session, IDbConnection conn, IDbTransaction transaction)
        {
            using (var cmd = CreateSelectCommand(conn, transaction))
            {
                cmd.Parameters["tableName"] = _targetTableName;
                cmd.Parameters["columnName"] = _targetTableIdColumnName;
                return cmd.ExecuteScalar();
            }
        }

        public object Generate(ISessionImplementor session, object obj)
        {
            return DoWorkInNewTransaction(session);
        }

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
