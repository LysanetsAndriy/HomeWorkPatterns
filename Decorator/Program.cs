using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            var tree = new ChristmasTree();
            var ball = new ToyDecorator("ball");
            var star1 = new ToyDecorator("star1");
            var star2 = new ToyDecorator("star2");
            var garland = new GarlandDecorator();

            ball.SetComponent(tree);
            star1.SetComponent(ball);
            star2.SetComponent(star1);
            garland.SetComponent(star2);

            star2.Operation();
            garland.Operation();
        }
    }
    interface IComponent
    {
        public void Operation();
    }

    abstract class BaseDecorator : IComponent
    {
        protected IComponent wrap;

        public void SetComponent(IComponent component)
        {
            wrap = component;
        }

        public virtual void Operation()
        {
            wrap.Operation();
        }
    }
    class ChristmasTree : IComponent
    {
        void IComponent.Operation()
        {
            Console.WriteLine("Christmas tree");
        }
    }
    class ToyDecorator : BaseDecorator
    {
        private string toy;

        public ToyDecorator(string toy)
        {
            this.toy = toy;
        }
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine($"A {toy} on the tree");
        }
    }
    class GarlandDecorator : BaseDecorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("Garland on the tree");
            Shine();
        }

        private void Shine()
        {
            Console.WriteLine("The garland is shining");
        }
    }
}
