using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week6day1VirtualPetPractice2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Animal dumbo = new Animal("elephant", 4, new List<string> { "bananas", "grass" }, true);
            //dumbo.Feed();
            //dumbo.AddFavoriteFood("apples");
            //dumbo.AddFavoriteFood("celery");
            //dumbo.ListFavoriteFood();
            ////dumbo.Feed();

            //dumbo.HungerLevel();
            //dumbo.Run();
            //dumbo.Walk();
            //dumbo.HungerLevel();

            //dumbo.Poop();
            //dumbo.Feed();
            //dumbo.HungerLevel();

            //Design your program
            //    Ensure that you have members
            //    for exercise/calories.

            // Number of minutes/hours of exercise determines number of calories burned.

            // Your Client Code: Set up menus for users to create new Animals; exercise, feed, etc.

            Console.WriteLine("***********************************");
            Console.WriteLine("Animal Manipulation Software Program");
            Console.WriteLine("***********************************");
            Console.WriteLine(" ");

            string startOver = "";
            string species = "";
            int legNum = 0;
            List<string> foods = new List<string>();
            bool hasATail = true;

            do
            {
                Console.WriteLine("Please choose from the following options by selecting a number (without the period): \n 1. Create New Animal \n 2. Feed the animal \n 3. Take the animal for a walk \n 4. Take the animal for a run");
                int userInput = int.Parse(Console.ReadLine());
                if (userInput == 1)
                {
                    Animal userPet = new Animal(species, legNum, hasATail);
                    Console.WriteLine("What kind of animal is this?");
                    species = Console.ReadLine();
                    Console.WriteLine("How many legs does your animal have?");
                    legNum = int.Parse(Console.ReadLine());
                    //Console.WriteLine("What is your animal's first favorite food?");
                    //foods[0] = Console.ReadLine();
                    //Console.WriteLine("What is your animal's second favorite food?");
                    //foods[1] = Console.ReadLine();
                    //Console.WriteLine("What is your animal's third favorite food?");
                    //foods[2] = Console.ReadLine();
                    Console.WriteLine("If your animal has a tail, enter T, if not, enter F");
                    string stringTail = Console.ReadLine();
                    if (stringTail == "T")
                    {
                        hasATail = true;
                    }
                    else if (stringTail == "F")
                    {
                        hasATail = false;
                    }
                    else
                    {
                        hasATail = false;
                    }
                }
                else if (userInput == 2)
                {
                    Animal undeclared = new Animal();
                    undeclared.Feed();
                }
                else if (userInput == 3)
                {
                    Animal secondUndeclared = new Animal();
                    secondUndeclared.Walk();
                }
                else if (userInput == 4)
                {
                    Animal thirdUndeclared = new Animal();
                    thirdUndeclared.Run();
                }
                else { Main(args); }

                Console.WriteLine("Do you want to start over? Enter Y for Yes or N for No");
                startOver = Console.ReadLine();

            } while (startOver == "Y");

            // Bonus - how to automate the animal getting hungry over time.
        }

        class Animal
        {
            //fields
            private int legs = 4; //default to 4, change later
            private string species = "The Animal";
            private List<string> favoriteFoods = new List<string>();
            private bool hasTail = true; //default to true
            private int hunger = 10;
            private const int maxFull = 10;

            //properties

            public int Legs
            {
                get { return this.legs; }
                set { this.legs = value; }
            }

            public string Species
            {
                get { return this.species; }
                set { this.species = value; }
            }

            public List<string> FavoriteFoods
            {
                get { return this.favoriteFoods; }
                set { this.favoriteFoods = value; }
            }

            public bool HasTail
            {
                get { return this.hasTail; }
                set { this.hasTail = value; }
            }

            public int Hunger
            {
                get { return this.hunger; }
                set
                {
                    if (value >= maxFull)
                    {
                        Console.WriteLine(this.Species + " is full.");

                    }
                    this.hunger = System.Math.Min(value, maxFull);
                }
            }


            //methods

            public bool Feed()
            {
                //get random favorite food because nothing was specified
                Random random = new Random();
                int randomNum = random.Next(this.FavoriteFoods.Count);
                Console.WriteLine(this.Species + " just ate " + this.FavoriteFoods.ElementAt(randomNum));
                return true;
            }

            //public int CheckFoodValue(string foodItem)
            //{
            //    //if implemented as a dictionary with food vals instead of as a list, then we could get points.
            //    return 1;
            //}

            internal void AddFavoriteFood(string foodItem)
            {
                this.FavoriteFoods.Add(foodItem);
            }

            public void ListFavoriteFood()
            {
                Console.WriteLine(this.Species + " favorite foods include:");
                foreach (string favFood in this.FavoriteFoods)
                {
                    Console.WriteLine(favFood);
                }
            }

            public void Run()
            {
                int calories = 200;
                int calConvert = calories / 100;

                if (this.Hunger >= 2)
                {
                    Console.WriteLine(this.Species + " just ran.");
                    this.Hunger = this.Hunger - calConvert;
                }
                if (this.Hunger < 2)
                {
                    Console.WriteLine(this.Species + " is hungry.");
                    Console.WriteLine(this.Species + " has no energy to run.");
                }
            }

            public void Walk()
            {
                int calories = 100;
                int calConvert = calories / 100;

                if (this.Hunger >= 1)
                {
                    Console.WriteLine(this.Species + " just walked.");
                    this.Hunger = this.Hunger - calConvert;
                }
                if (this.Hunger < 1)
                {
                    Console.WriteLine(this.Species + " is hungry.");
                    Console.WriteLine(this.Species + " has no energy to walk.");
                }
            }

            public void Poop()
            {
                if (this.Hunger > 1)
                {
                    this.Hunger = this.Hunger - 1;
                    Console.WriteLine(this.Species + " just pooped.");
                }
                else if (this.Hunger <= 0)
                {
                    Console.WriteLine(this.Species + "'s stomach is empty.");
                }
            }

            public void HungerLevel()
            {
                Console.WriteLine(this.Species + "'s Hunger Level: " + this.Hunger);
            }


            //constructors

            public Animal()
            {
                //default. Nothing really needed since we initialized our fields.
            }

            public Animal(string animalSpecies, int legs, bool hasTail)
            {
                this.Species = animalSpecies;
                this.Legs = legs;
                this.HasTail = hasTail;
            }

            public Animal(string animalSpecies, int legs, List<string> food, bool hasTail)
            {
                this.Species = animalSpecies;
                this.Legs = legs;
                this.FavoriteFoods = food;
                this.HasTail = hasTail;
            }
        }
    }
}