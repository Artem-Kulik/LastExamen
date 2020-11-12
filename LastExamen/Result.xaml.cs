using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Remoting.Channels;
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
    /// Interaction logic for Result.xaml
    /// </summary>
    public partial class Result : Window
    {
        BLLClass b = new BLLClass();
        UserDTO user;
        public Result(float a, float b, float c, float d, UserDTO u)
        {
            InitializeComponent();

            user = u;
            a1 = a;
            b1 = b;
            c1 = c;
            d1 = d;

            S.Text = a.ToString() + "%";
            P.Text = b.ToString() + "%";
            C.Text = c.ToString() + "%";
            M.Text = d.ToString() + "%";
        }
        float a1, b1, c1, d1;
        int i = 0;
        void Funk()
        {
            this.Hide();
            TemperamentsInfo t = new TemperamentsInfo(i, this);
            t.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            i = 4;
            Funk();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            i = 1;
            Funk();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            i = 3;
            Funk();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            UserUI u = new UserUI(user);
            u.Show();
            this.Close();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            string Sender = "art.kulik2005@gmail.com";
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587; //sets the server port
            client.EnableSsl = true;

            client.Credentials = new NetworkCredential(Sender, "kak272005");
            string res = "You are ";
            if (a1 > b1 && a1 > c1 && a1 > d1)
            {
                res += "Sanguine";
            }
            else if (b1 > a1 && b1 > c1 && b1 > d1)
            {
                res += "Phlegmatic";
            }
            else if(c1 > b1 && c1 > a1 && c1 > d1)
            {
                res += "Choleric";
            }
            else if(d1 > b1 && d1 > c1 && d1 > a1)
            {
                res += "Melancholic";
            }

            MailMessage message = new MailMessage(Sender, user.Login, "Temperament test", res);

            client.SendAsync(message, "Artem`s token");
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            AllResults all = new AllResults(a1, b1, c1, d1, user);
            all.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            i = 2;
            Funk();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) => this.Close();

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = false;
            b.AddResult(new ResultDTO()
            {
                UserId = user.Id,
                CholericPercent = (int)c1,
                MelancholicPercent = (int)d1,
                PhlegmaticPercent = (int)b1,
                SanguinePercent = (int)a1
            }
        );
        }
    }
}
