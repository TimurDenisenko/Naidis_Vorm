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
        //Perimeeter
        public double Surface()
        {
            if (On)
            {
                double p = (A + B + C) / 2;
                return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            }
            else return 0;
        }
        //Ruut
        public double Height(double side)
        {
            if (On)
                return (2 * Surface()) / side;
            else 
                return 0;
        }
        //Kõrgus
        public double Median(double side)
        {
            double side1, side2;
            if (On)
            {
                if (side==A)
                {
                    side1 = B;
                    side2 = C;
                }
                else if (side==B)
                {
                    side1 = A;
                    side2 = C;
                }
                else if (side==C)
                {
                    side1 = A;
                    side2 = B;
                }
                else
                {
                    return 0;
                }
                return (1 / 2) * Math.Sqrt(2 * (side1*side1 + side2*side2) - side*side);
            }
            else
                return 0;
        }
        //Mediaan
        public double Angle(string angle)
        {
            double side1, side2, side3;
            side1 = side2 = side3 = 0;
            if (On)
            {
                switch (angle)
                {
                    case "alpha":
                        side1 = A;
                        side2 = C;
                        side3 = B;
                        break;
                    case "beta":
                        side1 = A;
                        side2 = B;
                        side3 = C;
                        break;
                    case "gamma":
                        side1 = B;
                        side2 = C;
                        side3 = A;
                        break;
                    default:
                        return 0;
                }
                return Math.Acos(((side1*side1)+(side2*side2)-(side3*side3))/(2*side1*side2)) * 180 / Math.PI;
            }
            else
                return 0;
        }
        //Nurk
        public double Bisector(string side)
        {
            double side1, side2;
            if (On)
            {
                double angle;
                switch (side)
                {
                    case "AB":
                        angle = Angle("gamma");
                        side1 = A;
                        side2 = B;
                        break;
                    case "BC":
                        angle = Angle("alpha");
                        side1 = B;
                        side2 = C;
                        break;
                    case "CA":
                        angle = Angle("beta");
                        side1 = C;
                        side2 = A;
                        break;
                    default:
                        return 0;
                }
                return 2*side1*side2/(side1+side2)*Math.Cos(angle/2);
            }
            else
                return 0;
        }
        //Poolitaja
        public double[] All()
        {
            double[] all = new double[] { };
            if (On)
            {
                foreach (double item in new double[] {Perimeter(), Surface(), Height(A), Height(B), Height(B), Median(A), Median(B), Median(B), Angle("alpha"), Angle("beta"), Angle("gamma"), Bisector("AB"), Bisector("BC"), Bisector("CB")})
                {
                    all.Append(item);
                }
                return all;
            }
            else
                return new double[] {0};
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
