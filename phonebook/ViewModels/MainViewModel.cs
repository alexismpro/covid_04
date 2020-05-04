using phonebook.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace phonebook.ViewModels
{
    class MainViewModel:BaseViewModel
    {
        private BaseViewModel _vm;
        public BaseViewModel VM
        {
            get { return _vm; }
            set
            {
                _vm = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<ContactModel> contacts = new ObservableCollection<ContactModel>();

        public ObservableCollection<ContactModel> Contacts
        {
            get => contacts;
            private set
            {
                contacts = value;
                OnPropertyChanged();
            }
        }
        private ContactModel selectedContact;

        public ContactModel SelectedContact
        {
            get => selectedContact;
            set
            {
                selectedContact = value;
                OnPropertyChanged();
            }
        }

        private string criteria;

        public string Criteria
        {
            get { return criteria; }
            set { 
                criteria = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SearchContactCommand { get; set; }




        public MainViewModel()
        {
            SearchContactCommand = new RelayCommand(SearchByContact);

            VM = this;
            Contacts = PhoneBookBusiness.getAllContacts();
            SelectedContact = Contacts.First<ContactModel>();
        }

        private void SearchByContact(object parameter)
        {
            string input = parameter as string;
            int output;
            string searchMethod = "";

            if (!Int32.TryParse(input, out output))
            {
                searchMethod = "name";
            }
            else searchMethod = "id";

            switch (searchMethod)
            {
                case "id":
                    SelectedContact = PhoneBookBusiness.GetContactById(output);
                    break;
                case "name":
                    SelectedContact = PhoneBookBusiness.GetContactByName(input);
                    break;
                default:
                    MessageBox.Show("Unkonwn search method");
                    break;
            }
        }
    }
}
