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
        public static Image myImageProperties { get; set; }
        public static int myImageWidth { get; set; }
        public static int myImageHeigth { get; set; }


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
            //myImageProperties = myImage;

            //setting timer
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatchetTimer_Tick; //adding method to be evoked every "interval" time
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 20); //interval set to 20 milisecond

            startingCollectionOfPoints(1000);
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
            }

            
        }

       
    }

    //class CalculationAndRender
    //{

    //    internal static void DoCalculationAndRenderGraphic(int AmountPerTick)
    //    {
    //        using (DrawingContext dc = DrawingHelper.dVisual.RenderOpen())
    //        {
    //            for (int i = 0; i < AmountPerTick; i++)
    //            {
    //                dc.DrawEllipse(DrawingHelper.MyBlueBrush, null, 
    //                    new Point(RandomNumbers.GetRandom(MainWindow.myImageWidth), RandomNumbers.GetRandom(MainWindow.myImageHeigth)), 1, 1);

    //                MainWindow.myImageProperties.Source = DrawingHelper.createBitmap();
    //            }
    //        }


    //    }
    //}
}
