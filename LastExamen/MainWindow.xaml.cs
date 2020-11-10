using BLLCHANGE;
//mmihgiufiyftdhhte
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LastExamen
{
    public partial class MainWindow : Window
    {
        readonly BLLClass b = new BLLClass();
        public MainWindow()
        {
            InitializeComponent();
        }
        int i = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            i = 2;
            Name.IsEnabled = true;
            Login.IsEnabled = true;
            Password.IsEnabled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (i == 2)
            {
                b.AddUser(new UserDTO() { Login = Login.Text, Password = Password.Text, Name = Name.Text, Admin = false });
                MessageBox.Show($"User *{Name.Text}* sucsesful added");

                Name.IsEnabled = false;
                Login.IsEnabled = false;
                Password.IsEnabled = false;

                Name.Text = "Name";
                Login.Text = "Login";
                Password.Text = "Password";
            }
            else if (i == 1)
            {
                UserDTO u = b.Login(Login.Text, Password.Text);
                if (u != null)
                {
                    this.Hide();
                    UserUI ui = new UserUI(u);
                    ui.Show();

                    Name.IsEnabled = false;
                    Login.IsEnabled = false;
                    Password.IsEnabled = false;

                    Name.Text = "Name";
                    Login.Text = "Login";
                    Password.Text = "Password";
                }
                else MessageBox.Show("Error");
            }
        }

        private void SingIn_Click(object sender, RoutedEventArgs e)
        {
            i = 1;
            Login.IsEnabled = true;
            Password.IsEnabled = true;
            Name.IsEnabled = false;
        }
    }
}
