using System;
using System.Collections.Generic;
using System.Linq;

namespace JurassicPark
{
    public class DinosaurTracker
    {
        public List<Dinosaur> Dinosaurs { get; set; } = new List<Dinosaur>();

        public void AddNewDinosaur(string name, string dietType, int weight, int enclosureNumber)
        {
            var dinosaur = new Dinosaur
            {
                Name = name,
                DietType = dietType,
                Weight = weight,
                DateAcquired = DateTime.Now, 
                EnclosureNumber = enclosureNumber
            };

            Dinosaurs.Add(dinosaur);
        }
        public void RemoveDino(string name)
        {
            var dinoToRemove = Dinosaurs.Where(dinosaur => dinosaur.Name == name).ToList();
            if (dinoToRemove.Count() > 1)
            {
                Console.WriteLine($"We found multiple of {name}, which of them do you want to remove?");
                for (int i = 0; i < dinoToRemove.Count; i++)
                {
                    var dino = dinoToRemove[i];
                    Console.WriteLine($"{i + 1}: {dino.EnclosureNumber} at {dino.DateAcquired}.");
                }

                var index = int.Parse(Console.ReadLine());
                Dinosaurs.Remove(dinoToRemove[index - 1]);
            }
            else
            {
                Dinosaurs.Remove(dinoToRemove.First());
            }
        }
        public void TransferDino (string name)
        {
            var dinoToMove = Dinosaurs.IndexOf(Dinosaurs.First(dinosaur => dinosaur.Name == name));
            Console.WriteLine("What enclosure would you like to transfer them to?");
            var whereTo = int.Parse(Console.ReadLine());
            Dinosaurs[dinoToMove].EnclosureNumber = whereTo;
        }
        public void DisplayByDiet ()
        {
           var dinoHerb = Dinosaurs.Count(herbivore => herbivore.DietType == "herbivore");
           var dinoCarn = Dinosaurs.Count(carnivore => carnivore.DietType == "carnivore");     
           Console.WriteLine($"There are {dinoHerb} herbivores and {dinoCarn} carnivores.");
        }
        
        public void ViewByWeight ()
        {
            var dinoByWeight = (Dinosaurs.OrderByDescending(displayWeight => displayWeight.Weight).Take(3));
            foreach (var dino in dinoByWeight)
            {
            Console.WriteLine($"\nThe {dino.Name} weight {dino.Weight}.)");
            }
        }
    }
}