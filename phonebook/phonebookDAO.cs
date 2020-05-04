using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace phonebook
{
    // DAO = Data Access Object
    class phonebookDAO
    {
        private DbConnection con;

        public phonebookDAO()
        {
            con = new DbConnection();
        }

        public DataTable searchByName(string _name)
        {
            string _query = $"SELECT * " + $"FROM [Contacts] " + $"WHERE FirstName LIKE @firstName OR LastName LIKE @lastName ";

            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@firstName", SqlDbType.NVarChar);
            parameters[0].Value = _name;

            parameters[1] = new SqlParameter("@lastName", SqlDbType.NVarChar);
            parameters[1].Value = _name;

            return con.ExecuteSelectQuery(_query, parameters);      //Return DataTable
        }

        public DataTable searchById(int _id)
        {
            string _query = $"SELECT * " + $"FROM [Contacts] " + $"WHERE ContactID = @_id ";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@_id", SqlDbType.Int);
            parameters[0].Value = _id;
            Debug.WriteLine("\n" + "\n" + _id + "\n" + "\n");

            return con.ExecuteSelectQuery(_query, parameters);      //Return DataTable
        }
    }
}
