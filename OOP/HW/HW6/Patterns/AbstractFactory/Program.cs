using System;
using System.Runtime.CompilerServices;

namespace Patterns
{
    class AbstractFactory
    {
        static void Main(string[] args)
        {
            ICarFactory carFactory = new ToyotaFactory();
            ClientFactory client1 = new ClientFactory(carFactory);
            client1.Run();
            Console.WriteLine("\n");
            carFactory = new FordFactory();
            ClientFactory client2 = new ClientFactory(carFactory);
            client2.Run();
            Console.WriteLine("\n");
            carFactory = new MersedesFactory();
            ClientFactory client3 = new ClientFactory(carFactory);
            client3.Run();

            Console.ReadKey();
        }
    }

    // AbstractProductA
    public abstract class Car
    {
        public abstract void Info();
        public void Interact(Engine engine, Wheel wheel)
        {
            Info();
            Console.WriteLine("Set Engine: ");
            engine.GetPower();
            Console.WriteLine("Set Wheel: ");
            wheel.GetWheel();
        }
    }

    // ConcreteProductA1
    public class Ford : Car
    {
        public override void Info()
        {
            Console.WriteLine("Ford");
        }
    }

    //ConcreteProductA2
    public class Toyota : Car
    {
        public override void Info()
        {
            Console.WriteLine("Toyota");
        }
    }
    //ConcreteProductA3
    public class Mersedes : Car
    {
        public override void Info()
        {
            Console.WriteLine("Mersedes");
        }
    }

    // AbstractProductB
    public abstract class Engine
    {
        public virtual void GetPower()
        {
        }
    }

    // ConcreteProductB1
    public class FordEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Ford Engine");
        }
    }

    //ConcreteProductB2
    public class ToyotaEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Toyota Engine");
        }
    }

    //ConcreteProductB3
    public class MersedesEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Mersedes Engine");
        }
    }
    // AbstractProductC
    public abstract class Wheel
    {
        public virtual void GetWheel()
        {
        }
    }
    // ConcreteProductC1
    public class FordWheel : Wheel
    {
        public override void GetWheel()
        {
            Console.WriteLine("Ford wheel");
        }
    }

    //ConcreteProductC2
    public class ToyotaWheel : Wheel
    {
        public override void GetWheel()
        {
            Console.WriteLine("Toyota wheel");
        }
    }

    //ConcreteProductC3
    public class MersedesWheel : Wheel
    {
        public override void GetWheel()
        {
            Console.WriteLine("Mersedes wheel");
        }
    }

    // AbstractFactory
    public interface ICarFactory
    {
        Car CreateCar();
        Engine CreateEngine();
        Wheel CreateWheel();
    }

    // ConcreteFactory1
    public class FordFactory : ICarFactory
    {
        // from CarFactory
        Car ICarFactory.CreateCar()
        {
            return new Ford();
        }

        Engine ICarFactory.CreateEngine()
        {
            return new FordEngine();
        }
        Wheel ICarFactory.CreateWheel()
        {
            return new FordWheel();
        }
    }

    // ConcreteFactory2
    public class ToyotaFactory : ICarFactory
    {
        // from CarFactory
        Car ICarFactory.CreateCar()
        {
            return new Toyota();
        }

        Engine ICarFactory.CreateEngine()
        {
            return new ToyotaEngine();
        }
        Wheel ICarFactory.CreateWheel()
        {
            return new ToyotaWheel();
        }
    }
    // ConcreteFactory3
    public class MersedesFactory : ICarFactory
    {
        // from CarFactory
        Car ICarFactory.CreateCar()
        {
            return new Mersedes();
        }

        Engine ICarFactory.CreateEngine()
        {
            return new MersedesEngine();
        }
        Wheel ICarFactory.CreateWheel()
        {
            return new MersedesWheel();
        }
    }

    public class ClientFactory
    {
        private Car car;
        private Engine engine;
        private Wheel wheel;

        public ClientFactory(ICarFactory factory)
        {
            //Абстрагування процесів інстанціювання
            car = factory.CreateCar();
            engine = factory.CreateEngine();
            wheel = factory.CreateWheel();

        }

        public void Run()
        {
            car.GetType();
            //Абстрагування варіантів використання
            car.Interact(engine, wheel);
        }
    }

}



