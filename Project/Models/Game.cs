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
      Room approachingCastle = new Room("Approaching-Castle", "Brave Adventurer, through the years of all your trials and errors, you have always been the chosen one. This land and castle have been corrupt for the last 100 years that you have been in a slumber. This castle has called to you many times in your nightmares, a voice, a female voice has reached out for help. All along since you were a child, this destiny was in your hands. Without the help of you brave adventurer, humanity will be doomed forever in the dark demise of Ganon. Approaching the castle you realize the moment you step within the castle walls, you will not able to turn back and will be faced with many trials. The King and Princess are counting on you. Approaching the castle with only your sword and shield, you are faced with the toughest of all decisions. Place your life on the line to help humanity or step away. Facing East you see the castle walls, behind you to the west is the village from which you came.", true);

      Room runningAway = new Room("Run-Away", "You have decided that this adventure was too much for you to handle. You have let down the King, the Princess, and all of Humanity. When you turned around and tried to ride away on Epona, an arrow was shot into the leg of Epona, dropping your horse and you to the ground. When you fell off your mighty horse, your head struck a rock. A nearby Bokoblin has snatched you and took you back to his lair. It was only here your fate was met, you were skinned alive, tortured and killed. The game is over. Maybe next time you might want to consider what can happen to humanity when you decide to make a wrong decision.", true);

      Room insideCastleWalls = new Room("Inside-Castle-Walls", $"You approach the castle walking inside of the gates with only the sword and shield you have on your back. You {CurrentPlayer.Name} are the only one capable of completing such a daunting task. The castle gate behind you closes. You are realizing there is no turning back now, you gather your surroundings. To the north, you see an open room, to the south you see a room with the door closed. As you look off in the distance to the East in front of you, you see a large set of double doors. These doors appear to have a lock on them that is glowing from the distance. I wonder where this could lead. Is that maybe where the princess is?", true);

      Room barracks = new Room("barracks", "As you slowly creep your way inside of the barracks, you notice that the room is pretty bland. There are bunk beds that look like they haven't been used in years. You see a dresser with some dust on it. In the distance is a window that looks into the yard of the castle. What is this place? Old uniforms are hung up, with a particular uniform folded neatly on a bed. This might be worth checking out. To the south you see the path you just came from, and further looks like another room that is potentially locked.", true);

      Room captainsQuarters = new Room("Captains-Quarters", "When you enter into the Captain's Quarters you realize that this room is filled with luxurious knock off treasure that has been taken from the townsfolk. This has made you sick to your stomach. Now the motivation is really fueling to rid of the corruption to bring peace to their lives. You look around the room, searching and searching for any clues or information. The sword you are wielding over your back is slowly starting to turn a light blue color. Could this be magic? You must be getting closer to something..", true);

      Room guardRoom = new Room("Guard-Room", "As you slowly approached the Guard Room eluding all the guards that are working the shift. You realize that this room is completely pitch black now that you are inside. If you were to turn on the lights, you might expose yourself. There must be another way to search around the room and take a look without alarming everybody.", false);

      Room courtyard = new Room("Courtyard", "You have tip toed back to the opening of the courtyard, you look inside and notice that all the guard are all passed out. You see fresh tracks of a guard that has left the courtyard to go talk to Ganon. To your north, you see the Throne Room. This room may just contain the princess after all. Now you hear the voice 'Brave Adventurer, I am here.. help me please'. Hearing that has motivated you in knowing that you finally hear this voice that you have been hearing all along. It is time to move forward and go save the princess", true);

      Room hallway = new Room("Hallway", "As you move further along in the adventure you see this mysterious hallway that leads to the Throne Room. This hallway contains pictures of the princess and the royal family before the corruption happened. You still hear the voices in your head about saving this princess. To your East you see a short hallway with one room. This might be worth checking out. If you treck down the hallway towards the Throne Room it may be a trap. Always better to be extra precautious.", true);

      Room squire = new Room("Squire Tower", "You climb up to the top of the tower to see if you can get a good insight from the crows next about the situation outside once you grab the princess. You do not see a person in sight. There must have been a big party tonight as all the guards are still passed out in the courtyard.", true);

      Room council = new Room("Council-Room", "You poke your head into the Council Room as you hear some faint whispering. Its the weird bald dude who knows everything from Game of Thrones! He tells you that your destiny and rescue is in the Throne Room. Do you really trust this guy? To the south takes you back to the base of the tower.", true);

      Room throne = new Room("Throne Room", "Here lies the room where the Princess is. She gives you a big hug and thanks you for saving her. She has been so sick and so worried about her family. You do know that you will come back to avenge Ganon and finish him off for good. To the East within the room, you see a portal start to form. I think its about time to make the great escape.", true);

      Room completion = new Room("Completion", "You and the Princess jump through the portal and end up back in front of the castle where it all started. Everybody from the village has come out to cheer you on. Congratulations brave adventurer, you have completed your quest in saving the princess. There will be more to the game coming soon. Make sure you come back for more adventure in the future", true);

      //NOTE Creating a new player

      Player link = new Player("link");


      //NOTE establishes the current Room the character is in.
      CurrentRoom = approachingCastle;

      //NOTE current player
      CurrentPlayer = link;

      //NOTE Adds items to the game
      Item key = new Item("key", "key that can be used for another room");
      Item light = new Item("light", "A tool used to light up a room");

      //Adds items to the rooms
      barracks.Items.Add(light);

      //NOTE establishes the relationships between the rooms
      approachingCastle.Exits.Add("west", runningAway);
      approachingCastle.Exits.Add("east", insideCastleWalls);

      insideCastleWalls.Exits.Add("north", barracks);
      insideCastleWalls.Exits.Add("south", captainsQuarters);

      barracks.Exits.Add("south", insideCastleWalls);

      captainsQuarters.Exits.Add("north", insideCastleWalls);
      captainsQuarters.Exits.Add("east", guardRoom);

      guardRoom.Exits.Add("west", courtyard);

      courtyard.Exits.Add("north", hallway);
      courtyard.Exits.Add("east", guardRoom);

      hallway.Exits.Add("east", squire);
      hallway.Exits.Add("north", throne);

      squire.Exits.Add("north", council);
      squire.Exits.Add("west", hallway);

      council.Exits.Add("south", squire);

      throne.Exits.Add("east", completion);


    }








    //Note running Setup
    public Game()
    {
      Setup();
    }
  }
}