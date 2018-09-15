using System;


namespace CalculatingPI
{
    static class CalcPI
    {
        private static int squareField { get; set; }
        private static int circleField { get; set; }
        private static double valueOfPI { get; set; }
        public static double bestValueOfPI { get; set; }


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
    }
}
