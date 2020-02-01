using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }

    public List<string> Messages { get; set; }
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }

    public void PrintMessages()
    {
      Messages.Add(new string($"{_game.CurrentRoom.Description}\n"));
    }
    public void Go(string direction)
    {
      if (_game.CurrentRoom.Exits.ContainsKey(direction))
      {
        _game.CurrentRoom = _game.CurrentRoom.Exits[direction];
      }
      Messages.Add(new string($"{_game.CurrentRoom.Description}\n"));
      Messages.Add(new string("The Following Exits:"));
      //   for (int exit = 0; exit < _game.CurrentRoom.Exits.Count; exit++)
      //   {
      //     Messages.Add(new string($"{exit.ToString(direction)}"));
      //   }
      //   Messages.Add(new string($"There are no exits in this room\n"));

      foreach (var exit in _game.CurrentRoom.Exits)
      {
        Messages.Add(new string($"{exit.Key}"));
      }
      Messages.Add(new string($"There are no exits in this room"));

      Messages.Add(new string($"Available Items:"));
      foreach (var items in _game.CurrentRoom.Items)
      {
        Messages.Add(new string($"{items.Name}"));
      }
      Messages.Add(new string($"There are no items in this room\n"));
    }
    public void Help()
    {
      throw new System.NotImplementedException();
    }

    public void Inventory()
    {
      throw new System.NotImplementedException();
    }

    public void Look()
    {
      Messages.Add(new string($"{_game.CurrentRoom.Description}"));
    }

    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      throw new System.NotImplementedException();
    }

    //NOTE Still confused on the setup. I know it takes in a playerName, but is there a better way to go about it?
    public void Setup(string playerName)
    {
      playerName = "Link";
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      throw new System.NotImplementedException();
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      throw new System.NotImplementedException();
    }
  }
}
