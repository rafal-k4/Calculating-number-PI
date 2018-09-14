using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CalculatingPI
{
    static class DrawingHelper
    {
        static RenderTargetBitmap rtb = new RenderTargetBitmap((int)MainWindow.myImageWidth, (int)MainWindow.myImageHeigth, 0, 0, PixelFormats.Pbgra32);
        static DrawingVisual _dVisual = new DrawingVisual();
        static Brush myGreenBrush = Brushes.Green;
        static Brush myBlueBrush = Brushes.Blue;
        static Pen myBlackPen = new Pen(Brushes.Black, 5);
        

        public static DrawingVisual dVisual { get { return _dVisual; } }
        public static Brush MyGreenBrush { get => myGreenBrush; }
        public static Brush MyBlueBrush { get => myBlueBrush; }
        public static Pen MyBlackPen { get => myBlackPen; }

        private static Point myPoint = new Point();


        private static RenderTargetBitmap createBitmap()
        {
            rtb.Render(dVisual);
            return rtb;
        }

        public static void RenderOnImage(Image image, Points point)
        {
            using (DrawingContext dc = dVisual.RenderOpen())
            {
                myPoint.X = point.coordinateX;
                myPoint.Y = point.coordinateY;

                if(point.distance < image.Width/2)
                {
                    dc.DrawEllipse(MyGreenBrush, null, myPoint, 1, 1);
                }
                else
                {
                    dc.DrawEllipse(MyBlueBrush, null, myPoint, 1, 1);
                }

                image.Source = createBitmap();

            }
        }

        public static void DrawRectangleAndCircle(Image image)
        {
            using (DrawingContext dc = dVisual.RenderOpen())
            {
                myPoint.X = image.Width/2;
                myPoint.Y = image.Height/2;
                dc.DrawEllipse(null, myBlackPen, myPoint, image.Width / 2, image.Height / 2);
                dc.DrawRectangle(null, myBlackPen, new Rect(0, 0, image.Width, image.Height));

                image.Source = createBitmap();
            }
        }
    }


}
