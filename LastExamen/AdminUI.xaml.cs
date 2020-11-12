using BLL;
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
    /// Interaction logic for AdminUI.xaml
    /// </summary>
    public partial class AdminUI : Window
    {
        UserDTO user;
        public AdminUI(UserDTO u)
        {
            InitializeComponent();
            user = u;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserUI u = new UserUI(user);
            u.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FullStatictic f = new FullStatictic();
            f.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AddQuestion q = new AddQuestion();
            q.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AddAdmin d = new AddAdmin();
            d.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            EditQuestions q = new EditQuestions();
            q.Show();
        }
    }
}
