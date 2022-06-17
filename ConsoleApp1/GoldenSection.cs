using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class GoldenSection
    {
        public delegate double Function(Point x);
        public double eps { get; set; } = 0.01;
        private double fi;
        public long MaxSteps = 10000;
        public long Steps { get; set; }
        public GoldenSection()
        {
            fi = (1 + Math.Sqrt(5)) / 2;
        }
        public double Optimize(Func<Point, double> f, Point vars, int varIndex, double a, double b)
        {
            double x1, x2, y1, y2;
            do
            {
                x1 = b - (b - a) / fi;
                x2 = a + (b - a) / fi;
                vars[varIndex] = x1;
                y1 = f(vars);
                vars[varIndex] = x2;
                y2 = f(vars);
                if (y1 >= y2) a = x1;
                else b = x2;
                Steps++;
                if (Steps > MaxSteps) break;

            }
            while (Math.Abs(b - a) > eps);
            return (b + a) / 2;
        }


    }
}