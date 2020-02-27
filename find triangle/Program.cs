using System;
using System.Collections.Generic;
using System.Text;

namespace Ödev1
{
    class Point
    {
        int x;
        int y;

        //Constructor 
        public Point()
        {
            this.x = 0;
            this.y = 0;
        }
        //Parameter Constructor
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //Distance between two points
        public Double Distance(int x, int y)
        {
            int xdis = this.x - x;
            int ydis = this.y - y;

            return Math.Sqrt(xdis * xdis + ydis * ydis);
        }
        //Distance between two points with object
        public Double Distance(Point N)
        {
            int xdis = this.x - N.x;
            int ydis = this.y - N.y;

            return Math.Sqrt(xdis * xdis + ydis * ydis);
        }
        //Knowledge of point
        public String PointtoString()
        {
            return "The coordinate of x :" + this.x + "   ----  " + "The coordinate of y:" + this.y;
        }
        public int getX()
        {
            return this.x;
        }
        public int getY()
        {
            return this.y;
        }
        public void setX(int x)
        {
            this.x = x;
        }
        public void setY(int y)
        {
            this.y = y;
        }
    }
    class Triangle
    {
        Point p1, p2, p3;
        double edge1, edge2, edge3;

        //Parameter Constructor 
        public Triangle(int p1x, int p1y, int p2x, int p2y, int p3x, int p3y)
        {
            double edge1 = Math.Sqrt(Math.Pow((p2x - p1x), 2) + Math.Pow((p2y - p1y), 2));
            double edge2 = Math.Sqrt(Math.Pow((p3x - p1x), 2) + Math.Pow((p3y - p1y), 2));
            double edge3 = Math.Sqrt(Math.Pow((p3x - p2x), 2) + Math.Pow((p3y - p2y), 2));

            //if it can be a triangle, it creats the following points and edges 
            if (triangleControl(edge1, edge2, edge3)) 
            {
                this.p1 = new Point(p1x, p1y);
                this.p2 = new Point(p2x, p2y);
                this.p3 = new Point(p3x, p3y);
                this.edge1 = edge1;
                this.edge2 = edge2;
                this.edge3 = edge3;
            }
            //if not , creats it autmatically
            else
            {
                Console.WriteLine("Warning:The points given do not form a triangle so automatically assign points (0,0)(0,1)(1,0)");
                this.p1 = new Point(0, 0);
                this.p2 = new Point(0, 1);
                this.p3 = new Point(1, 0);
                this.edge1 = 1;
                this.edge2 = 1;
                this.edge3 = Math.Sqrt(2);
            }
        }
        //Object parameter constructor
        public Triangle(Point p1, Point p2, Point p3)
        {
            double edge1 = Math.Sqrt(Math.Pow((p1.getX() - p2.getX()), 2) + Math.Pow((p1.getY() - p2.getY()), 2));
            double edge2 = Math.Sqrt(Math.Pow((p1.getX() - p3.getX()), 2) + Math.Pow((p1.getY() - p3.getY()), 2));
            double edge3 = Math.Sqrt(Math.Pow((p2.getX() - p3.getX()), 2) + Math.Pow((p2.getY() - p3.getY()), 2));

            //if it can be a triangle, it creats the following points and edges
            if (triangleControl(edge1, edge2, edge3))
            {
                this.p1 = p1;
                this.p2 = p2;
                this.p3 = p3;
                this.edge1 = edge1;
                this.edge2 = edge2;
                this.edge3 = edge3;

            }
            //if not , creats it autmatically
            else
            {
                Console.WriteLine("Warning:The points given do not form a triangle so automatically assign points (0,0)(0,1)(1,0)");
                this.p1 = new Point(0, 0);
                this.p2 = new Point(0, 1);
                this.p3 = new Point(1, 0);
                this.edge1 = 1;
                this.edge2 = 1;
                this.edge3 = Math.Sqrt(2);
            }

        }
        //Check triangulation rule
        public bool triangleControl(double edge1, double edge2, double edge3)
        {
            if (edge1 + edge2 >= edge3)
                if (edge2 + edge3 >= edge1)
                    if (edge2 + edge3 >= edge2)
                        return true;
                    else
                        return false;
                else
                    return false;
            else
                return false;

        }
        // Check triangular type
        public void TriangulaType(Triangle T)
        {
            if (T.edge1 == T.edge2 && T.edge2 == T.edge3)
                Console.WriteLine("Equilateral triangle");
            else if (T.edge1 == T.edge3 && T.edge3 != T.edge2)
                Console.WriteLine("Isosceles triangle");
            else if (T.edge3 == T.edge2 && T.edge2 != T.edge1)
                Console.WriteLine("Isosceles triangle");
            else if (T.edge1 == T.edge2 && T.edge2 != T.edge3)
                Console.WriteLine("Isosceles triangle");
            else
                Console.WriteLine("Diagonal triangle");

        }
        //Calculate perimeter of the triangle
        public void calculatePerimeter(Triangle C)
        {
            Console.WriteLine("Triangle perimeter:" + (C.edge1 + C.edge2 + C.edge3));
        }
        //Knowledge of triangle
        public String TriangleString()
        {
            return "\n1.Point: " + p1.PointtoString() + "\n" + "2.Point: "  + p2.PointtoString() + "\n" + "3.Point: " + p3.PointtoString () +"\n"
                    +"1.Edge: " + this.edge1 + "\n2.Edge: " + this.edge2 + "\n3.Edge: " + this.edge3;
        }
        public Point getP1()
        {
            return this.p1;
        }
        public Point getP2()
        {
            return this.p2;
        }
        public Point getP3()
        {
            return this.p3;
        }
        public double getEdge1()
        {
            return this.edge1;
        }
        public double getEdge2()
        {
            return this.edge2;
        }
        public double getEdge3()
        {
            return this.edge3;
        }
    }
    class Square
    {
        Point rightLower;
        Point leftUpper;
        int edge;

