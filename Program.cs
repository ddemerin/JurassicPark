using System;
using System.Collections.Generic;

namespace JurassicPark
{
  class Program
  {
    static void Main(string[] args)
    {

      var tracker = new DinosaurTracker();
      var cleverGirl = true;
        
      while (cleverGirl)
      {  
      Console.WriteLine("\n\nWelcome to Jurassic Park Dinosaur Tracker!");
      Console.WriteLine("\n\nWhat would you like to do?");
      Console.WriteLine("\n(VIEW), (ADD), (REMOVE), (TRANSFER), or (QUIT)");
      var input = Console.ReadLine().ToLower();

      if (input == "add")
      {
        Console.Clear();
        Console.WriteLine("What is the name of the dinosaur you saw?");
        var name = Console.ReadLine().ToLower();
        Console.WriteLine("What is the diet type of the dinosaur: Herbivore or Carnivore?");
        var dietType = Console.ReadLine().ToLower();
        Console.WriteLine("What was the weight of the dinosaur?");
        var weight = int.Parse(Console.ReadLine().ToLower());
        Console.WriteLine("Which enclosure would you like to house the dinosaur?");
        var enclosureNumber = int.Parse(Console.ReadLine().ToLower());

        tracker.AddNewDinosaur(name, dietType, weight, enclosureNumber);
      }
      else if (input == "view")
      {
        Console.Clear();
        Console.WriteLine("What would you like to view?");
        Console.WriteLine("(ALL), (THREE) Heaviest, or (DIET) Summary?");
        input = Console.ReadLine().ToLower();
        
        if (input == "all")
        {
          Console.WriteLine("\n\nHere are all the dinosaurs in the park:");
          foreach (var list in tracker.Dinosaurs)
          {
          Console.WriteLine($"\nOn {list.DateAcquired}, you caught a {list.Name}. It is a {list.DietType}, weighs {list.Weight} and is found in enclosure number {list.EnclosureNumber}.");
          }
        }
        else if (input == "three")
        {
          // Console.Clear();
          Console.WriteLine("Here are three heaviest dinosaurs in the park:");
          tracker.ViewByWeight();
        }
          else if (input == "diet")
        {
          // Console.Clear();
          tracker.DisplayByDiet();
          }
        }
        else if (input == "remove")
        {
          Console.Clear();
          Console.WriteLine("\n\nHere are all the dinosaurs in the park:");
          foreach (var list in tracker.Dinosaurs)
          {
          Console.WriteLine($"\n{list.Name} ({list.DietType}, weighs {list.Weight} and is found in enclosure number {list.EnclosureNumber})");
          }
          Console.WriteLine("Which dinosaur do you want to remove?");
          var dino = Console.ReadLine().ToLower();
          tracker.RemoveDino(dino);
        }
        else if (input == "transfer")
        {
          Console.Clear();
          Console.WriteLine("\n\nHere are all the dinosaurs in the park:");
          foreach (var list in tracker.Dinosaurs)
          {
          Console.WriteLine($"\nOn {list.DateAcquired}, you caught a {list.Name}. It is a {list.DietType}, weighs {list.Weight} and is found in enclosure number {list.EnclosureNumber}.");
          }
          Console.WriteLine("Which dinosaur would you like to transfer?");
          var transfer = Console.ReadLine().ToLower();
          tracker.TransferDino(transfer);
        }
        if (input == "quit")
        {
          cleverGirl = false;
        }
      }
    }
  }
}
