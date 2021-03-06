// See https://aka.ms/new-console-template for more information





using HockeyTeamSystem;
using static System.Console;
using System.Text.RegularExpressions;
using System.Text.Json;



// Define a constant for the location of players CSV data file
const string HockeyPlayerCsvFile = "../../../HockeyPlayers.csv";
const string HockeyTeamJsonFile = "../../../HockeyTeam.json";

//WriteLine("Creating CSV file for hockey players.");
//CreateHocketPlayersCSVFile();
HockeyTeam currentTeam = ReadHockeyPlayerCSVFile(HockeyPlayerCsvFile);
DisplayHockeyTeam(currentTeam);
WriteHockeyTeamToJsonFile(currentTeam, HockeyTeamJsonFile);
currentTeam = ReadHockeyTeamFromJsonFile(HockeyTeamJsonFile);
DisplayHockeyTeam(currentTeam);



static void CreateHocketPlayersCSVFile()
{

    try
    {
        // Create a new HockeyCoach instance for the team
        HockeyCoach coach = new HockeyCoach("Dave Trippet", "May 28, 2019");
        // Create players for the team
        HockeyPlayer player1 = new HockeyPlayer("Leon Draisaitl", 29, PlayerPosition.Center, 29, 30);
        // WriteLine(player1);
        HockeyPlayer player2 = new HockeyPlayer("Conno McDavid", 97, PlayerPosition.Center, 20, 37);
        //WriteLine(player2);
        HockeyPlayer player3 = new HockeyPlayer("Ryan NugentHopkins", 93, PlayerPosition.Center, 3, 24);
        // WriteLine(player3);
        HockeyPlayer player4 = new HockeyPlayer("Jesse Puljujarvi", 13, PlayerPosition.RightWing, 10, 15);
        // WriteLine(player4);
        HockeyPlayer player5 = new HockeyPlayer("Jesse Puljujarvi", 14, PlayerPosition.RightWing, 10, 15);
        // WriteLine(player5);
        // Create a hockey team
        HockeyTeam team1 = new HockeyTeam("Edmonton Oilers", TeamDivision.Pacific, coach);
        // Add players to the hockey team
        team1.AddPlayer(player1);
        team1.AddPlayer(player2);
        team1.AddPlayer(player3);
        team1.AddPlayer(player4);
        team1.AddPlayer(player5);
        //WriteLine(team1);

        //Write the list of hocekt players to a CSV file
         //Step 1: Create a csv line for each hockey player and add it to a list of a list of string values
        List<string> csvLines = new List<string>();
        foreach (HockeyPlayer currentPlayer in team1.HockeyPlayers)
        {
            csvLines.Add(currentPlayer.ToString());
        }
        // Step 2: Write all the lines in the list of string values to a file
        File.WriteAllLines(HockeyPlayerCsvFile, csvLines);



        //Alternative way to do it
        /*
        using (StreamWriter sw = new StreamWriter(HockeyPlayerCsvFile))
        {
            foreach(HockeyPlayer player in team1.HockeyPlayers)
            {
                sw.WriteLine(player.ToString());
            }
            sw.Close(); //Optional if you use "using"
        }
        */


        //Display the location absolute of the csv data file
        WriteLine($"Successfully created csv file at: {Path.GetFullPath(HockeyPlayerCsvFile)}");
    }
    catch (Exception ex)
    {
        WriteLine($"Error writing to CSV file with excepton {ex.Message}");
    }
    
}

static HockeyTeam ReadHockeyPlayerCSVFile(string csvFilePath)
{
    HockeyCoach coach1 = new HockeyCoach("David Tippet", "May 28, 2019");
    HockeyTeam team1 = new("Edmonton Oilers", TeamDivision.Pacific, coach1);

    try
    {
        //Read all the lines from the file and return an array of string values for each line
        string[] allLinesArray = File.ReadAllLines(HockeyPlayerCsvFile);
        foreach(string line in allLinesArray)
        {
            try
            {
                HockeyPlayer currentPlayer = null;
                bool success = HockeyPlayer.TryParse(line, out currentPlayer);
                if(success)
                {
                    team1.AddPlayer(currentPlayer);
                }
            }
            catch(FormatException ex)
            {
                Console.WriteLine($"Format exception: {ex.Message}");
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine($"Argument null exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing data from line with exception: {ex.Message}");
            }
        }
    }
    catch (Exception ex)
    {
        WriteLine($"Error reading from  file with exception: {ex.Message}");
    }
    return team1;
}

static void DisplayHockeyTeam(HockeyTeam currentTeam)
{
    if (currentTeam == null)
    {
        WriteLine("There is no HockeyTeam to display");
    }
    else
    {
        WriteLine($"Coach: {currentTeam.Coach}");
        if (currentTeam.HockeyPlayers.Count == 0 )
        {
            WriteLine($"There are no players for {currentTeam.TeamName}");
        }
        else
        {
            WriteLine($"Hockey players for {currentTeam.TeamName}");
            foreach(HockeyPlayer currentPlayer in currentTeam.HockeyPlayers)
            {
                WriteLine($"Hockey Player: {currentPlayer}");
            }
        }
        
    }
}

static void WriteHockeyTeamToJsonFile(HockeyTeam currentTeam, string jsonFilePath)
{
    try
    {
        // Make sure you add the namespace System.Text.Json

        //JsonSerializerOptions options = new JsonSerializerOptions();
        //options.WriteIndented = true;
        //options.IncludeFields = true;

        //Shortcut way of above lines

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true
        };
        string jsonString = JsonSerializer.Serialize<HockeyTeam>(currentTeam, options);
        File.WriteAllText(jsonFilePath, jsonString);
        WriteLine($"Successfully created JSON fole at {Path.GetFullPath(jsonFilePath)}");
    }
    catch (Exception ex)
    {
        WriteLine($"Error writing to json file with exception: {ex.Message}");
    }
}

static HockeyTeam ReadHockeyTeamFromJsonFile(string jsonFilePath)
{
    HockeyTeam currentTeam = null;
    try
    {
        string jsonString = File.ReadAllText(jsonFilePath);
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented=true,
            IncludeFields=true
        };
        //currentTeam = JsonSerializer.Deserialize<HockeyTeam>(jsonString, options);  // this wont work bcz of readonly property and inheritence so new technique

        currentTeam = Newtonsoft.Json.JsonConvert.DeserializeObject<HockeyTeam>(jsonString, new Newtonsoft.Json.JsonSerializerSettings()
        {
            ConstructorHandling = Newtonsoft.Json.ConstructorHandling.AllowNonPublicDefaultConstructor
        });

        DisplayHockeyTeam(currentTeam);
    }
    catch(Exception ex)
    {
        WriteLine($"Error reading from json file with exception: {ex.Message}");
    }
    return currentTeam;
}
//// Read the list of hockey players from the CSV files
//try
//{
//    WriteLine("Reading from CSV file");
//    string[] csvLineArray = File.ReadAllLines(HockeyPlayerCsvFile);
//    foreach(string line in csvLineArray)
//    {
//        HockeyPlayer currentPlayer = null;
//        bool parseSuccessful = HockeyPlayer.TryParse(line, out currentPlayer);
//        WriteLine(currentPlayer);
//    }
//}
//catch (Exception ex)
//{
//    WriteLine(ex);
//}