        //Parameter constructor
        public Square(int p1x, int p1y, int p2x, int p2y)
        {
            int edge1 = Math.Abs(p2x - p1x);
            int edge2 = Math.Abs(p2y - p1y);

            //if it can be a square, it creats the following points and edges 
            if (SquareControl(edge1, edge2))
            {
                rightLower = new Point(p1x, p1y);
                leftUpper = new Point(p2x, p2y);
                this.edge = edge1;
            }
            //if not , it creats automatically
            else
            {
                Console.WriteLine("Warning:The points given do not form a square so automatically assign points (1,0)(0,1)");
                rightLower = new Point(1, 0);
                leftUpper = new Point(0, 1);
                this.edge = 1;

            }
        }
        //Object parameter constructor
        public Square(Point p1, Point p2)
        {
            int edge1 = Math.Abs(p1.getX() - p2.getX());
            int edge2 = Math.Abs(p1.getY() - p2.getY());

            //if it can be a square, it creats the following points and edges 
            if (SquareControl(edge1, edge2))
            {
                rightLower = p1;
                leftUpper = p2;
                this.edge = edge1;
            }
            //if not , it creats automatically
            else
            {
                Console.WriteLine("Warning:The points given do not form a square so automatically assign points (1,0)(0,1)");
                rightLower = new Point(1, 0);
                leftUpper = new Point(0, 1);
                this.edge = 1;
            }
        }
        //Check square rule
        public bool SquareControl(int edge1, int edge2)
        {
            if (edge1 == edge2)
                return true;
            else
                return false;
        }
        //Calculate perimeter of the square
        public void SquarePerimeter(Square C)
        {
            Console.WriteLine("Square of perimeter: " + (4 * C.edge));
        }
        //Calculate area of the square
        public void SquareArea(Square A)
        {
            Console.WriteLine("Square of area: " + (A.edge * A.edge));
        }
        //Knowledge of square
        public String SquareString()
        {
            return "\nRight Lower Point: " + rightLower.PointtoString() + "\n" + "Left Upper Point: " + leftUpper.PointtoString();
        }
        public Point getRightLower()
        {
            return rightLower;
        }
        public Point getLeftUpper()
        {
            return leftUpper;
        }
        public int getEdge()
        {
            return this.edge;
        }
    }
    class ComplexNumber
    {
        double realValue;
        double imaginaryValue;

