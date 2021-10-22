using System;

namespace AnimalKingdom.GodObject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public sealed class Animal
    {
        private readonly string type;
        
        private Tuple<int, int> position;

        public Animal(string type)
        {
            this.type = type;
            this.position = new Tuple<int, int>(0, 0);
        }

        public Tuple<int, int> Walk(int direction)
        {
            if (this.type == "snake")
            {
                throw new NotSupportedException();
            }
            else if (this.type == "dog")
            {
                this.position = new Tuple<int, int>(
                    this.position.Item1,
                    this.position.Item2 + 2); // dogs walk faster than birds
                return this.position;
            }
            else if (this.type == "bird")
            {
                this.position = new Tuple<int, int>(
                    this.position.Item1,
                    this.position.Item2 + 1); // birds walk slower than dogs
                return this.position;
            }
            else if (this.type == "fish")
            {
                throw new NotSupportedException();
            }

            throw new NotSupportedException();
        }

        public Tuple<int, int> Swim(int direction)
        {
            if (this.type == "snake")
            {
                throw new NotSupportedException();
            }
            else if (this.type == "dog")
            {
                this.position = new Tuple<int, int>(
                    this.position.Item1,
                    this.position.Item2 + 1); // dogs swim slower than fish
                return this.position;
            }
            else if (this.type == "bird")
            {
                throw new NotSupportedException();
            }
            else if (this.type == "fish")
            {
                this.position = new Tuple<int, int>(
                    this.position.Item1,
                    this.position.Item2 + 3); // fish swim really fast!
                return this.position;
            }

            throw new NotSupportedException();
        }

        public void Eat(Animal animalToEat)
        {
            throw new NotImplementedException();
        }
    }
}
