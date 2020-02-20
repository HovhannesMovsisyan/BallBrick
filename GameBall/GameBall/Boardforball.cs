using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using GameBall.Interfaces;

namespace GameBall
{
   public class Boardforball : IDraw, IMoveable
    {
        MainWindow _window;
        public Rectangle boardForBall;
        private int width;
        private readonly int height;
        private int x;
        private readonly int y;
        private readonly int directX;
        public Boardforball(MainWindow window)
        {
            this._window = window;
            this.width = 180;
            this.height = 20;
            this.x = (int)this._window.Width / 3;
            this.y = (int)this._window.Height - 120;
            this.directX = 50;
        }
        public void Draw()
        {
            boardForBall = new Rectangle();
            boardForBall.Width = width;
            boardForBall.Height = height;
            boardForBall.Fill = Brushes.Blue;
            this._window.board.Children.Add(boardForBall);
            Canvas.SetTop(boardForBall, y);
            Canvas.SetLeft(boardForBall, x);
        }


        public void MoveRight()
        {
            x = (int)Canvas.GetLeft(boardForBall);
            if (x + width + 50 < this._window.Width)
                x += directX;
            Canvas.SetLeft(boardForBall, x);
        }

        public void MoveLeft()
        {
            x = (int)Canvas.GetLeft(boardForBall);
            if (x > 50)
                x -= directX;
            Canvas.SetLeft(boardForBall, x);

        }

    }
}
