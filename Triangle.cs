using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naidis_Vorm
{
    public class Triangle
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Triangle(double a, double b, double c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }

        public double Perimeter()
        {
            return A+B+C;
        }

        public double Surface()
        { 
            double p = (A + B + C) / 2;
            return Math.Sqrt(p*(p-A)*(p-B)*(p-C));
        }

        public bool ExistTriangle
        { 
            get
            {
                if((A>B+C) && (B>A+C) && (C>A+B))
                    return false;
                else return true;
            }
        }
    }
}
