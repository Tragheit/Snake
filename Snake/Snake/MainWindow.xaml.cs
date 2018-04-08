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

namespace Snake
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly int SIZE = 10;
        private MySnake _snake;

        public MainWindow()
        {
            InitializeComponent();
            InitBoard();
            InitSnake();
        }

        void InitBoard()
        {
            for (int i = 0; i < grid.Width / SIZE; i++)
            {
                ColumnDefinition columnDefinition = new ColumnDefinition();
                columnDefinition.Width = new GridLength(SIZE);
                grid.ColumnDefinitions.Add(columnDefinition);
            }

            for(int i = 0; i < grid.Height; i++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(SIZE);
                grid.RowDefinitions.Add(rowDefinition);
            }

            _snake = new MySnake();
        }

        void InitSnake()
        {
            grid.Children.Add(_snake.Head.Rect);
            
            foreach (SnakePart snakePart in _snake.Parts)
            {
                grid.Children.Add(snakePart.Rect);
                _snake.RedrawSnake();
            }
        }

    }
}
