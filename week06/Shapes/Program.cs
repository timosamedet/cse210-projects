using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Square square = new Square("Blue", 15);
        Rectangle rectangle = new Rectangle("Green", 25, 12);
        Circle circle = new Circle("Grey", 30.5);

        List<Shape> shapes = new List<Shape>{square, rectangle, circle};

        foreach(Shape shape in shapes){
            Console.WriteLine($"{shape.GetType().Name} - Color: {shape.GetColor()}, Area: {shape.GetArea()}");
        }
    }
}