using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
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

        public static RenderTargetBitmap createBitmap()
        {
            rtb.Render(dVisual);
            return rtb;
        }

        public static void RenderOnImage(Image image)
        {
            using (DrawingContext dc = dVisual.RenderOpen())
            {
                //for (int i = 0; i < 1000; i++)
                //{
                    dc.DrawEllipse(MyBlueBrush, null,
                        new Point(RandomNumbers.GetRandom(MainWindow.myImageWidth), RandomNumbers.GetRandom(MainWindow.myImageHeigth)), 1, 1);

                    image.Source = createBitmap();
                //}
            }
        }

    }


}
