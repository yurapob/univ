using System;
using System.Text;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            ChristmasTree tree1 = new Basic();
            tree1 = new Yellow(tree1);
            tree1 = new Red(tree1);
            tree1 = new White(tree1);
            Console.Write("Назва: {0}\n", tree1.decoration);
            tree1.GetLights();
            
        }
    }
    abstract class ChristmasTree
    {
        public string decoration;
        public ChristmasTree(string n)
        {
            this.decoration = n;

        }

        public abstract void GetLights();

    }
    class Basic : ChristmasTree
    {
        public Basic() : base("Класична ялинка з:") { }
        public override void GetLights()
        {

        }
    }
    abstract class ChristmasDecorator : ChristmasTree
    {
        protected ChristmasTree tree;
        public ChristmasDecorator(string n, ChristmasTree tree) : base(n)
        {
            this.tree = tree;
        }
    }
    class Yellow : ChristmasDecorator
    {
        public Yellow(ChristmasTree p)
        : base(p.decoration + " золотими кульками,", p)
        { }
        public override void GetLights()
        {
            tree.GetLights();
            Console.WriteLine("свiтиться жовтими вогниками"); ;
        }
    }
    class Red : ChristmasDecorator
    {
        public Red(ChristmasTree p)
        : base(p.decoration + " червоними кульками,", p)
        { }
        public override void GetLights()
        {
            tree.GetLights();
            Console.WriteLine("свiтиться червоними вогниками"); ;
        }
    }
    class White : ChristmasDecorator
    {
        public White(ChristmasTree p)
        : base(p.decoration + " білими кульками", p)
        { }
        public override void GetLights()
        {
            tree.GetLights();
            Console.WriteLine("свiтиться білими вогниками"); ;
        }
    }



}
