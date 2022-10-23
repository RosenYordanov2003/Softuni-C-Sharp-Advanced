using System;
using System.Collections.Generic;

namespace Basketball
{
    public class StartUp
    {
        static void Main()
        {
            Team team = new Team("BHTC", 5, 'A');
            Player firstPlayer = new Player("Viktor", "Center", 97.5, 10);
            Console.WriteLine(firstPlayer);
            Console.WriteLine(team.AddPlayer(firstPlayer));
            Console.WriteLine(team.Count);
            Console.WriteLine(team.RemovePlayer("Slavi"));
            Player secondPlayer = new Player("Slavi", "Point Guard", 94.3, 47);
            Player thirdPlayer = new Player("Evgeni", "Shooting Guard", 93.7, 16);
            Player fourthPlayer = new Player("Momchil", "Small forward", 67.9, 3);
            Player fifthPlayer = new Player("Vasil", "Power forward", 86.9, 10);
            Player sixthPlayer = new Player("Stefan", "Center", 95.6, 25);
            Player seventhPlayer = new Player("Ivan", " Small forward ", 98.5, 89);
            Console.WriteLine(team.AddPlayer(secondPlayer));
            Console.WriteLine(team.AddPlayer(thirdPlayer));
            Console.WriteLine(team.AddPlayer(fourthPlayer));
            Console.WriteLine(team.AddPlayer(fifthPlayer));
            Console.WriteLine(team.AddPlayer(sixthPlayer));
            Console.WriteLine(team.AddPlayer(seventhPlayer));
            Console.WriteLine(team.RetirePlayer("Slavi"));
            List<Player> players = team.AwardPlayers(15);
            foreach (Player playerToBeAwarded in players)
            {
                Console.WriteLine(playerToBeAwarded);
            }
            Console.WriteLine(team.RemovePlayerByPosition("Center"));
            Console.WriteLine("----------------------Report----------------------");
            Console.WriteLine(team.Report());

        }
    }
}

