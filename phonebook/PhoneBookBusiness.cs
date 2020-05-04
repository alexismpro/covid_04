using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace phonebook
{
    static class PhoneBookBusiness
    {
        private static phonebookDAO dao = new phonebookDAO();

        public static ContactModel GetContactByName(string _name)
        {
            ContactModel cm = null;

            DataTable dt = new DataTable();

            dt = dao.searchByName(_name);

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    cm = RowToContactModel(row);
                }
            }

            return cm;
        }

        public static ObservableCollection<ContactModel> GetContactsByName(string _name)
        {
            ContactModel cm = null;
            ObservableCollection<ContactModel> collContacts = new ObservableCollection<ContactModel>();
            DataTable dt = new DataTable();

            dt = dao.searchByName(_name);

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    cm = RowToContactModel(row);
                    collContacts.Add(cm);
                }
            }

            return collContacts;
        }

        public static ContactModel GetContactById(int _id)
        {
            ContactModel cm = null;

            DataTable dt = new DataTable();

            dt = dao.searchById(_id);

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    cm = RowToContactModel(row);
                }
            }

            return cm;
        }
        public static ObservableCollection<ContactModel> getAllContacts()
        {
            ContactModel cm = null;

            DataTable dt = new DataTable();
            ObservableCollection<ContactModel> contacts = new ObservableCollection<ContactModel>();

            dt = dao.getAll();

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    cm = RowToContactModel(row);
                    contacts.Add(cm);
                }
            }

            return contacts;
        }

        private static ContactModel RowToContactModel(DataRow row)
        {
            ContactModel cm = new ContactModel();

            cm.ContactID = Convert.ToInt32(row["ContactID"]);
            cm.FirstName = row["FirstName"].ToString();
            cm.LastName = row["LastName"].ToString();
            cm.Email = row["Email"].ToString();
            cm.Phone = row["Phone"].ToString();
            cm.Mobile = row["Mobile"].ToString();

            return cm;
        }

        public static int NewContact(ContactModel cm)
        {
            int add=0;

            dao.New(cm);

            return add;
        }
    }
}
