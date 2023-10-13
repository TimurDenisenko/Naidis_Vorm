using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naidis_Vorm
{
    public class Triangle
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }
        public bool On = false;

        public Triangle(double a, double b, double c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
            On = ExistTriangle;
        }

        public Triangle(double a) 
        { 
            this.A = a;
            this.B = a;
            this.C = a;
        }

        public void SetA(double a) { this.A = a; On = ExistTriangle; }

        public void SetB(double b) { this.B = b; On = ExistTriangle; }

        public void SetC(double c) { this.C = c; On = ExistTriangle; }

        public double Perimeter()
        {
            if (On) return A+B+C;
            else return 0;
        }

        public double Surface()
        {
            if (On)
            {
                double p = (A + B + C) / 2;
                return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            }
            else return 0;
        }

        public double Height(double a)
        {
            if (On)
                return (2 * Surface()) / a;
            else 
                return 0;
        }

        public bool ExistTriangle
        { 
            get
            {
                if ((A < B + C) && (B < A + C) && (C < A + B))
                {
                    On = true;
                    return true;
                }
                else
                {
                    On = false;
                    return false;
                }
            }
        }
    }
}
