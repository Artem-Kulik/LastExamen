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
    /// Interaction logic for AllResults.xaml
    /// </summary>
 
    public partial class AllResults : Window
    {
        BLLClass b = new BLLClass();
        float a1, b1, c1, d1;
        UserDTO user;

        public AllResults(float a, float h, float c, float d, UserDTO u)
        {
            InitializeComponent();

            user = u;
            a1 = a;
            b1 = h;
            c1 = c;
            d1 = d;

            Wellcome.Text = "All " + u.Name + "`s results";

            foreach (var it in b.AllResultsById(u.Id))
            {
                Results.Items.Add($"{it.SanguinePercent}%\t{it.PhlegmaticPercent}%\t{it.CholericPercent}%\t{it.MelancholicPercent}%");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LastExamen.Result res = new Result(a1, b1, c1, d1, user);
            res.Show();
            this.Close();
        }
    }
}
