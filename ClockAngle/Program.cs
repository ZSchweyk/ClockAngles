using System;
using System.Collections.Generic;

namespace ClockAngle
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Clock> times = Clock.GetTimesWithAngle(30);
            Console.WriteLine(times.Count);
            foreach (Clock time in times)
                Console.WriteLine(time);
        }
    }
}
