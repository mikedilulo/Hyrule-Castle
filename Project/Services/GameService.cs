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
      Messages.Add(new string("Type help to see a list of commands\n"));
    }
    public void Go(string direction)
    {
      if (_game.CurrentRoom.Exits.ContainsKey(direction))
      {
        _game.CurrentRoom = _game.CurrentRoom.Exits[direction];
      }
      Messages.Add(new string($"{_game.CurrentRoom.Description}\n"));
      Messages.Add(new string("Type help to view a list of commands\n"));
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
      Messages.Add(new string("-----Inventory-----"));
      // for (int item = 0; item < _game.CurrentPlayer.Inventory.Count; item++)
      // {
      //   Messages.Add(new string($"{item.ToString("name")}"));
      // }
      foreach (var item in _game.CurrentPlayer.Inventory)
      {
        Messages.Add(new string($"{item.Name}"));
      }
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
      _game.CurrentPlayer.Inventory.Clear();
      _game.CurrentRoom.Items.Clear();
      _game.Setup();
    }

    //NOTE Still confused on the setup. I know it takes in a playerName, but is there a better way to go about it?
    public void Setup(string playerName)
    {
      _game.CurrentPlayer.Name = playerName;
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      for (int i = 0; i < _game.CurrentRoom.Items.Count; i++)
      {
        if (_game.CurrentRoom.Items[i].Name == itemName)
        {
          Messages.Add(new string($"You have taken {_game.CurrentRoom.Items.Count} items"));
          _game.CurrentPlayer.Inventory.Add(_game.CurrentRoom.Items[0]);
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
      }
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      if (!_game.CurrentRoom.Lit)
      {
        Messages.Add(new string($"Using {itemName} lights up the room and you see a mysterious trap door to the north that will need to have some sort of key to open it. You're sword is beaming now, you are getting closer to finding the Princess!"));
        Messages.Add(new string("\nItems available:"));
        Messages.Add(new string("There are no items that you find that would be useful. You grab an apple thats sitting on the table and take a bite. While eating you hear the sounds of footsteps to the west.\n"));
      }
      if (_game.CurrentRoom.Lit)
      {
        Messages.Add(new string($"This room has no value for using a light"));
      }
    }
  }
}
