using System;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace CalculatingPI
{
    static class CalcPI
    {
        private static int squareField { get; set; }
        private static int circleField { get; set; }
        private static double valueOfPI { get; set; }
        public static double bestValueOfPI { get; set; }
        internal static int indexOfSameDigits { get; set; } //showing how many digits from approximated value of PI cover with Math.PI value


        public static void CalculateNumberPI(Points point, double CircleRadius)
        {
            squareField++;
            if (point.distance <= CircleRadius)
            {
                circleField++;
            }

            valueOfPI = (4 * (double)circleField) / squareField;  //calculating PI number based on randomness of random dots appearing in circlce inscribed in square

            CheckBestValueOfPie(valueOfPI);

        }

        //searching for most accurate value of PI
        private static void CheckBestValueOfPie(double valueOfPI)
        {
            double approximationErrorOfActualPI = Math.Abs(Math.PI - valueOfPI);
            double approximationErrorOfBestPI = Math.Abs(Math.PI - bestValueOfPI);

            if (approximationErrorOfActualPI < approximationErrorOfBestPI)
            {
                bestValueOfPI = valueOfPI; 
            }
        }

        internal static void ScreenValueOfPI(ref TextBlock myTextBlock)
        {
           
            CheckHowManyDigitsCover();
            string approximatedValueOfPI = Convert.ToString(bestValueOfPI);

            myTextBlock.Text = ""; //firstly we are adding a non-accurate tail of digits, afterwards we are adding to the head a pack of accurate digits
            for (int i = indexOfSameDigits; i < approximatedValueOfPI.Length; i++)
            {
                myTextBlock.Text += approximatedValueOfPI[i];
            }

            ////TextPointer Class can be used for setting place of pointer
            //TextPointer textPointer = myTextBlock.ContentStart;
            //for (int i = 0; i < indexOfSameDigits; i++)
            //{
            //    textPointer.GetPointerContext(LogicalDirection.Forward);
            //}
            //textPointer.GetPointerContext(LogicalDirection.Forward);

            TextRange textRange = new TextRange(myTextBlock.ContentStart, myTextBlock.ContentStart); //changing second paramater of constructor TextRange to ContendEnd will result
                                                                                                     //in showing only accurate digits
            textRange.Text = "";
            for (int i = 0; i < indexOfSameDigits; i++)
            {
                textRange.Text += approximatedValueOfPI[i];
            }
            textRange.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Yellow); //highlighting the accurate digits
            
        }

        //method for checking how many digits of calculated value of PI are accurate to math.PI value
        private static void CheckHowManyDigitsCover()
        {
            string approximatedDigitsPI = Convert.ToString(bestValueOfPI);
            string accurateDigitsPI = Convert.ToString(Math.PI);

            indexOfSameDigits = 0;

            for (int i = 0; i < approximatedDigitsPI.Length; i++)
            {
                if(approximatedDigitsPI[i] == accurateDigitsPI[i])
                {
                    indexOfSameDigits++;
                }
                else
                {
                    break;
                }
            }
            
        }
    }
}
