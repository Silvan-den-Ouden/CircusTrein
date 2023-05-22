using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrein2
{
    public class Wagon
    {
        public int maxWeight = 10;
        public List<Animal> passengers = new();

        ///
        public List<Wagon> wagons = new();
        
        public Wagon()
        {
            wagons.Add(this);
        }
        ///

        public Wagon(Animal animal)
        {
            passengers.Add(animal);
        }

        public int getWeight()
        {
            int weight = 0;
            foreach(Animal animal in passengers)
            {
                weight += animal.weight;
            }
            return weight;
        }

        public int getSmallestAnimal()
        {
            int smallestAnimal = 10;
            foreach(Animal animal in passengers)
            {
                if(animal.weight < smallestAnimal)
                {
                    smallestAnimal = animal.weight;
                }
            }
            return smallestAnimal;
        }

        public int getBiggestCarnivore()
        {
            int biggestCarnivore = 0;
            foreach(Animal animal in passengers)
            {
                if(animal.weight > biggestCarnivore && animal.carnivorous)
                {
                    biggestCarnivore = animal.weight;
                }
            }
            return biggestCarnivore;
        }
    }
}



