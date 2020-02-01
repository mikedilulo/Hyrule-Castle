using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();

    //NOTE this is the bool that will keep the game running
    private bool _adventuring = true;

    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
    public void Run()
    {
      Console.Clear();
      Console.WriteLine("What is your name brave adventurer?");
      string name = Console.ReadLine();
      _gameService.Setup(name);
      _gameService.PrintMessages();
      while (_adventuring)
      {
        Console.Clear();
        Print();
        GetUserInput();
      }

    }

    //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
    public void GetUserInput()
    {
      System.Console.WriteLine("What would you like to do?");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      //NOTE this will take the user input and parse it into a command and option.
      //IE: take silver key => command = "take" option = "silver key"

      switch (command)
      {
        case "quit":
          _adventuring = false;
          break;
        case "look":
          Console.Clear();
          _gameService.Look();
          break;
        case "go":
          Console.Clear();
          _gameService.Go(option);
          break;
        case "help":
          _gameService.Help();
          break;
        case "inventory":
          _gameService.Inventory();
          break;
        case "take":
          _gameService.TakeItem(option);
          break;

      }

    }

    //NOTE this should print your messages for the game.
    private void Print()
    {
      foreach (string message in _gameService.Messages)
      {
        System.Console.WriteLine(message);
      }
      _gameService.Messages.Clear();
    }

  }
}