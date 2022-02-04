using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyTeamSystem
{
    public class HockeyTeam
    {
        // Define a computed (read-only) proeprty to TotalPoints for all HockeyPlayers
        // sums the Points for each HockeyPlayer in the team

        public int TotalPoints 
        {
            get 
            {
                int totalPoints = 0;
                
                // you can use var instead of HockeyPlayer, it automatically recognizes the correct class using the class List name
                foreach (HockeyPlayer currentPlayer in HockeyPlayers)
                {
                    totalPoints += currentPlayer.Points;
                }
                return totalPoints;
            }
            
        }

        // Define a fully-implemented property with a backing field for the team name 
        private string _teamName; // Define a private backign field for teh property
        public string TeamName  // Define a readonly property for TeamName with a private Set
        {
            get { return _teamName; }
            private set 
            {
                //Validate teh new team name is not null, empty string or only whitespaces
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("HockeyTeam TeamName is requried");
                }
                // VAlidate the new team name containes 5 or more characters
                if(value.Trim().Length < 5)
                {
                    throw new ArgumentException("HockeyTeam TeamName must contain 5 or more characters");
                }
                _teamName = value; 
            }
        }

        // Define a auto-implemented property with a private set for the Division 
        public  TeamDivision Division { get; private set; }

        // Define a auto-implemented readonly property for the HockeyPlayers
        public List<HockeyPlayer> HockeyPlayers { get;} = new List<HockeyPlayer>();

        // Define a read-only property for PlayerCount
        public int PlayerCount
        {
            get { return HockeyPlayers.Count; }
        }

        // Define a readonly property with a private set for the coach
        // The Coach peropery is known as Aggregation/Composition when: the field/property is an Object
        public HockeyCoach Coach { get; private set; }


        // Define a greedy constructor that has a parameter for the HockeyCoach and TeamDivision
        // team name, team division, and coach 

#pragma warning disable 

        public HockeyTeam(string teamName, TeamDivision division, HockeyCoach coach)
        {
            TeamName = teamName;
            Division = division;
            Coach = coach;
        }

        public void AddPlayer(HockeyPlayer player)
        {
            // Validate that the player is not null
            if(player ==null)
            {
                throw new ArgumentNullException("HockeyTeam add hockey Player is requried.");
            }
            // Validate that the number of players is less than 23
            if(PlayerCount == 23)
            {
                throw new ArgumentException("HockeyTeam add hocket player failed. Exceed 23 players.");
            }

            // Validate that player (by primary number) is not already on the team
            foreach(HockeyPlayer currentPlayer in HockeyPlayers)
            {
                if(player.PrimaryNumber == currentPlayer.PrimaryNumber)
                {
                    throw new ArgumentException("HockeyTeam add hockey player failed. Player primary number already exists.");
                }
                
            }

            HockeyPlayers.Add(player);
        }

        public override string ToString()
        {
            return $"{TeamName},{Coach},{Division}";
        }

    }
}
