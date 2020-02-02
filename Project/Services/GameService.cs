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

      foreach (var exit in _game.CurrentRoom.Exits)
      {
        Messages.Add(new string($"{exit.Key}"));
      }
      if (_game.CurrentRoom.Exits.Count == 0)
      {
        Messages.Add(new string($"There are no exits in this room \n"));
      }

      Messages.Add(new string($"\nAvailable Items:"));
      foreach (var items in _game.CurrentRoom.Items)
      {
        Messages.Add(new string($"{items.Name}\n"));
      }
      if (_game.CurrentRoom.Items.Count == 0)
        Messages.Add(new string($"There are no items in this room\n"));
    }
    public void Help()
    {
      Messages.Add(new string("Type quit and hit enter to quit the console application"));
      Messages.Add(new string("Type go and <direction> to travel into the next room"));
      Messages.Add(new string("Type take and <item> to take an item from a room"));
      Messages.Add(new string("Type use and <item to use an item from a room"));
      Messages.Add(new string("Type look to get a description of the room you are currently in"));
      Messages.Add(new string("Type reset to reset the game back to the beginning"));
      Messages.Add(new string("Type inventory to view a list of items in your inventory\n"));
    }

    public void Inventory()
    {

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
      if (_game.CurrentRoom.Items[0].Name == itemName)
      {
        Messages.Add(new string($"You have taken {_game.CurrentRoom.Items.Count} items"));
        _game.CurrentRoom.Items.Clear();
        Messages.Add(new string($"{_game.CurrentRoom.Description}"));
        Messages.Add(new string("\nAvailable Exits"));
        foreach (var exit in _game.CurrentRoom.Exits)
        {
          Messages.Add(new string($"{exit.Key}"));
        }
        if (_game.CurrentRoom.Exits.Count == 0)
        {
          Messages.Add(new string($"There are no exits in this room \n"));
        }
        return;
      }
      _game.CurrentPlayer.Inventory.Add(_game.CurrentRoom.Items[0]);


    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {

    }
  }
}
