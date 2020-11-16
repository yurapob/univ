using System;

namespace Builder
{
    class Builder
    {
        class Pizza
        {
            string dough;
            string sauce;
            string topping;
            string vegetables;
            public Pizza() { }
            public void SetDough(string d) { dough = d; }
            public void SetSauce(string s) { sauce = s; }
            public void SetTopping(string t) { topping = t; }
            public void SetVegetables(string v) { vegetables = v; }
            public void Info()
            {
                Console.WriteLine("Dough: {0}\nSause: {1}\nTopping: {2}\nVegetables: {3}", dough, sauce, topping, vegetables);
            }
        }

        //Abstract Builder
        abstract class PizzaBuilder
        {
            protected Pizza pizza;
            public PizzaBuilder() { }
            public Pizza GetPizza() { return pizza; }
            public void CreateNewPizza() { pizza = new Pizza(); }

            public abstract void BuildDough();
            public abstract void BuildSauce();
            public abstract void BuildTopping();
            public abstract void BuildVegetables();
        }
        //Concrete Builder
        class HawaiianPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("cross"); }
            public override void BuildSauce() { pizza.SetSauce("mild"); }
            public override void BuildTopping() { pizza.SetTopping("ham+pineapple"); }
            public override void BuildVegetables() { pizza.SetVegetables("mushrooms"); }
        }
        //Concrete Builder
        class SpicyPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("pan baked"); }
            public override void BuildSauce() { pizza.SetSauce("hot"); }
            public override void BuildTopping() { pizza.SetTopping("pepparoni+salami"); }
            public override void BuildVegetables() { pizza.SetVegetables("pepper"); }
        }
        //Concrete Builder
        class MargaritaPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("pan baked"); }
            public override void BuildSauce() { pizza.SetSauce(" tomato sauce"); }
            public override void BuildTopping() { pizza.SetTopping("parmigiano+mozarella"); }
            public override void BuildVegetables() { pizza.SetVegetables("tomatoes"); }
        }
        /** "Director" */
        class Waiter
        {
            private PizzaBuilder pizzaBuilder;
            public void SetPizzaBuilder(PizzaBuilder pb) { pizzaBuilder = pb; }
            public Pizza GetPizza() { return pizzaBuilder.GetPizza(); }
            public void ConstructPizza()
            {
                pizzaBuilder.CreateNewPizza();
                pizzaBuilder.BuildDough();
                pizzaBuilder.BuildSauce();
                pizzaBuilder.BuildTopping();
                pizzaBuilder.BuildVegetables();
            }
        }
        /** A customer ordering a pizza. */
        class BuilderExample
        {
            public static void Main(String[] args)
            {
                Waiter waiter = new Waiter();
                PizzaBuilder hawaiianPizzaBuilder = new HawaiianPizzaBuilder();
                PizzaBuilder spicyPizzaBuilder = new SpicyPizzaBuilder();
                PizzaBuilder margaritaPizzaBuilder = new MargaritaPizzaBuilder();
                Console.WriteLine("Spicy\n");
                waiter.SetPizzaBuilder(spicyPizzaBuilder);
                waiter.ConstructPizza();
                Pizza pizza = waiter.GetPizza();
                pizza.Info();
                Console.WriteLine("\nHawaiian\n");
                waiter.SetPizzaBuilder(hawaiianPizzaBuilder);
                waiter.ConstructPizza();
                pizza = waiter.GetPizza();
                pizza.Info();
                Console.WriteLine("\nMargarita\n");
                waiter.SetPizzaBuilder(margaritaPizzaBuilder);
                waiter.ConstructPizza();
                pizza = waiter.GetPizza();
                pizza.Info();

                Console.ReadKey();
            }
        }

    }
}
