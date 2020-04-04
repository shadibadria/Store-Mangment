using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
namespace Store_Mangment.Control
{
    class DataBase_Connection
    {
        protected OleDbConnection _conn = null;

        public static DataBase_Connection Instance { get; internal set; }

        /*Creating a new connection*/
        public DataBase_Connection(String connectionString)
        {
            _conn = new OleDbConnection(connectionString);

        }

        /*checking if connection is good and open connection*/
        protected void Connect()
        {
            if (_conn.State != ConnectionState.Open)
            {
                _conn.Open();
            }
        }

        /*disconnect*/
        protected void Disconnect()
        {
            _conn.Close();
        }


        /*get simple query*/
        protected void ExecuteSimpleQuery(OleDbCommand command)
        {
            lock (_conn)
            {
                Connect();
                command.Connection = _conn;
                try
                {
                    command.ExecuteNonQuery();
                }
                finally
                {
                    Disconnect();
                }
            }
        }


        /*get by type query*/
        protected int ExecuteScalarIntQuery(OleDbCommand command)
        {
            int ret = -1;
            lock (_conn)
            {
                Connect();
                command.Connection = _conn;
                try
                {
                    ret = (int)command.ExecuteScalar();
                }
                finally
                {
                    Disconnect();
                }
            }
            return ret;
        }

        protected DataSet GetMultiPleQuery(OleDbCommand command)
        {
            DataSet dataset = new DataSet();
            lock (_conn)
            {
                Connect();
                command.Connection = _conn;
                try
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(dataset);
                }
                finally
                {
                    Disconnect();
                }

            }
            return dataset;

        }
    }
}

