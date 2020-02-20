using System;
using System.Collections.Generic;
using System.Linq;

namespace JurassicPark
{
    public class DinosaurTracker
    {
        // sets the default list <Dinosaur> for placing the values for each dinosaur in "Dinosaurs" container
        public List<Dinosaur> Dinosaurs { get; set; } = new List<Dinosaur>();

        // method to add a new dinosaur and store it's properties in "Dinosaurs"
        public void AddNewDinosaur(string name, string dietType, int weight, int enclosureNumber)
        {
            // variable that contains the properties of a single dinosaur
            var dinosaur = new Dinosaur
            {
                Name = name,
                DietType = dietType,
                Weight = weight,
                DateAcquired = DateTime.Now, 
                EnclosureNumber = enclosureNumber
            };
            // adds the new instance of a dinosaur into the "Dinosaurs" container
            Dinosaurs.Add(dinosaur);
        }
        // mtehod to remove dinosaur from the list of <Dinosaur>
        public void RemoveDino(string name)
        {
            // variable that looks into "Dinosaurs" container, searches within the list, using the variable "dinosaur"
            // to see the "Name" property to see if it is equal to user inputs "name" and returns the list of
            // string instances
            var dinoToRemove = Dinosaurs.Where(dinosaur => dinosaur.Name == name).ToList();
            // if the number of dinosaurs that the users wants to remove is higher than 1
            if (dinoToRemove.Count() > 1)
            {
                // console lists the multiple dinosaurs of the same name
                Console.WriteLine($"We found multiple of {name}, which of them do you want to remove?");
                // loop starts from 0, counts each matching dinosaur by name, and iterates until it has all of them
                for (int i = 0; i < dinoToRemove.Count; i++)
                {
                    // variable dino exists to apply the iterative loop to the dinosaurs that user wants to remove
                    var dino = dinoToRemove[i];
                    // console shows index number, what enclosure the dino is in, and the date it was acquired
                    Console.WriteLine($"{i + 1}: {dino.EnclosureNumber} at {dino.DateAcquired}.");
                }
                // variable that parses the users input from a string into an integer
                var index = int.Parse(Console.ReadLine());
                // removes the dinosaur and it's index according to user input
                Dinosaurs.Remove(dinoToRemove[index - 1]);
            }
            else
            {
                // removes the first instance of the dinosaur that the user inputs
                Dinosaurs.Remove(dinoToRemove.First());
            }
        }
        // method to transfer dinosaur from one enclosure to another
        public void TransferDino (string name)
        {
            Console.WriteLine("What enclosure would you like to transfer them to?");
            // variable to parse user input from a string to an integer
            var whereTo = int.Parse(Console.ReadLine());
            // looks into the list of Dinosaurs, finds the first instance of dinosaur that  
            // user inputs along with its enclosure number and assigns it to the variable above
            Dinosaurs.First(name => Dinosaurs.Contains(name)).EnclosureNumber = whereTo;
        }
        public void DisplayByDiet ()
        {
            // variable that looks into the list of Dinosaurs, counts through them, looks into the 
            // DietTypes of the dinosaurs contained in the list, checking if it matches their diet type
            // and returns the number of matches
            var dinoHerb = Dinosaurs.Count(herbivore => herbivore.DietType == "herbivore");
            var dinoCarn = Dinosaurs.Count(carnivore => carnivore.DietType == "carnivore");
            // console displays the number of matches for each variable
            Console.WriteLine($"There are {dinoHerb} herbivores and {dinoCarn} carnivores.");
        }
        
        public void ViewByWeight ()
        {
            // variable that looks into the list of Dinosaurs, finds the weight of each dinosaur contained
            // in the list, orders them from the top in descending order and takes the 3 in the list
            // and returns them
            var dinoByWeight = Dinosaurs.OrderByDescending(displayWeight => displayWeight.Weight).Take(3);
            foreach (var dino in dinoByWeight)
            {
            // console displays the dinosaurs names and the weights that variable returns
            Console.WriteLine($"\nThe {dino.Name} weight {dino.Weight}.)");
            }
        }
    }
}