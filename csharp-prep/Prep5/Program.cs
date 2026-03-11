
class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("= Testing Individual Shapes =\n");

        Square sq = new Square("Red", 5);
        Console.WriteLine($"Square  -> Color: {sq.GetColor()}, Area: {sq.GetArea()}");

        Rectangle rect = new Rectangle("Blue", 4, 6);
        Console.WriteLine($"Rect    -> Color: {rect.GetColor()}, Area: {rect.GetArea()}");

        Circle circ = new Circle("Green", 3);
        Console.WriteLine($"Circle  -> Color: {circ.GetColor()}, Area: {circ.GetArea():F2}");

        // Build a List<Shape> and iterate
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 4, 6));
        shapes.Add(new Circle("Green", 3));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetType().Name,-12} → Color: {shape.GetColor(),-8} Area: {shape.GetArea():F2}");
        }
    }
}