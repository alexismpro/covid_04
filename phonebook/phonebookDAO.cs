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
        private DbConnection conn;

        public phonebookDAO()
        {
            conn = new DbConnection();
        }

        public DataTable searchByName(string _name)
        {
            string _query = $"SELECT * " + $"FROM [Contacts] " + $"WHERE FirstName LIKE @firstName OR LastName LIKE @lastName ";

            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@firstName", SqlDbType.NVarChar);
            parameters[0].Value = _name;

            parameters[1] = new SqlParameter("@lastName", SqlDbType.NVarChar);
            parameters[1].Value = _name;

            return conn.ExecuteSelectQuery(_query, parameters);      //Return DataTable
        }

        public DataTable searchById(int _id)
        {
            string _query = $"SELECT * " + $"FROM [Contacts] " + $"WHERE ContactID = @_id ";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@_id", SqlDbType.Int);
            parameters[0].Value = _id;
            Debug.WriteLine("\n" + "\n" + _id + "\n" + "\n");

            return conn.ExecuteSelectQuery(_query, parameters);      //Return DataTable
        }

        public DataTable getAll()
        {
            string _query = $"SELECT * " +
                            $"FROM [Contacts] ";

            return conn.ExecuteSelectQuery(_query, null);
        }
        public int New(ContactModel cm)
        {
            string _query = $"INSERT INTO [Contacts] (FirstName, LastName, Email, Phone, Mobile) " +
                            $"OUTPUT INSERTED.ContactID " +
                            $"VALUES ('{cm.FirstName}','{cm.LastName}','{cm.Email}','{cm.Phone}','{cm.Mobile}')";

            return conn.ExecutInsertQuery(_query, null);
        }
    }
}
