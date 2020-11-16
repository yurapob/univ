using System;

namespace Facade
{
    // Mainapp test application 
    class MainApp
    {
        public static void Main()
        {
            Facade facade = new Facade();
            facade.MethodA();
            facade.MethodB();
            facade.MethodC();
            facade.MethodD();
            // Wait for user 
            Console.Read();
        }
    }


    // "Subsystem ClassA" 
    class SubSystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine(" SubSystemOne Method");
        }
    }

    // Subsystem ClassB" 
    class SubSystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine(" SubSystemTwo Method");
        }
    }


    // Subsystem ClassC" 
    class SubSystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine(" SubSystemThree Method");
        }
    }
    // Subsystem ClassD" 
    class SubSystemFour
    {
        public void MethodFour()
        {
            Console.WriteLine(" SubSystemFour Method");
        }
    }
    // Subsystem ClassE" 
    class SubSystemFive
    {
        public void MethodFive()
        {
            Console.WriteLine(" SubSystemFive Method");
        }
    }
    // Subsystem ClassD" 
    class SubSystemSix
    {
        public void MethodSix()
        {
            Console.WriteLine(" SubSystemsix Method");
        }
    }
    // "Facade" 
    class Facade
    {
        SubSystemOne one;
        SubSystemTwo two;
        SubSystemThree three;
        SubSystemFour four;
        SubSystemFive five;
        SubSystemSix six;

        public Facade()
        {
            one = new SubSystemOne();
            two = new SubSystemTwo();
            three = new SubSystemThree();
            four = new SubSystemFour();
            five = new SubSystemFive();
            six = new SubSystemSix();
        }

        public void MethodA()
        {
            Console.WriteLine("\nMethodA() ---- ");
            one.MethodOne();
            two.MethodTwo();
            four.MethodFour();
        }

        public void MethodB()
        {
            Console.WriteLine("\nMethodB() ---- ");
            two.MethodTwo();
            three.MethodThree();
        }
        public void MethodC()
        {
            Console.WriteLine("\nMethodC() ---- ");
            one.MethodOne();
            three.MethodThree();
            five.MethodFive();
        }
        public void MethodD()
        {
            Console.WriteLine("\nMethodD) ---- ");
            two.MethodTwo();
            four.MethodFour();
            six.MethodSix();
        }
    }
}
