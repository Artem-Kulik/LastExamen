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
    /// Interaction logic for AddQuestion.xaml
    /// </summary>
    public partial class AddQuestion : Window
    {
        BLLClass b = new BLLClass();
        public AddQuestion()
        {
            InitializeComponent();
            foreach (var it in b.AllTemperaments())
            {
                Temperament.Items.Add(it.Name);
                TemperamentAntonim.Items.Add(it.Name);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            b.AddQuestion(Question.Text, Temperament.SelectedIndex + 1, TemperamentAntonim.SelectedIndex + 1);
            Question.Text = "Question";
            Temperament.SelectedItem = null;
            TemperamentAntonim.SelectedItem = null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
