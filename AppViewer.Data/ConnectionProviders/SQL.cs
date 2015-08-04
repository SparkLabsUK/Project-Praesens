using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViewer.Data.ConnectionProviders
{
    public class SQL
    {
        private SqlCommand Command;
        private string ConnectionString;

        public SQL()
        {
            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AppViewer"].ConnectionString;

            Reset();
        }
        public void AddParameter(string ParameterName, System.Data.SqlDbType ParameterType, int Size, ParameterDirection Direction, object Value)
        {
            SqlParameter objCurrentParameter = new SqlParameter();
            if (Value == System.DBNull.Value)
                objCurrentParameter.IsNullable = true;
            if (Value == null)
            {
                objCurrentParameter.IsNullable = true;
                Value = DBNull.Value;
            }

            objCurrentParameter.ParameterName = "@" + ParameterName;
            objCurrentParameter.SqlDbType = ParameterType;
            objCurrentParameter.Size = Size;
            objCurrentParameter.Direction = Direction;
            objCurrentParameter.Value = Value;

            Command.Parameters.Add(objCurrentParameter);
        }

        public object GetParameter(string ParameterName)
        {
            if (Command.Parameters.Contains("@" + ParameterName))
            {
                return Command.Parameters["@" + ParameterName].Value;
            }
            else
            {
                return new object();
            }
        }

        public void Reset()
        {
            Command = new SqlCommand();
        }

        public void ExecuteCommand(string CommandText, CommandType CommandType)
        {
            SqlConnection objConnection;

            try
            {
                objConnection = new SqlConnection(ConnectionString);
                objConnection.Open();

                Command.CommandText = CommandText;
                Command.Connection = objConnection;
                Command.CommandType = CommandType;

                Command.ExecuteNonQuery();

                objConnection.Close();
            }
            finally
            {
                Command.Connection = null;

            }
        }

        public object ExecuteScalar(string CommandText, CommandType CommandType)
        {
            SqlConnection objConnection;

            try
            {
                objConnection = new SqlConnection(ConnectionString);
                objConnection.Open();

                Command.CommandText = CommandText;
                Command.Connection = objConnection;
                Command.CommandType = CommandType;

                return Command.ExecuteScalar();

                objConnection.Close();
            }
            finally
            {
                Command.Connection = null;

            }

            return null;
        }

        public DataTable GetDataset(string CommandText, CommandType CommandType)
        {

            try
            {

                SqlConnection objConnection = new SqlConnection(ConnectionString);

                Command.CommandText = CommandText;
                Command.CommandType = CommandType;

                objConnection.Open();

                Command.Connection = objConnection;

                DataTable objData = new DataTable();
                SqlDataAdapter oDAP = new SqlDataAdapter(Command);
                oDAP.Fill(objData);

                objConnection.Close();

                return objData;
            }
            finally
            {
                Command.Connection = null;

            }
        }

        public void Dispose()
        {
            Command.Dispose();
            Command = null;
        }
    }
}
