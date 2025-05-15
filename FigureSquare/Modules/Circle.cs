using FigureSquare.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureSquare.Modules
{
    public class Circle : IFigure
    {
        public double Radius { get; }

        public Circle()
        {
            double radius = 0;
            while (radius <= 0)
            {
                Console.Write("Введите радиус: ");
                try
                {
                    if (double.TryParse(Console.ReadLine(), out double input) && input > 0)
                    {
                        radius = input;
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

            Radius = radius;
        }

        // Конструктор для юнит-тестов
        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Радиус должен быть положительным");

            Radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
