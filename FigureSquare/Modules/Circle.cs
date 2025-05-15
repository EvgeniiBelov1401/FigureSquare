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
        private double Radius { get; set; }
        public Circle()
        {
            while (Radius == default)
            {
                Console.Write("Введите радиус: ");
                try
                {
                    if (double.TryParse(Console.ReadLine(), out double radius))
                    {
                        if (radius > 0)
                        {
                            this.Radius = radius;
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
        }
        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
