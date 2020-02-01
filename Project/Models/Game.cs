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
      Room approachingCastle = new Room("Approaching-Castle", "Brave Adventurer, through the years of all your trials and errors, you have always been the chosen one. This land and castle have been corrupt for the last 100 years that you have been in a slumber. This castle has called to you many times in your nightmares, a voice, a female voice has reached out for help. All along since you were a child, this destiny was in your hands. Without the help of you brave adventurer, humanity will be doomed forever in the dark demise of Ganon. Approaching the castle you realize the moment you step within the castle walls, you will not able to turn back and will be faced with many trials. The King and Princess are counting on you. Approaching the castle with only your sword and shield, you are faced with the toughest of all decisions. Place your life on the line to help humanity or step away. Facing East you see the castle walls, behind you to the west is the village from which you came.");

      Room runningAway = new Room("Run-Away", "You have decided that this adventure was too much for you to handle. You have let down the King, the Princess, and all of Humanity. When you turned around and tried to ride away on Epona, an arrow was shot into the leg of Epona, dropping your horse and you to the ground. When you fell off your mighty horse, your head struck a rock. A nearby Bokoblin has snatched you and took you back to his lair. It was only here your fate was met, you were skinned alive, tortured and killed. The game is over. Maybe next time you might want to consider what can happen to humanity when you decide to make a wrong decision.");


      //NOTE establishes the current Room the character is in.
      CurrentRoom = approachingCastle;

      //TODO Need to establish items in the rooms.

      //NOTE establishes the relationships between the rooms
      approachingCastle.Exits.Add("west", runningAway);
    }








    //Note running Setup
    public Game()
    {
      Setup();
    }
  }
}