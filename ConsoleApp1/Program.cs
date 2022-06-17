using System;

namespace ConsoleApp1
{
    class Program
    {
        static double f(Point point) => point[0] + point[1] - ((point[0] + point[1]) * (point[0] + point[1])) - (4 * point[1] * point[1]);
        static Point GaussMin(Func<Point, double> f, Point start, double pr = 0.01, double g = 1)
        {
            Point uTemp = start;
            double I1, I2;
            int size = start.length;
            double gr;
            double h = 1e-6;

            for (int k = 1; k < 1000; k++)
            {
                double checkSum = 0;
                Point prevPoint = uTemp;
                for (int i = 0; i < size; i++)
                {
                    Point stepPoint = uTemp;
                    stepPoint[i] = stepPoint[i] + h;
                    I1 = f(stepPoint);

                    stepPoint = uTemp;
                    stepPoint[i] = stepPoint[i] - 2 * h;
                    I2 = f(stepPoint);

                    gr = (I1 - I2) / (2 * h);

                    uTemp[i] = uTemp[i] - g * gr;

                    checkSum += (prevPoint[i] - uTemp[i]) * (prevPoint[i] - uTemp[i]);

                    if(i == 0) Console.WriteLine($"X: \t {uTemp[i]}");
                    if(i == 1) Console.WriteLine($"Y: \t {uTemp[i]}\n");
                    Console.WriteLine($"({prevPoint[i]} - {uTemp[i]}) * ({prevPoint[i]} - {uTemp[i]}) \t {checkSum}\n");

                }
                if (Math.Sqrt(checkSum) <= pr && k > 1)
                {
                    Console.WriteLine($"Done.Number of steps: { k}");
                    break;
                }
            }
            return uTemp;
        }
        static void Main(string[] args)
        {
            var res = GaussMin(f, new Point(new double[] {0, 0 }));
            for (int i = 0; i < res.pointValue.Length; i++)
            {
                Console.WriteLine($"{res[i]}; \n");
            }
            Console.ReadKey();
        }
    }
}
