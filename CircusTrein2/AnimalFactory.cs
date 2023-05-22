using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrein2
{
    public class AnimalFactory
    {
        public static List<Animal> RandomAnimals(int min, int max)
        {
            Random r = new Random();
            List<Animal> animals = new List<Animal>();

            for(int i = 0; i < r.Next(min, max); i++) {
                animals.Add(RandomAnimal());
            }

            return animals;
        }

        public static Animal RandomAnimal()
        {
            Random r = new Random();
            Animal animal = new Animal();

            int i = r.Next(0, 2);
            switch (i)
            {
                case 0:
                    animal.carnivorous = false;
                    break;
                case 1:
                    animal.carnivorous = true;
                    break;
            }

            int j = r.Next(0, 3);
            switch(j)
            {
                case 0:
                    animal.weight = 1; break;
                case 1:
                    animal.weight = 3; break;
                case 2:
                    animal.weight = 5; break;
            }

            return animal;
        }

        public static Animal SmallHerbivore { get { return new Animal(1, false); } }
        public static Animal MediumHerbivore { get { return new Animal(3, false); } }
        public static Animal LargeHerbivore { get { return new Animal(5, false); } }


        public static Animal SmallCarnivore { get { return new Animal(1, true); } }
        public static Animal MediuCarnivore { get { return new Animal(3, true); } }
        public static Animal LargeCarnivore { get { return new Animal(5, true); } }
    }
}
