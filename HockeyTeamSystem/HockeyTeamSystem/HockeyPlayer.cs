using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HockeyTeamSystem
{
    public class HockeyPlayer : Person
    {
        private int _primaryNumber;
        public PlayerPosition Position { get; private set; }

        // Define properties with private set for Goals, assits
        public int Goals { get; private set; }
        public int Assists { get; private set; }
        // Define a readony computed property for Points (Goals + Assists)
        public int Points { get => Goals + Assists; }

        public int PrimaryNumber 
        { 
            get { return _primaryNumber; } 
            private set 
            { 
                //Validate PrimaryNumber is between 1 and 99
                if (value < 1 || value > 99)
                {
                    throw new ArgumentOutOfRangeException("HocketPlayer primaryNumber must be between 1 and 99.");
                }

                _primaryNumber = value;
            } 
        }

        

        //Define an greedy constructor
#pragma warning disable CS8618
        public HockeyPlayer(string fullName, int primaryNumber, PlayerPosition playerPosition,
            int goals, int assists) : base(fullName)
        {
            PrimaryNumber = primaryNumber;
            Position = playerPosition;
            Goals = goals;
            Assists = assists;
        }
        // Override the ToString() method to return a CSV
        public override string ToString()
        {
            return $"{FullName},{PrimaryNumber},{Position},{Goals},{Assists}";
        }

        // A staic (class-level) method can be accessed directly without creating an instance
        // object for the class. For example we can 
        // HockeyPlayer currentPlayer = HocketPlayer.Parse("")
        public static HockeyPlayer Parse(string csvLineText)
        {
            const char Delimiter = ',';
            string[] tokens = csvLineText.Split(',');
            //There should be 5 elements in the tokens
            if (tokens.Length != 5)
            {
                throw new FormatException($"CSV string not in the expected format. {csvLineText}");
            }

            return new HockeyPlayer(
                fullName: tokens[0],
                primaryNumber: int.Parse(tokens[1]),
                playerPosition: (PlayerPosition) Enum.Parse(typeof(PlayerPosition),(tokens[2])),
                goals: int.Parse(tokens[3]), 
                assists: int.Parse(tokens[4])
                );
        }

        public static bool TryParse(string csvLinetext, out HockeyPlayer player)
        {
            bool success = false;

            try
            {
                player = Parse(csvLinetext);
                success = true;
            }
            catch (FormatException ex)
            {
                throw new FormatException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"HockeyPlayer TryParse {ex.Message}");
            }

            return success;
        }


    }
}
