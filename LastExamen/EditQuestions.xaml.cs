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
    /// Interaction logic for EditQuestions.xaml
    /// </summary>
    public partial class EditQuestions : Window
    {
        BLLClass b = new BLLClass();
  
        public EditQuestions()
        {
            InitializeComponent();
            foreach (var it in b.AllQuestions())
            {
                questions.Add(i, it.Text);
                help.Add(i, it.Id);
                i++;
            }
            MAX = i;
            i = 0;
            Question.Text = questions[i];
        }

        Dictionary<int, string> questions = new Dictionary<int, string>();
        Dictionary<int, int> help = new Dictionary<int, int>();
        int MAX = 0;
        int i = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            b.EditQuestion(Question.Text, help[i]);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Next.Content.ToString() != "End")
            {
                i--;
                if (i > -1)
                    Question.Text = questions[i];
                else i++;
            }
            else
            {
                Next.Content = "Next";
                i--;
                Question.Text = questions[i];
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (Next.Content.ToString() != "End")
            {
                i++;
                if (i + 1 == MAX) Next.Content = "End";
                Question.Text = questions[i];
            }            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
