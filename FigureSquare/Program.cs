using FigureSquare.Interfaces;
using FigureSquare.Modules;

internal class Program
{
    /*
     * Напишите на C# или Python библиотеку для поставки внешним клиентам, которая умеет вычислять 
     * площадь круга по радиусу и треугольника по трем сторонам. Дополнительно:
        - Юнит-тесты
        - Легкость добавления других фигур
        - Вычисление площади фигуры без знания типа фигуры в compile-time
        - Проверку на то, является ли треугольник прямоугольным
     */
    private static void Main(string[] args)
    {
        Start();
    }
    private static void Start()
    {
        while (true)
        {
            Console.WriteLine("ПРОГРАММА ДЛЯ ВЫЧИСЛЕНИЯ ПЛОЩАДИ РАЗНЫХ ФИГУР\n");
            Console.WriteLine($"Фигуры:{Environment.NewLine}" +
                $"1 - Круг{Environment.NewLine}" +
                $"2 - Треугольник");
            Console.Write("Выберите номер фигуры: ");
            try
            {
                if (uint.TryParse(Console.ReadLine(), out uint choosenItem))
                {
                    switch (choosenItem)
                    {
                        case 1:
                            var circle = new Circle();
                            ShowResult(circle);
                            break;
                        case 2:
                            var triangle = new Triangle();
                            if (triangle.Exist)
                            {
                                Console.WriteLine($"Тип: {triangle.Type}");
                                ShowResult(triangle);
                            }
                            else
                            {
                                Console.WriteLine("Такого треугольника не существует...");
                            }
                            break;
                        default:
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

            Console.ReadLine();
            Console.Clear();
        }
    }
    private static void ShowResult(IFigure figure)
    {
        try
        {
            if (figure is null)
            {
                throw new ArgumentNullException(nameof(figure));
            }
            else
            {
                var square = figure.GetArea();
                Console.WriteLine($"Площадь: {square:F2}");
            }
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}