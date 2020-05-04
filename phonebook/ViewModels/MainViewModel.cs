using phonebook.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace phonebook.ViewModels
{
    class MainViewModel:BaseViewModel
    {
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
            SelectedContact = PhoneBookBusiness.GetContactById(1);
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
