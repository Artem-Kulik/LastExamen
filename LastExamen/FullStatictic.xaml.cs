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
    /// Interaction logic for FullStatictic.xaml
    /// </summary>
    public partial class FullStatictic : Window
    {
        BLLClass b = new BLLClass();
        public FullStatictic()
        {
            InitializeComponent();

            float[] res = b.FullPersent();

            S.Text = res[0].ToString() + "%";
            P.Text = res[1].ToString() + "%";
            C.Text = res[2].ToString() + "%";
            M.Text = res[3].ToString() + "%";

            S1.Value = res[0];
            P1.Value = res[1];
            C1.Value = res[2];
            M1.Value = res[3];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
