using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }

    public bool Light { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }



    //NOTE Constructor made for the Rooms
    //TODO Need to add a locked boolean and implement that into the game
    public Room(string name, string description, bool light)
    {
      Name = name;
      Description = description;
      Light = light;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();
    }
  }
}