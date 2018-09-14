using System;


namespace CalculatingPI
{
    static class RandomNumbers
    {
        static public Random rand { get; set; } = new Random();
        
        static public double GetRandom(double maxValue) // returns double random value, where max value is given by user
        {
            return rand.NextDouble() * maxValue;
        }
    }
}
