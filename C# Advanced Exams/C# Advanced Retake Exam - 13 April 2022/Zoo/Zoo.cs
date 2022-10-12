using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        private List<Animal> animals;
        public Zoo(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            animals = new List<Animal>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Animal> Animals { get { return this.animals; } set { ;} }
        public string AddAnimal(Animal animal)
        {
            string message = string.Empty;
            if (string.IsNullOrEmpty(animal.Species))
            {
                message = "Invalid animal species.";
            }
            else if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                message = "Invalid animal diet.";
            }
            else if (this.Capacity - this.Animals.Count > 0)
            {
                this.Animals.Add(animal);
                message = $"Successfully added {animal.Species} to the zoo.";
            }
            else
            {
                message = "The zoo is full.";
            }
            return message;
        }
        public int RemoveAnimals(string species)
        {
            int countRemovedAnimals = 0;
            for (int i = 0; i < this.Animals.Count; i++)
            {
                Animal currentAnimal = Animals[i];
                if (currentAnimal.Species == species)
                {
                    this.Animals.Remove(currentAnimal);
                    i--;
                    countRemovedAnimals++;
                }
            }
            return countRemovedAnimals;
        }
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> animals = new List<Animal>();
            animals = this.Animals.Where(x => x.Diet == diet).ToList();
            return animals;
        }
        public Animal GetAnimalByWeight(double weight)
        {
            Animal animalToReturn = this.Animals.FirstOrDefault(x => x.Weight == weight);
            return animalToReturn;
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            string message = string.Empty;
            List<Animal> animals = this.Animals.Where(x => x.Length>=minimumLength&& x.Length<=maximumLength).ToList();
            message = $"There are {animals.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
            return message;
        }
    }
}
