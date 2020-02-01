using System;
using ConsoleAdventure.Project;
using ConsoleAdventure.Project.Controllers;

namespace ConsoleAdventure
{
  public class Program
  {
    public static void Main(string[] args)
    {
      //NOTE This will ultimately run the program.
      GameController gc = new GameController();
      gc.Run();
    }
  }
}
