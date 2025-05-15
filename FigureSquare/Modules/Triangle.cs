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
        private double Side1 { get; set; }
        private double Side2 { get; set; }
        private double Side3 { get; set; }
        public bool Exist { get; set; }
        public string? Type { get; set; }
        private int _sides = 1;

        public Triangle()
        {
            Console.WriteLine("Введите длины сторон треугольника");
            this.Side1 = InputSide();
            this.Side2 = InputSide();
            this.Side3 = InputSide();

            CheckTriangle();
        }
        private void CheckTriangle()
        {
            if (Side1 + Side2 <= Side3 || Side1 + Side3 <= Side2 || Side2 + Side3 <= Side1)
            {
                this.Exist = false;
            }
            else
            {
                this.Exist = true;

                double[] sides = { Side1, Side2, Side3 };
                Array.Sort(sides);

                double shortSide = Math.Pow(sides[0], 2);
                double middleSide = Math.Pow(sides[1], 2);
                double longtSide = Math.Pow(sides[2], 2);

                if (Math.Abs(longtSide - (shortSide + middleSide)) < 1e-10)
                {
                    this.Type = "Прямоугольный треугольник";
                }
                else
                {
                    this.Type = "Непрямоугольный треугольник";
                }
            }
        }
        private double InputSide()
        {
            double side = 0;
            while (side == 0)
            {
                try
                {
                    Console.Write($"Сторна {_sides}: ");
                    if (double.TryParse(Console.ReadLine(), out double input))
                    {
                        if (input > 0)
                        {
                            side = input;
                            _sides++;
                        }
                        else
                        {
                            throw new FormatException();
                        }
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
        public double GetArea()
        {
            var semiPerimeter = (Side1 + Side2 + Side3) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - Side1) * (semiPerimeter - Side2) * (semiPerimeter - Side3));
        }
    }
}
