using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle ABC = new Triangle(0, 0, 0, 2, 5, 0);
            Console.WriteLine($"Периметр треугольника АВС: {ABC.Perimeter()}");
            Console.WriteLine($"Площадь треугольника АВС: {ABC.Square()}");

            SquareFigure ABCD = new SquareFigure(10);
            ABCD.PrintPerimeter();
            ABCD.PrintSquare();

            Rhombus rhombus = new Rhombus(10, 20);
            rhombus.PrintPerimeter();
            rhombus.PrintSquare();

            Rectangle rectangle = new Rectangle(10, 20);
            rectangle.PrintPerimeter();
            rectangle.PrintSquare();

            //float tmp = 0;
            //Geometric_figure[] SostavnFigura =
            //{
            //    ABC, ABCD, rhombus, rectangle
            //};
            //foreach (var item in SostavnFigura)
            //{
            //    tmp += item.Square();
            //}
            //Console.WriteLine(tmp);

            SostavnFigura sf = new SostavnFigura();
            sf.Add_figure(0, 0, 0, 2, 5, 0);
            sf.Add_figure(10);
            sf.Add_figure(10, 20, 1);
            sf.Add_figure(10, 20, 2);
            Console.WriteLine($"Периметр составной фигуры: {sf.Perimeter()}");
            Console.WriteLine($"Площадь составной фигуры: {sf.Square()}");

            Console.ReadKey();
        }
    }
}
