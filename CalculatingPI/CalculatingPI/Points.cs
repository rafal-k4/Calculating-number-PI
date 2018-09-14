using System;


namespace CalculatingPI
{
    class Points:MainWindow
    {
        public double coordinateX { get; set; }
        public double coordinateY { get; set; }

        public double distance { get; set; }
        

        public void CalculateDistanceFromMiddle(double middlePoint_X, double middlePoint_Y)
        {
            
            distance = Math.Sqrt((coordinateX - middlePoint_X) * (coordinateX - middlePoint_X)
                + (coordinateY - middlePoint_Y) * (coordinateY - middlePoint_Y));
        }

        public void settingRandomCoordinates(double valueX, double valueY)
        {
            coordinateX = valueX;
            coordinateY = valueY;
        }
    }
}
