using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey userInput;

            /* This 2 lines will change database content automatically
            DBScript dBScript = new DBScript();
            dBScript.Run();
            */

            while(true)
            {
                Console.WriteLine("Wciśnij dowolny klawisz aby rozpocząć.\nESC wby wyjść.");
                userInput = Console.ReadKey().Key;

                if(userInput == ConsoleKey.Escape)
                    Environment.Exit(0);

                string word = drawWord();

                Game new_game = new Game(word);
            }
        }

        static string drawWord(string connectionString = @"server=localhost;userid=root;database=hangman")
        {
            string word = "";
            Console.WriteLine("Connecting . . .");
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            Console.WriteLine("Connected");
            try
            {
                Console.WriteLine("Shuffling");
                MySqlCommand cmd = new MySqlCommand(@"SELECT * FROM words ORDER BY rand() LIMIT 1", con);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    word = reader[1].ToString();
                }
                reader.Close();

                Console.WriteLine("Word drawed");

                con.Close();

                return word;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            con.Close();
            return "";
        }
    }
}
