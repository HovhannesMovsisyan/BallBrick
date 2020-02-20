using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace GameBall
{
    public class Gridforball:IDraw
    {
        readonly MainWindow _window;
        public Rectangle[,] grid = new Rectangle[5, 8];
        public Gridforball(MainWindow window)
        {
            this._window = window;
        }
        public void Draw()
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = new Rectangle();
                    grid[i, j].Width = 60;
                    grid[i, j].Height = 20;
                    grid[i, j].Fill = Brushes.Yellow;
                    this._window.board.Children.Add(grid[i, j]);
                    Canvas.SetLeft(grid[i, j], 10 + 90 * j);
                    Canvas.SetTop(grid[i, j], 15 + 30 * i);
                }
            }
        }
    }
}