        public double getRealValue()
        {
            return realValue;
        }
        public double getImaginaryValue()
        {
            return imaginaryValue;
        }
        public void setRealValue(double realValue)
        {
            this.realValue = realValue;
        }
        public void setImaginaryValue(double imaginaryValue)
        {
            this.imaginaryValue = imaginaryValue;
        }

        //Constructor 0 + 0*i
        public ComplexNumber()
        {
            this.realValue = 0;
            this.imaginaryValue = 0;
        }
        //Constructor realValue + imaginaryValue*i --> a + b*i
        public ComplexNumber(double realValue, double imaginaryValue)
        {
            this.realValue = realValue;
            this.imaginaryValue = imaginaryValue;
        }
        //Sum of two complex numbers
        public static ComplexNumber operator +(ComplexNumber C1, ComplexNumber C2)
        {
            double realSum = C1.realValue + C2.realValue;
            double imaginarySum = C1.imaginaryValue + C2.imaginaryValue;

            return new ComplexNumber(realSum, imaginarySum);
        }
        //Sum of a complex number and real number
        public static ComplexNumber operator +(ComplexNumber C, double realValue)
        {
            double realSum = C.realValue + realValue;

            return new ComplexNumber(realSum, C.imaginaryValue);
        }
        //Difference of two complex numbers
        public static ComplexNumber operator -(ComplexNumber C1, ComplexNumber C2)
        {
            double realDifference = C1.realValue - C2.realValue;
            double imaginaryDifference = C1.imaginaryValue - C2.imaginaryValue;

            return new ComplexNumber(realDifference, imaginaryDifference);
        }
        //Difference of a complex number and real numbers
        public static ComplexNumber operator -(ComplexNumber C, double realValue)
        {
            double realDifference = C.realValue - realValue;

            return new ComplexNumber(realDifference, C.imaginaryValue);
        }
        //Negative of complex number
        public static ComplexNumber operator -(ComplexNumber C)
        {
            return new ComplexNumber((-1) * C.realValue, (-1) * C.imaginaryValue);
        }
        //Multiplication of two complex number
        public static ComplexNumber operator *(ComplexNumber C1, ComplexNumber C2)
        {
            double realMulti = (C1.realValue * C2.realValue) - (C1.imaginaryValue * C2.imaginaryValue);
            double imaginaryMulti = (C1.realValue * C2.imaginaryValue) + (C1.imaginaryValue * C2.realValue);

            return new ComplexNumber(realMulti, imaginaryMulti);
        }
        //Check the equality of two complex number
        public static bool operator ==(ComplexNumber C1, ComplexNumber C2)
        {
            if (C1.realValue == C2.realValue && C1.imaginaryValue == C2.imaginaryValue)
                return true;
            else
                return false;
        }
        //Check the equality of two complex number
        public static bool operator !=(ComplexNumber C1, ComplexNumber C2)
        {
            if (C1.realValue == C2.realValue && C1.imaginaryValue == C2.imaginaryValue)
                return false;
            else
                return true;
        }
        public String ComplexToString()
        {
            if (this.imaginaryValue < 0)
            {
                return this.realValue + "-" + -1 * this.imaginaryValue + "i";
            }
            else
            {
                return this.realValue + "+" + this.imaginaryValue + "i";
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine(MetotX(array,96));
            Console.WriteLine("\n----------------------------------------------------------\n");

            Point P1 = new Point(3,4);
            Point P2 = new Point(7,24);
            Point P3 = new Point();
            Console.WriteLine("1.Point of knowledge : " + P1.PointtoString());
            Console.WriteLine("2.Point of knowledge : " + P2.PointtoString());
            Console.WriteLine("Origin distance of 1.Point: " + P1.Distance(P3));
            Console.WriteLine("Origin distance of 2.Point: " + P2.Distance(P3));
            Console.WriteLine("Distance between two points: "+P1.Distance(P2));
            Console.WriteLine("Distance between two points: " + P1.Distance(7,24));
            Console.WriteLine("\n----------------------------------------------------------\n");

            Triangle T1 = new Triangle(3,4,7,24,0,0);
            Triangle T2 = new Triangle(P1,P2,P3);
            Triangle T3 = new Triangle(0,0,0,8,0,4);
            Console.WriteLine("Knowledge of triangle : " + T1.TriangleString());
            T1.TriangulaType(T1);
            T1.calculatePerimeter(T1);
            Console.WriteLine("\n----------------------------------------------------------\n");
            Console.WriteLine("Knowledge of triangle : " + T2.TriangleString());
            T2.TriangulaType(T2);
            T2.calculatePerimeter(T2);
            Console.WriteLine("\n----------------------------------------------------------\n");
            Console.WriteLine("Knowledge of triangle : " + T3.TriangleString());
            T3.TriangulaType(T3);
            T3.calculatePerimeter(T3);
            Console.WriteLine("\n----------------------------------------------------------\n");

            Square S1 = new Square(3,4,7,24);
            Square S2 = new Square(P1, P2);
            Square S3 = new Square(1, 4, 4, 1);
            Console.WriteLine("Knowledge of square : " + S1.SquareString());
            S1.SquarePerimeter(S1);
            S1.SquareArea(S1);
            Console.WriteLine("\n----------------------------------------------------------\n");
            Console.WriteLine("Knowledge of square : " + S3.SquareString());
            S3.SquarePerimeter(S3);
            S3.SquareArea(S3);
            Console.WriteLine("\n----------------------------------------------------------\n");

            ComplexNumber C1 = new ComplexNumber(3, 7);
            ComplexNumber C2 = new ComplexNumber(1, -9);
            ComplexNumber C3 = new ComplexNumber();
            ComplexNumber C4 = new ComplexNumber(3, 7);
            Console.WriteLine("1.Complex Number: " + C1.ComplexToString());
            Console.WriteLine("2.Complex Number: " + C2.ComplexToString());
            Console.WriteLine("3.Complex Number: " + C3.ComplexToString());
            Console.WriteLine("4.Complex Number: " + C4.ComplexToString());
            Console.WriteLine("Sum of 1. and 2. complex numbers : " + (C1+C2).ComplexToString());
            Console.WriteLine("Sum of a complex numbers and a real number: " + (C1+5).ComplexToString());
            Console.WriteLine("Difference of 1. and 2. complex numbers : " + (C1-C2).ComplexToString());
            Console.WriteLine("Difference of a complex numbers and a real number: " + (C1 - 3).ComplexToString());
            Console.WriteLine("Negative of 2.complex number: " + (-C2).ComplexToString());
            Console.WriteLine("Multiplication of 1. and 2. complex numbers: " + (C1*C2).ComplexToString());
            if (C1 != C2)
                Console.WriteLine("1. and 2. complex numbers are different from each other");
            if (C1 == C4)
                Console.WriteLine("1. and 4. complex number are same from each other");
        }

        static bool MetotX(int[] array, int key, int i = 0)
        {
            int size = array.Length;

            if (size > i && array[i] != key)
            {
                i++;
                MetotX(array, key, i);
            }
            else if (i >= size)
                return false;
            else if (i < size && array[i] == key)
                return true;
            if (MetotX(array, key, i) == true && i < size)
                return true;
            else
                return false;
        }
    }
}