using System;

namespace RefactoringGuru.DesignPatterns.TemplateMethod.Conceptual
{
    // The Abstract Class defines a template method that contains a skeleton of
    // some algorithm, composed of calls to (usually) abstract primitive
    // operations.
    //
    // Concrete subclasses should implement these operations, but leave the
    // template method itself intact.
    abstract class AbstractClass
    {
        // The template method defines the skeleton of an algorithm.
        public void TemplateMethod()
        {
            this.start_work();
            this.heat_water();
            this.drink_dilution();
            this.add_suggar();
            this.pour_drink();
        }

        protected void start_work()
        {
            Console.WriteLine("\n START");
        }
        protected void heat_water()
        {
            Console.WriteLine("вода нагрівається");
        }

        protected void pour_drink()
        {
            Console.WriteLine("напій налито");
        }

        protected abstract void drink_dilution();

        protected virtual void add_suggar() { }

    }

    class Work_Drink1 : AbstractClass
    {
        protected override void drink_dilution()
        {
            Console.WriteLine("напій розведено з водою");
        }
        protected override void add_suggar()
        {
            Console.WriteLine("цукор додано");
        }

}

    class Work_Drink2 : AbstractClass
    {
        protected override void drink_dilution()
        {
            Console.WriteLine("напій розведено з водою");
        }
    }

    class Client
    {

        public static void ClientCode(AbstractClass abstractClass)
        {
            abstractClass.TemplateMethod();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Процес роботи чаю : нагріти воду , розвести воду і каву , додати цукор ,  вилити напій в чашку ");
           
            Client.ClientCode(new Work_Drink1());

            Console.Write("\n");
            string drink_name = "coffee";
            Console.WriteLine($"Процес роботи {drink_name} : нагріти воду , розвести воду і чай , додати цукор ,  вилити напій в чашку "); 

            Client.ClientCode(new Work_Drink2());

        }
    }
}