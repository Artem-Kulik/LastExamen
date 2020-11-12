using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LastExamen
{
    /// <summary>
    /// Interaction logic for EditUI.xaml
    /// </summary>
    public partial class EditUI : Window
    {
        BLLClass b = new BLLClass();

        UserDTO user;
        UserDTO newU;
        public EditUI(UserDTO u)
        {
            InitializeComponent();
            user = u;
            Name.Text += " " + u.Name; 
            Login.Text += " " +  u.Login; 
            Password.Text += " " + u.Password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                b.EditUser(Login.Text, Password.Text, Name.Text, user.Id);
                newU = new UserDTO { Login = Login.Text, Password = Password.Text, Name = Name.Text, Id = user.Id, Admin = false };

                UserUI u = new UserUI(newU);
                u.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); };
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UserUI u = new UserUI(user);
            u.Show();
            this.Close();
        }
    }
}
