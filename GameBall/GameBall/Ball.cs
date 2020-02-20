using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using GameBall.Interfaces;


namespace GameBall
{
    class Ball :IDraw,IMove
    {
        readonly MainWindow _window;
        Ellipse ball;
        private readonly int r;
        private int x;
        private int y;
        private int directX;
        private int directY;
        bool block;
        public Ball(MainWindow window)
        {
            this._window = window;
            this.r = 30;
            this.x = (int)this._window.Width / 2 - r;
            this.y = (int)this._window.Height - 151;
            this.directX = 10;
            this.directY = -10;
            block = false;
        }
        public void Draw()
        {
            ball = new Ellipse();
            ball.Fill = Brushes.Red;
            ball.Width = r;
            ball.Height = r;
            this._window.board.Children.Add(ball);
            Canvas.SetLeft(ball, x);
            Canvas.SetTop(ball, y);
            Canvas.SetZIndex(ball, 999);
        }

        public void Move(Boardforball boardforball, Gridforball gridforball)
        {

            x = (int)Canvas.GetLeft(ball);
            y = (int)Canvas.GetTop(ball);
            int xBoard = (int)Canvas.GetLeft(boardforball.boardForBall);
            int yBoard = (int)Canvas.GetTop(boardforball.boardForBall);
            if (x + 2*r >= _window.Width || x <= 0)
                directX = -directX;
            if (y <= 0 || y + 2 * r >= _window.Height)
                directY = -directY;
            if (x + r >= xBoard && x <= xBoard + boardforball.boardForBall.Width &&
                y + r >= yBoard && y <= yBoard + boardforball.boardForBall.Height)
            {
                directY = -directY;
                block = false;
            }
            for (int i = 0; i < gridforball.grid.GetLength(0); i++)
            {
                for (int j = 0; j < gridforball.grid.GetLength(1); j++)
                {
                    int grid_x = (int)Canvas.GetLeft(gridforball.grid[i, j]);
                    int grid_y = (int)Canvas.GetTop(gridforball.grid[i, j]);

                    if (x >= grid_x-10 && x < grid_x + 10 + gridforball.grid[i, j].Width && y >= grid_y && 
                        y < grid_y + gridforball.grid[i, j].Height && gridforball.grid[i, j].Fill != Brushes.YellowGreen && !block) 
                    {
                        gridforball.grid[i, j].Fill = Brushes.YellowGreen;
                        this._window.board.Children.Remove(gridforball.grid[i, j]);
                        directY = -directY;
                        block = true;
                        int count = int.Parse(this._window.Result.Content.ToString());
                        count += 1;
                        this._window.Result.Content = count;
                        if (count == 40 && int.Parse(this._window.Time.Content.ToString()) > 0)
                        {
                            this._window.timer.Stop();
                            MessageBox.Show("YOU WIN !!!!!!");
                        }
                        //int speed = this._window.timer.Interval.Milliseconds;
                        //speed -= 2;
                        //if (speed <= 20)
                        //{
                        //    speed = -20;
                        //}
                        //this._window.timer.Interval = new TimeSpan(0, 0, 0, 0, speed);
                    }
                }
            }
            x += directX;
            y += directY;
            Canvas.SetLeft(ball, x);
            Canvas.SetTop(ball, y);

            if (y >= _window.Height - 100)
            {
                this._window.timer.Stop();
                this._window.board.Children.Remove(ball);
                _window.timerForTIme.Stop();
                MessageBox.Show("YOU LOSE");
            }

        }
    }
}
