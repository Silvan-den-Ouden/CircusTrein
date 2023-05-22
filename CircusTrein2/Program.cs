// See https://aka.ms/new-console-template for more information
using System.Timers;
using CircusTrein2;

Wagon wagon = new Wagon();

Animal bunny = new(1, false);
Animal donkey = new(3, false);
Animal elephant = new(5, false);

Animal cat = new(1, true);
Animal lion = new(3, true);
Animal trex = new(5, true);

List<Animal> test_case_1 = new() { elephant, elephant, donkey, donkey, donkey, cat };
List<Animal> test_case_2 = new() { elephant, donkey, donkey, bunny, bunny, bunny, bunny, bunny, cat };
List<Animal> test_case_3 = new() { elephant, trex, donkey, lion, bunny, cat };
List<Animal> test_case_4 = new() { elephant, trex, donkey, donkey, donkey, donkey, donkey, lion, bunny, cat, cat };
List<Animal> test_case_5 = new() { elephant, elephant, donkey, bunny, cat };
List<Animal> test_case_6 = new() { cat, donkey, donkey, elephant, elephant, elephant, cat, cat };
List<Animal> test_case_7 = new() { elephant, elephant, elephant, elephant, elephant, elephant, trex, trex, trex, donkey, donkey, donkey, donkey, donkey,  lion, lion, lion, cat, cat, cat, cat, cat, cat, cat};

List<Animal> animals = test_case_6;

Random rand = new();
animals = animals.OrderBy(_ => rand.Next()).ToList();

List<Animal> sort(List<Animal> animals)
{
    List<Animal> temp = new();
    List<Animal> small = new();
    List<Animal> medium = new();
    List<Animal> large = new();
    List<Animal> sorted = new();

    for (int i = 0; i < animals.Count; i++)
    {
        if (animals[i].carnivorous)
        {
            temp.Add(animals[i]);
            animals.RemoveAt(i);
            i--;
        } else
        if (animals[i].weight == 5)
        {
            large.Add(animals[i]);
        } else
        if (animals[i].weight == 3)
        {
            medium.Add(animals[i]);
        } else
        if (animals[i].weight == 1)
        {
            small.Add(animals[i]);
        }
    }

    sorted.AddRange(large);
    sorted.AddRange(medium);
    sorted.AddRange(small);
    temp.AddRange(sorted);
   
    return temp;
}

animals = sort(animals);

for (int i = 0; i < animals.Count; i++)
{
    bool toegevoegd = false;
    for (int j = 0; j < wagon.wagons.Count; j++)
    {
        if (toegevoegd)
        {
            break;
        }

        if (animals[i].carnivorous && animals[i].weight > wagon.wagons[j].getSmallestAnimal())
        {
            break;
        }

        if (animals[i].weight + wagon.wagons[j].getWeight() <= wagon.maxWeight)
        {
            if (animals[i].weight > wagon.wagons[j].getBiggestCarnivore())
            {
                wagon.wagons[j].passengers.Add(animals[i]);
                toegevoegd = true;
            }
        }
    }
    if (!toegevoegd)
    {
        wagon.wagons.Add(new Wagon(animals[i]));
    }
}

//UI
foreach (Wagon wag in wagon.wagons)
{
    Console.Write(wag.getWeight() + " ");
}
Console.WriteLine();


for (int i = 0; i < wagon.wagons.Count; i++)
{
    for (int j = 0; j < wagon.wagons[i].passengers.Count; j++)
    {
        Console.Write(wagon.wagons[i].passengers[j].weight + "" + wagon.wagons[i].passengers[j].carnivorous + " ");
    }
    Console.WriteLine();
}
Console.WriteLine(wagon.wagons.Count);

