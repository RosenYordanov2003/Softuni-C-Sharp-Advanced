using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape circle = new Circle();
            IShape square = new Square();
            IShape rectangle = new Rectangle();
            GraphicEditor editor = new GraphicEditor();
            editor.DrawShape(circle);
            editor.DrawShape(square);
            editor.DrawShape(rectangle);
        }
    }
}
