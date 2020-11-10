using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Annotations;
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
    /// Interaction logic for UserUI.xaml
    /// </summary>
    public partial class UserUI : Window
    {
        readonly BLLClass b = new BLLClass();

        public UserUI(UserDTO u)
        {
            InitializeComponent();
            Text.Text = "Welcome " + u.Name;
            if (b.AllQuestions() == null) return;
            foreach (var it in b.AllQuestions())
            {
                questions.Add(i, it.Text);
                temperaments.Add(i, it.TemperamentName);
                i++;
            }
            MAX = i;
            i = 0;
        }
        int MAX = 0;
        int i = 0;

        Dictionary<int, bool> answers = new Dictionary<int, bool>();
        Dictionary<int, string> questions = new Dictionary<int, string>();
        Dictionary<int, string> temperaments = new Dictionary<int, string>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Prew.IsEnabled = true;
            Next.IsEnabled = true;

            answers.Clear();
            Yes.IsChecked = false;
            No.IsChecked = false;
            i = 0;
            Question.Text = questions[i];
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (Next.Content.ToString() != "Show result")
            {
                if (Yes.IsChecked == true || No.IsChecked == true)
                {
                start:
                    try
                    {
                        answers.Add(i, Yes.IsChecked == true ? true : false);
                        i++;
                        if (i + 1 == MAX) Next.Content = "Show result";
                        Question.Text = questions[i];
                        Yes.IsChecked = false;
                        No.IsChecked = false;
                    }
                    catch (Exception ex)
                    {
                        answers.Remove(i);
                        goto start;
                    }
                }
            }
            else
            {
                if (Yes.IsChecked == true || No.IsChecked == true)

                answers.Add(i, Yes.IsChecked == true ? true : false);

                int a = 0, b = 0, c = 0, d = 0;
                for (int i = 0; i < MAX; i++)
                {
                     if (answers[i] == true)
                    {
                        if (temperaments[i] == "Sanguine") a++;
                        if (temperaments[i] == "Phlegmatic") b++;
                        if (temperaments[i] == "Choleric") c++;
                        if (temperaments[i] == "Melancholic") d++;
                    }
                }
                float mark = 100 / (a + b + c + d);               

                Result r = new Result(mark * a, mark * b, mark * c, mark * d);
                r.Show();
                this.Close();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Next.Content.ToString() != "Show result")
            {
                answers.Remove(i - 1);
                i--;
                if (i > -1)
                    Question.Text = questions[i];
                else i++;
            }
            else
            {
                answers.Remove(i);

                Next.Content = "Next";
                i--;
                Question.Text = questions[i];
            }
        }
    }
}