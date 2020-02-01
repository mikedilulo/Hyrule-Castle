using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {
    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    //NOTE Make yo rooms here...
    public void Setup()
    {
      Room approachingCastle = new Room("Approaching-Castle", "Brave Adventurer, through the years of all your trials and errors, you have always been the chosen one. This land and castle have been corrupt for the last 100 years that you have been in a slumber. This castle has called to you many times in your nightmares, a voice, a female voice has reached out for help. All along since you were a child, this destiny was in your hands. Without the help of you brave adventurer, humanity will be doomed forever in the dark demise of Ganon. Approaching the castle you realize the moment you step within the castle walls, you will not able to turn back and will be faced with many trials. The King and Princess are counting on you.");

      CurrentRoom = approachingCastle;
    }

    //Note running Setup

    public Game()
    {
      Setup();
    }
  }
}