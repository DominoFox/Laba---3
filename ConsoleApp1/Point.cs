using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Point
    {
        public double[] pointValue;
        public int length;
        public Point(double[] point)
        {
            pointValue = point;
            length = point.Length;
        }

        public double this[int index]
        {
            get
            {
                if (index >= 0 && index < pointValue.Length)
                    return pointValue[index]; 
                else
                    throw new ArgumentOutOfRangeException(); 
            }
            set
            {
                if (index >= 0 && index < pointValue.Length)
                    pointValue[index] = value;    
            }
        }
    }
}
