using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Squirrel joey = new Squirrel("Joey");
            joey.speak();
            joey.identify();

            Bear blaine = new Bear("Blaine");
            blaine.speak();
            blaine.identify();

            List<Animal> animals = new List<Animal>();
            animals.Add(joey);
            animals.Add(blaine);
            animals.Add(new Starfish("starro"));
            animals.Add(new Starfish("barro"));

            Console.WriteLine($"Animal Roll Call with {animals.Count} animals.");
            animals.ForEach(animal =>
            {
                animal.speak();
                animal.identify();
            });

        }

    }


    class Animal
    {
        protected string myName;
        protected int legs;
        protected string animalType;
        public Animal(string name)
        {
            Console.WriteLine("AnimalConstructor");
            this.myName = name;
            this.animalType = "Unknown";
            this.legs = 2;
        }

        virtual public void speak()
        {
            Console.WriteLine("I am an abstract animal");
        }

        public void identify()
        {
            Console.WriteLine($"My name is {this.myName}, I am a {this.animalType} with {this.legs} legs.");
        }

    }

    class Squirrel : Animal
    {
        public Squirrel(string name) : base(name)
        {
            Console.WriteLine("Squirrel Constructor");
            this.myName = name;
        }

        override public void speak()
        {
            Console.WriteLine("SQUIRREL!");
        }
    }

    class Bear : Animal
    {
        public Bear(string name) : base(name)
        {
            this.legs = 4;
            this.animalType = "Hairy Bear";
        }

        override public void speak()
        {
            Console.WriteLine("rawr");
        }
    }


    class Starfish : Animal
    {
        public Starfish(string name) : base(name)
        {
            this.legs = Random.Shared.Next(8);
            this.animalType = $"Baby {this.legs} legged starfish";
        }

        override public void speak()
        {
            Console.WriteLine("'yo imma starfish'");
        }
    }

}
