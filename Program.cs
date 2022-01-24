using System;
using System.IO;

namespace COM
{
    public abstract class Animal{
        protected string Name { get; set; }
        protected int Thirst { get; set; }
        protected int Hunger { get; set; }
        protected int Comfort { get; set; }
        protected int Energy { get; set; }
        public int getEnergy(){ return Energy; }
        public Animal()
        {
            Name = "unknown";
            Thirst = 25;
            Hunger = 25;
            Comfort = 25;
            Energy = 100;
            Console.WriteLine("You have a pet!");
        }
    
        public Animal(string name)
        {
            Name = name;
            Thirst = 25;
            Hunger = 25;
            Comfort = 25;
            Energy = 100;
        }
        public void Status(){
            System.Console.WriteLine("Status: hunger="+Hunger+", thirst="+Thirst+", comfort="+Comfort+", energy="+Energy );
        }
        public void Feed(){
            string? input;
            int result = 0;
            do
            {
                System.Console.Write("Amount(1-3): ");
                input = Console.ReadLine();
                int.TryParse(input, out result);
                
            } while (input != null && input.Length == 1 && (result<1 || result>3));
            if (input != null && input.Length == 1)
            {
                //int.TryParse(input, out result);
                if (result == 1)
                {
                    System.Console.WriteLine("It was too little.");
                    Hunger += 15;
                    if (Hunger > 100)
                    {
                        // This is the max.
                        Hunger = 100;
                    }
                    Comfort -= 20;
                    if (Comfort < 0)
                    {
                        Comfort = 0;
                    }
                }
                else if (result == 2)
                {
                    Hunger += 25;
                    if (Hunger > 100)
                    {
                        // This is the max.
                        Hunger = 100;
                    }
                    Comfort += 10;
                    if (Comfort >100 )
                    {
                        Comfort = 100;
                    }
                }
                else if (result == 3)
                {
                    System.Console.WriteLine("It was too much.");
                    Hunger += 35;
                    if (Hunger > 100)
                    {
                        // This is the max.
                        Hunger = 100;
                    }
                    Comfort -= 10;
                    if (Comfort < 0)
                    {
                        Comfort = 0;
                    }
                }
            }
            
        }
        public void Drink(){
            Thirst += 25;
            if (Thirst > 100)
            {
                // This is the max.
                Thirst = 100;
            }
        }
        virtual public void Pet(){
            Comfort += 15;
            if (Comfort > 100)
            {
                // This is the max.
                Comfort = 100;
            }
        }
        virtual public void Play(bool walking){
            
            if (walking)
            {
                Comfort += 35;
                if (Comfort > 100)
                {
                    // This is the max.
                    Comfort = 100;
                }
            }
            else
            {
                Comfort += 15;
                if (Comfort > 100)
                {
                    // This is the max.
                    Comfort = 100;
                }
                Energy -= 40;
                if (Energy < 0)
                {
                    // This is the max.
                    Energy = 0;
                }
            }
        }
        virtual public void Sleep(){
            Energy += 40;
            if (Energy > 100)
            {
                // This is the max.
                Energy = 100;
            }
            Hunger -= 40;
            if (Hunger < 0)
                {
                    // This is the min.
                    Hunger = 0;
                }
            Thirst -= 40;
            if (Thirst < 0)
                {
                    // This is the min.
                    Thirst = 0;
                }
            Comfort -= 40;
            if (Comfort < 0)
                {
                    // This is the min.
                    Comfort = 0;
                }
        }
        public abstract void Walk();
    }
    public class Dog : Animal{
        public Dog() : base() {}
        public Dog(string name) : base(name) {
            System.Console.WriteLine("\nYou have a dog! Take care of "+name+'!');
        }
        public override void Walk(){
            Comfort += 15;
            if (Comfort > 100)
            {
                // This is the max.
                Comfort = 100;
            }
            Energy -= 60;
            if (Energy < 0)
            {
                // This is the max.
                Energy = 0;
            }
        }

    }
    public class Cat : Animal{
        public Cat() : base() {}
        public Cat(string name) : base(name) {
            System.Console.WriteLine("\nYou have a cat! Take care of "+name+'!');
        }
        public override void Pet(){
            Random r = new Random();
            int num = r.Next(1, 101);
            if (num <= 20)
            {
                Comfort -= 10;
                if (Comfort < 0)
                {
                    // This is the min.
                    Comfort = 0;
                }
                System.Console.WriteLine("The cat does not had the mood for a pet. It bites.");
                Energy -= 10;
                if (Energy < 0)
                {
                    // This is the max.
                    Energy = 0;
                }
            }
            else
            {
                Comfort += 15;
                if (Comfort > 100)
                {
                    // This is the min.
                    Comfort = 100;
                }
            }
        }
        public override void Walk(){}
    }
    internal class Program
    {
        public static Animal NameIt(string inp){
            string? name = "";
            System.Console.Write("Name your new pet: ");
            do
            {
                name = System.Console.ReadLine();
            } while (name == null);

            if (inp[0] == 'd')
            {
                return new Dog(name);
            }
            else
            {
                return new Cat(name);
            }
        }
        static void Main(string[] args)
        {
            Animal animal;
            string? input = "";
            do
            {
                System.Console.WriteLine("Select the type of animal you would like to have! Enter 'd' for Dog or 'c' for Cat!");
                input = Console.ReadLine();
                if (input != null && input[0] == 'd' && input.Length == 1)
                {
                    animal = NameIt(input);
                    break;
                }
                else if (input != null && input[0] == 'c' && input.Length == 1)
                {
                    animal = NameIt(input);
                    break;
                }
            } while (true);
            
            if (animal.GetType() == typeof(COM.Dog))
            {
                System.Console.WriteLine("Options: [0]Exit, [1]Feed, [2]Drink, [3]Pet, [4]Play, [5]Sleep, [6]Walk");
            }
            else if (animal.GetType() == typeof(COM.Cat))
            {
                System.Console.WriteLine("Options: [0]Exit, [1]Feed, [2]Drink, [3]Pet, [4]Play, [5]Sleep");
            }

            do
            {
                animal.Status();
                input = Console.ReadLine();
                if (input != null && input.Length == 1 )
                {
                    int result = 0;
                    int.TryParse(input, out result);
                    if (result == 0)
                    {
                        break;
                    }
                    else if (result == 1)
                    {
                        animal.Feed();
                    }
                    else if (result == 2)
                    {
                        animal.Drink();
                    }
                    else if (result == 3)
                    {
                        animal.Pet();
                    }
                    else if (result == 4)
                    {
                        if (animal.getEnergy() > 0)
                        {
                            animal.Play(false);
                        }
                        else
                        {
                            System.Console.WriteLine("Too tired.");
                        }
                    }
                    else if (result == 5)
                    {
                        animal.Sleep();
                    }
                    else if (result == 6 && animal.GetType() == typeof(COM.Dog))
                    {
                        if (animal.getEnergy() > 0)
                        {
                            //int result = 0;
                            animal.Walk();
                            do
                            {
                                System.Console.WriteLine("Options: [1]Go home, [2]Play");
                                input = Console.ReadLine();
                                int.TryParse(input, out result);
                                
                            } while (input != null && input.Length == 1 && (result<1 || result>2));
                            if (input != null && input.Length == 1 && result == 2)
                            {
                                animal.Play(true);
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Too tired.");
                        }
                    }
                }
            } while (input != null && input.Length == 1 && input[0] != '0');
            
            System.Console.WriteLine("Press any key to exit..");
            System.Console.ReadKey();
        }
    }
}