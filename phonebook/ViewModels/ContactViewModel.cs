using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace phonebook.ViewModels
{
    class ContactViewModel : BaseViewModel
    {

        private ObservableCollection<ContactModel> contacts;

        private ContactModel selectedContact;

        public ObservableCollection<ContactModel> Contacts
        {
            get => contacts;
            private set
            {
                contacts = value;
                OnPropertyChanged();
            }
        }

        public ContactModel SelectedContact
        {
            get => selectedContact;
            set
            {
                selectedContact = value;
                OnPropertyChanged();
            }
        }
    }
}
