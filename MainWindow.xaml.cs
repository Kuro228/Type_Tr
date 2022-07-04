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

namespace Type_Tr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        public Point[] points = new Point[3];

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            points[0].X = Convert.ToDouble(x1.Text);
            points[0].Y = Convert.ToDouble(y1.Text);
            points[1].X = Convert.ToDouble(x2.Text);
            points[1].Y = Convert.ToDouble(y2.Text);
            points[2].X = Convert.ToDouble(x3.Text);
            points[2].Y = Convert.ToDouble(y3.Text);
            Line line1 = new Line();
            line1.Stroke = Brushes.Black;
            Line line2 = new Line();
            line2.Stroke = Brushes.Black;
            Line line3 = new Line();
            line3.Stroke = Brushes.Black;

            //Первая линия
            line1.X1 = points[1].X;
            line1.Y1 = points[1].Y;
            line1.X2 = points[2].X;
            line1.Y2 = points[2].Y;
            //Вторая линия
            line2.X1 = points[2].X;
            line2.Y1 = points[2].Y;
            line2.X2 = points[0].X;
            line2.Y2 = points[0].Y;
            //Третья линия
            line3.X1 = points[0].X;
            line3.Y1 = points[0].Y;
            line3.X2 = points[1].X;
            line3.Y2 = points[1].Y;
            //строим треугольник 
            canvas.Children.Add(line1);
            canvas.Children.Add(line2);
            canvas.Children.Add(line3);

            



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            double X1 = Convert.ToDouble(x1.Text);
            double Y1 = Convert.ToDouble(y1.Text);
            double X2 = Convert.ToDouble(x2.Text);
            double Y2 = Convert.ToDouble(y2.Text);
            double X3 = Convert.ToDouble(x3.Text);
            double Y3 = Convert.ToDouble(y3.Text);

            double a = Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
            double b = Math.Sqrt(Math.Pow(X3 - X2, 2) + Math.Pow(Y3 - Y2, 2));
            double c = Math.Sqrt(Math.Pow(X3 - X1, 2) + Math.Pow(Y3 - Y1, 2));
            lenght_a.Text = Convert.ToString(a);
            lenght_b.Text = Convert.ToString(b);
            lenght_c.Text = Convert.ToString(c);
            double alpha = 0;
            double betta = 0;
            double gamma = 0;

            alpha = Math.Truncate(((Math.Acos((b * b + c * c - a * a) / (2 * b * c)) * 180)) / Math.PI);
            betta = Math.Truncate(((Math.Acos((a * a + c * c - b * b) / (2 * a * c)) * 180)) / Math.PI);
            gamma = Math.Truncate(((Math.Acos((a * a + b * b - c * c) / (2 * a * b)) * 180)) / Math.PI);

         
            if (a < (b + c) && b < (a + c) && c < (a + b))
            {
                if ((alpha == 90) || (betta == 90) || (gamma == 90))
                {
                    L3.Foreground = Brushes.Red;//прямоугольный 
                    L2.Foreground = Brushes.Black;
                    L1.Foreground = Brushes.Black;
                }
                else if ((alpha > 90) || (betta > 90) || (gamma > 90))
                {
                    L2.Foreground = Brushes.Red;//тупоугольный 
                    L1.Foreground = Brushes.Black;
                    L3.Foreground = Brushes.Black;
                }
                else
                {
                    L1.Foreground = Brushes.Red;//остроугольный 
                    L2.Foreground = Brushes.Black;
                    L3.Foreground = Brushes.Black;
                }
                if ((a == b) && (a == c) && (b == c))
                {
                    L5.Foreground = Brushes.Red;//равносторонний 
                    L6.Foreground = Brushes.Black;
                }
                else
                {
                    L6.Foreground = Brushes.Red;//разносторонний 
                    L5.Foreground = Brushes.Black;
                }
                if ((alpha == betta) || (alpha == gamma) || (betta == gamma)) L4.Foreground = Brushes.Red;
                else L4.Foreground = Brushes.Black;

                if (a % 3 == 0)
                {
                    if (b % 4 == 0 && c % 5 == 0) L7.Foreground = Brushes.Red;
                    if (c % 4 == 0 && b % 5 == 0) L7.Foreground = Brushes.Red;

                }
                else if (a % 4 == 0) {
                    if (b % 3 == 0 && c % 5 == 0) L7.Foreground = Brushes.Red;
                    if (c % 3 == 0 && b % 5 == 0) L7.Foreground = Brushes.Red;

                }
                else if (a % 5 == 0)
                {
                    if (b % 3 == 0 && c % 4 == 0) L7.Foreground = Brushes.Red;
                    if (c % 3 == 0 && b % 4 == 0) L7.Foreground = Brushes.Red;

                }else L7.Foreground = Brushes.Black;
            }
            
        }
    }
}
