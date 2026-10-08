using System;
using System.Collections.Generic;

namespace Shapes;

class Program
{
    static void Main(string[] args)
    {
        // 1. Crear una lista heterogénea de Shapes
        List<Shape> shapes = new List<Shape>();

        // 2. Instanciar las distintas formas geométricas
        Square redSquare = new Square("Rojo", 5);
        Rectangle blueRectangle = new Rectangle("Azul", 4, 6);
        Circle greenCircle = new Circle("Verde", 3);

        // 3. Agregar todas las figuras a la misma lista
        shapes.Add(redSquare);
        shapes.Add(blueRectangle);
        shapes.Add(greenCircle);

        // 4. Polimorfismo en acción: iterar la lista e invocar GetColor() y GetArea()
        Console.WriteLine("--- Resultados de las Figuras Geométricas ---\n");

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"Figura de color {color} tiene un área de: {area:F2}");
        }
    }
}