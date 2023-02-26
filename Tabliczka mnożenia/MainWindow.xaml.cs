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
using System.Windows.Threading;

namespace Tabliczka_mnożenia
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int b, d, dobre, zle,i,spr;

        public TimeSpan RemainingTime { get; set; }
        private DispatcherTimer timer;
        char[] znak = { '+', '-', '/', '*' };

        public MainWindow()
        {
            InitializeComponent();
            dobre = 0;
            zle = 0;
            punkty_d.Text = "Ilość poprawnych odpowiedzi to: " + dobre;
            punkty_z.Text = "Ilość błędnych odpowiedzi to: " + zle;
            losowanie();
            MessageBox.Show("Powodzenia w mojej grze !");
            DataContext = this;

            RemainingTime = TimeSpan.FromMinutes(1);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();


        }
        public void losowanie()
        {
            string a, c;
            Random random = new Random();
            i = random.Next(0, 4);     
            int reszta;
            
                b = random.Next(0, 11);
                do
                {
                    d = random.Next(0, 11);
                    if (znak[i] != '/') { break; }               
                } while (d == 0);

            a = b.ToString();
            c = d.ToString();
            dzialanie.Text = a + " " + znak[i] + " " + c + " podaj wynik!";
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            string spr2 = wynik.Text;

            if (int.TryParse(spr2, out spr))
            {
                spr = int.Parse(spr2);
                if (znak[i] == '*') { mnozenie(); }
                if (znak[i] == '+') { dodawanie(); }
                if (znak[i] == '-') { odejmowanie(); }
                if (znak[i] == '/') { dzielenie(); }
                
                
                punkty_d.Text = "Ilość poprawnych odpowiedzi to: " + dobre;
                punkty_z.Text = "Ilość błędnych odpowiedzi to: " + zle;

                losowanie();

                wynik.Text = "";
            }
            else
            {
                wynik.Text = "";
            }
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                button1_Click(sender, e);
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            RemainingTime = RemainingTime.Subtract(TimeSpan.FromSeconds(1));
            time.Text = RemainingTime.ToString();
            if (RemainingTime <= TimeSpan.Zero)
            {
                timer.Stop();
                MessageBox.Show("Koniec czasu!");
                dobre= 0;
                zle= 0;
                RemainingTime = TimeSpan.FromMinutes(1);
                punkty_d.Text = "Ilość poprawnych odpowiedzi to: " + dobre;
                punkty_z.Text = "Ilość błędnych odpowiedzi to: " + zle;
                losowanie();
                timer.Start();
            }



        }

        private void mnozenie()
        {
            if (spr == (b * d))
            {
                dobre++;
            }
            else
            {
                zle++;
            }
        }
        private void dodawanie()
        {
            if (spr == (b + d))
            {
                dobre++;
            }
            else
            {
                zle++;
            }
        }
        private void odejmowanie()
        {
            if (spr == (b - d))
            {
                dobre++;
            }
            else
            {
                zle++;
            }
        }
        private void dzielenie()
        {
            if (spr == (b / d))
            {
                dobre++;
            }
            else
            {
                zle++;
            }
        }
    }
}
