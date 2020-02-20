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

namespace GameBall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Gridforball gridforball;
        readonly Ball ball;
        readonly Boardforball boardforball;
        public DispatcherTimer timer;
        public DispatcherTimer timerForTIme;
        public int count;

        public MainWindow()
        {
            InitializeComponent();
            gridforball = new Gridforball(this);
            gridforball.Draw();
            ball = new Ball(this);
            ball.Draw();
            boardforball = new Boardforball(this);
            boardforball.Draw();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Tick += Timer_Tick;
            timer.Start();
            timerForTIme = new DispatcherTimer();
            timerForTIme.Interval = new TimeSpan(0, 0, 0, 1);
            timerForTIme.Tick += Timer_Tick_ForTIme;
            timerForTIme.Start();
        }

        private void Timer_Tick_ForTIme(object sender, EventArgs e)
        {
            int time = int.Parse(this.Time.Content.ToString());
            time--;
            this.Time.Content = time;
            if (time == 0 && int.Parse(Result.Content.ToString()) < 40)
            {
                this.timer.Stop();
                this.timerForTIme.Stop();
                MessageBox.Show("YOU LOSE:(");
            }
               
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ball.Move(boardforball, gridforball);
        }

        private void Window_Keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
                boardforball.MoveRight();
            if (e.Key == Key.Left)
                boardforball.MoveLeft();
        }
    }
}
