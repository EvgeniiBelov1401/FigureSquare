using FigureSquare.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureSquare.Modules
{
    public class Triangle : IFigure
    {
        public double Side1 { get; private set; }
        public double Side2 { get; private set; }
        public double Side3 { get; private set; }

        public bool Exist { get; private set; }
        public string? Type { get; private set; }


        public Triangle()
        {
            Console.WriteLine("Введите длины сторон треугольника");

            Side1 = InputSide(1);
            Side2 = InputSide(2);
            Side3 = InputSide(3);

            CheckTriangle();
        }

        // Конструктор для юнит-тестов 
        public Triangle(double side1, double side2, double side3)
        {
            if (side1 <= 0 || side2 <= 0 || side3 <= 0)
            {
                throw new ArgumentException("Стороны должны быть положительными");
            }

            Side1 = side1;
            Side2 = side2;
            Side3 = side3;

            CheckTriangle();
        }

        private double InputSide(int index)
        {
            double side = 0;
            while (side <= 0)
            {
                Console.Write($"Сторона {index}: ");
                try
                {
                    if (double.TryParse(Console.ReadLine(), out double input) && input > 0)
                    {
                        side = input;
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите корректные данные...");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return side;
        }

        private void CheckTriangle()
        {
            if (Side1 + Side2 <= Side3 || Side1 + Side3 <= Side2 || Side2 + Side3 <= Side1)
            {
                Exist = false;
                return;
            }

            Exist = true;

            double[] sides = { Side1, Side2, Side3 };
            Array.Sort(sides);

            double shortSide = Math.Pow(sides[0], 2);
            double middleSide = Math.Pow(sides[1], 2);
            double longSide = Math.Pow(sides[2], 2);

            Type = Math.Abs(longSide - (shortSide + middleSide)) < 1e-10 ? "Прямоугольный треугольник" : "Непрямоугольный треугольник";
        }

        public double GetArea()
        {
            if (!Exist) return 0;

            var semiPerimeter = (Side1 + Side2 + Side3) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - Side1) * (semiPerimeter - Side2) * (semiPerimeter - Side3));
        }
    }
}
