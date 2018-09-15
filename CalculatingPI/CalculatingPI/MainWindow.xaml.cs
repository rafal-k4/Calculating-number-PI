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


namespace CalculatingPI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DispatcherTimer dispatcherTimer; //timer periodically evoking sets of function
        List<Points> points = new List<Points>();

        public static int myImageWidth { get; set; }
        public static int myImageHeigth { get; set; }

        public static Image myImageProperties { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Start();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //getting heigth and width of Image Control
            myImageHeigth = (int)myImage.Height;
            myImageWidth = (int)myImage.Width;

            //setting timer
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatchetTimer_Tick; //adding method to be evoked every "interval" time
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 5); //interval set to 20 milisecond
            
            startingCollectionOfPoints(1000); //this value sets the amount of dots rendered on screen per one timer tick.
        }

        private void startingCollectionOfPoints(int AmountOfObjectInCollection)
        {
            for (int i = 0; i < AmountOfObjectInCollection; i++)
            {
                points.Add(new Points());
            }
        }

        private void dispatchetTimer_Tick(object sender, EventArgs e)
        {
            foreach (Points point in points)
            {

                point.settingRandomCoordinates(RandomNumbers.GetRandom(myImage.Width), RandomNumbers.GetRandom(myImage.Height));
                point.CalculateDistanceFromMiddle(myImage.Width / 2, myImage.Height / 2);

                DrawingHelper.RenderOnImage(myImage, point);

                //TextBoxShowingValue.Text = CalcPI.CalculateNumberPI(point, myImage.Width / 2).ToString();
                CalcPI.CalculateNumberPI(point, myImage.Width / 2);

            }

            TextBoxShowingValue.Text = CalcPI.bestValueOfPI.ToString();
            
            DrawingHelper.DrawRectangleAndCircle(myImage);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Calculating value of PI in this project is made by counting dots randomly placed in circle and square."
                +Environment.NewLine +"Knowing the fact that circle inscribed in square share the same length of diameter as the side of a square we can derive the formula of PI." 
                + Environment.NewLine +"Based on this formula, we can calculate the approximate value of the number PI" 
                + Environment.NewLine +"Accuracy of calculated PI number strictly depends on randomness of the generated numbers.");
        }
    }
}
