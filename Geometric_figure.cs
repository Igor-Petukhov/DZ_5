using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_5
{
    abstract class Geometric_figure
    {
        protected float square;
        protected float perimeter;

        public abstract float Square();
        public abstract float Perimeter();

        public void PrintSquareText()
        {
            Console.Write($"Площадь фигуры ");
        }

        public void PrintPerimeterText()
        {
            Console.Write($"Периметр фигуры ");
        }


    }

    class Triangle : Geometric_figure
    {
        int x1, y1, x2, y2, x3, y3;
        float AB, BC, AC;
        
        public Triangle (int x1, int y1, int x2, int y2, int x3, int y3)
        {
            //Проверка треугольника на существование
            AB = (float)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            BC = (float)Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            AC = (float)Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));
            if ((AB + BC <= AC) || (BC + AC <= AB) || (AC + AB <= BC))
                Console.WriteLine("Извините такого треугольника не существует. Возможно :)");
            else
            {
                x1 = x1;
                y1 = y1;
                x2 = x2;
                y2 = y2;
                x3 = x3;
                y3 = y3;
            }
        }
        public override float Square()
        {
            float p = (AB + BC + AC) / 2; //Полупериметр
            return (float)Math.Sqrt(p * (p - AB) * (p - BC) * (p - AC));
        }

        public override float Perimeter()
        {
            return AB + BC + AC;
        }
    }


    class SquareFigure : Geometric_figure
    {
        float AB;
        public SquareFigure(float AB) //получим длину стороны квадрата
        {
            this.AB = AB;
        }
        public override float Square()
        {
            return AB*AB;
        }

        public override float Perimeter()
        {
            return 4*AB;
        }

        public void PrintSquare()
        {
            base.PrintSquareText();
            Console.WriteLine($"квадрат: {Square()}");
        }

        public void PrintPerimeter()
        {
            base.PrintPerimeterText();
            Console.WriteLine($"квадрат: {Perimeter()}");
        }

        
    }
    
    class Rhombus : Geometric_figure
    {
        float AC, BD; //диагонали

        public Rhombus(float AC, float BD) //по двум диагоналям
        {
            this.AC = AC;
            this.BD = BD;
        }
        public override float Perimeter()
        {
            return (float)(2 * (Math.Sqrt(Math.Pow(AC, 2) + Math.Pow(BD, 2))));
        }

        public override float Square()
        {
            return AC * BD / 2;
        }

        public void PrintSquare()
        {
            base.PrintSquareText();
            Console.WriteLine($"ромб: {Square()}");
        }
        
        public void PrintPerimeter()
        {
            base.PrintPerimeterText();
            Console.WriteLine($"ромб: {Perimeter()}");
        }
    }

    class Rectangle : Geometric_figure
    {
        float AB, AD; //через 2 стороны
        public Rectangle(float AB, float AD)
        {
            this.AB = AB;
            this.AD = AD;
        }

        public override float Perimeter()
        {
            return 2*AB + 2*AD;
        }
        public override float Square()
        {
            return AB*AD;
        }

        public void PrintSquare()
        {
            base.PrintSquareText();
            Console.WriteLine($"прямоугольник: {Square()}");
        }

        public void PrintPerimeter()
        {
            base.PrintPerimeterText();
            Console.WriteLine($"прямоугольник: {Perimeter()}");
        }
    }

    class SostavnFigura : Geometric_figure
    {
        private List<Geometric_figure> lst;

        public SostavnFigura()
        {
            this.lst = new List<Geometric_figure>();
        }
        public void Add_figure(int x1, int y1, int x2, int y2, int x3, int y3) //triangle
        {
            Triangle triangle = new Triangle(x1, y1, x2, y2, x3, y3);
            lst.Add(triangle);
        }
        public void Add_figure(float AB) //square figure
        {
            SquareFigure square = new SquareFigure(AB);
            lst.Add(square);
        }
        public void Add_figure(float a, float b, int figure_id)//figure_id 1 - Rhombus, 2 - Rectangle
        {
            switch (figure_id)
            {
                case 1: //rhombus
                    Rhombus rhomb = new Rhombus(a, b);
                    lst.Add(rhomb);
                    break;
                case 2: //rectangle
                    Rectangle rectangle = new Rectangle(a, b);
                    lst.Add(rectangle);
                    break;
                default:
                    break;
            }
            
        }
        public override float Perimeter()
        {
            float tmp = 0;
            for (int i = 0; i < lst.Count; i++)
            {
                tmp += lst[i].Perimeter();
            }
            return tmp;
        }
        public override float Square()
        {
            float tmp = 0;
            for (int i = 0; i < lst.Count; i++)
            {
                tmp += lst[i].Square();
            }
            return tmp;
        }
    }

}
