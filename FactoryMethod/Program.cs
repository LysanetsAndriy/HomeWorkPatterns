using System;
namespace FactoryMethodExample
{
    public interface IShape
    {
        void Draw();
    }
    public class Triangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Трикутник був намальований");
        }
    }
    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Коло було намальоване");
        }
    }
    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Прямокутник був намальований");
        }
    }
    public interface IShapeFactory
    {
        IShape CreateShape();
    }
    public class TriangleFactory : IShapeFactory
    {
        public IShape CreateShape()
        {
            return new Triangle();
        }
    }
    public class CircleFactory : IShapeFactory
    {
        public IShape CreateShape()
        {
            return new Circle();
        }
    }
    public class RectangleFactory : IShapeFactory
    {
        public IShape CreateShape()
        {
            return new Rectangle();
        }
    }
    class Program
    {
        static void Main()
        {
            IShapeFactory triangleFactory = new TriangleFactory();
            IShape triangle = triangleFactory.CreateShape();
            triangle.Draw();

            IShapeFactory rectangleFactory = new RectangleFactory();
            IShape rectangle = rectangleFactory.CreateShape();
            rectangle.Draw();

            IShapeFactory circleFactory = new CircleFactory();
            IShape circle = circleFactory.CreateShape();
            circle.Draw();
        }
    }
}

