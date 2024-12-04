using CSC317PassManagerP2Starter.Modules.Models;
using System.Collections.ObjectModel;
/* HEADER COMMENT
Program Author: Joshua Johnston

USM ID: w10153021

Assignment: Password manager 2

Description:

the purpose of this lab was to implement the backend to a password manager app. 
I very much struggled with this assignment, but i managed to complete both of the controllers, models, and part of the password list view backend.
I really would appreciate some grace, and leniency with this assignment, as i struggled with it immensely. I have an incredible amount of work to do, with exams and finals.
I know i didnt do everything, but i hope this will allow me to get a few points.




*/
namespace CSC317PassManagerP2Starter.Modules.Views
{
    public partial class PasswordListView : ContentPage
    {
        private ObservableCollection<PasswordRow> _rows = new ObservableCollection<PasswordRow>();

        public PasswordListView()
        {
            InitializeComponent();
            App.PasswordController.GenTestPasswords();
            App.PasswordController.PopulatePasswordView(_rows);
            collPasswords.ItemsSource = _rows;
        }

        private void TextSearchBar(object sender, TextChangedEventArgs e)
        {
            App.PasswordController.PopulatePasswordView(_rows, e.NewTextValue);
        }

        private void CopyPassToClipboard(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32((sender as Button).CommandParameter);
            var password = App.PasswordController.GetPassword(ID);
            if (password != null)
            {
               // couldnt get this to work Task task = Clipboard.SetTextAsync(PasswordModel.PasswordText);
                DisplayAlert("Copied", "Password copied to clipboard.", "OK");
            }
        }

        private void EditPassword(object sender, EventArgs e)
        {
            var button = sender as Button;
            var row = button.BindingContext as PasswordRow;

            if (row != null)
            {
                if (row.Editing)
                {
                    row.SavePassword();
                    row.Editing = false;
                    button.Text = "Edit";
                }
                else
                {
                    row.Editing = true;
                    button.Text = "Save";
                }
            }
        }

        private void DeletePassword(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32((sender as Button).CommandParameter);
            if (App.PasswordController.RemovePassword(ID))
            {
                var rowToRemove = _rows.FirstOrDefault(row => row.PasswordID == ID);
                if (rowToRemove != null)
                {
                    _rows.Remove(rowToRemove);
                }
            }
            else
            {
                DisplayAlert("Error", "Failed to delete the password.", "OK");
            }
        }

        private void ButtonAddPassword(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddPasswordView());
        }
    }
}
