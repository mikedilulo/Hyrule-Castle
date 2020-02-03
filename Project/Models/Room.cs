using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Lit { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }



    //NOTE Constructor made for the Rooms
    public Room(string name, string description, bool lit)
    {
      Name = name;
      Description = description;
      Lit = lit;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();
    }
  }
}