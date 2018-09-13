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
        Points point;
        public static Image myImageProperties { get; set; }


        public static double myImageWidth { get; set; }
        public static double myImageHeigth { get; set; }

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
            myImageWidth = myImage.Width;
            myImageHeigth = myImage.Height;
            myImageProperties = myImage;

            //setting timer
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatchetTimer_Tick; //adding method to be evoked every "interval" time
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 20); //interval set to 20 milisecond

            point = new Points();
        }

        private void dispatchetTimer_Tick(object sender, EventArgs e)
        {
            //CalculationAndRender.DoCalculationAndRenderGraphic(100);

            MultipleCalculationPerTick(1000);

            //point.settingRandomCoordinates(RandomNumbers.GetRandom(myImage.Width),RandomNumbers.GetRandom(myImage.Height)); //width and height supposed to be same since we are dealing with circle inscribed in square
            //point.CalculateDistanceFromMiddle(myImage.Width / 2, myImage.Height / 2);
        }

        private void MultipleCalculationPerTick(int AmountPerTick)
        {
            for (int i = 0; i < AmountPerTick; i++)
            {
                DrawingHelper.RenderOnImage(myImage);
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
