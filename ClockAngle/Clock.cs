using System;
using System.Collections.Generic;
using System.Text;

namespace ClockAngle
{
    class Clock
    {
        private int hour;
        private int minute;
        private int second;
        private static double anglePerTick = 6;
        public Clock(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public static List<Clock> GetTimesWithAngle(double angle, double tolerance = .01, bool measureAcuteOnly = true, bool absolute = true)
        {
            var result = new List<Clock>();
            Clock c;
            for (int hours = 0; hours < 24; hours++)
            {
                for (int minutes = 0; minutes < 60; minutes++)
                {
                    for (int seconds = 0; seconds < 60; seconds++)
                    {
                        c = new Clock(hours, minutes, seconds);
                        double calculatedAngle = c.GetAngle(measureAcuteOnly, absolute);
                        double highBound = angle + tolerance;
                        double lowBound = angle - tolerance;
                        if (highBound >= calculatedAngle && lowBound <= calculatedAngle)
                            result.Add(c);
                    }
                }
            }
            return result;
        }

        public double GetAngle(bool measureAcuteOnly = true, bool absolute = true)
        {
            double minute = this.minute + (double) second / 60;
            double hour = this.hour + (double) minute / 60;

            double minuteTicks = minute;
            double hourTicks = (hour * 5) % 60;

            double angle = (minuteTicks - hourTicks) * anglePerTick;
            if (measureAcuteOnly && angle > 180)
            {
                angle = (hourTicks - minuteTicks) * anglePerTick;
                return absolute ? Math.Abs(angle) : angle;
            }
            return absolute ? Math.Abs(angle) : angle;
        }

        public override string ToString()
        {
            string h = hour.ToString();
            string m = minute.ToString();
            string s = second.ToString();

            if (hour < 10)
                h = $"0{hour}";
            if (minute < 10)
                m = $"0{minute}";
            if (second < 10)
                s = $"0{second}";

            return $"{h}:{m}:{s}";
        }

    }
}
