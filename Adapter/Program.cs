using System;
using FactoryMethodExample;

namespace AdapterMethodExample
{
    interface IPolygon
    {
        void DrawPolygon();
    }

    class PolygonAdapter : IPolygon
    {
        private IShape shape;

        public PolygonAdapter(IShape shape)
        {
            this.shape = shape;
        }

        public void DrawPolygon()
        {
            Console.WriteLine("Фігуру адаптовано до полігону:");
            if (shape is Circle)
            {
                Console.WriteLine("Помилка: Коло не є багатокутником.");
            }
            else
            {
                shape.Draw();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            IShapeFactory triangleFactory = new TriangleFactory();
            IShape triangle = triangleFactory.CreateShape();

            IShapeFactory rectangleFactory = new RectangleFactory();
            IShape rectangle = rectangleFactory.CreateShape();

            IShapeFactory circleFactory = new CircleFactory();
            IShape circle = circleFactory.CreateShape();

            IPolygon triangleAdapter = new PolygonAdapter(triangle);
            IPolygon rectangleAdapter = new PolygonAdapter(rectangle);
            IPolygon circleAdapter = new PolygonAdapter(circle);

            triangleAdapter.DrawPolygon();
            rectangleAdapter.DrawPolygon();
            circleAdapter.DrawPolygon();
        }
    }


}