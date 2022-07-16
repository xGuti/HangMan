using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace HangMan
{
    class DBScript
    {
        public void Run()
        {
            string cs = @"server=localhost;userid=root;database=hangman";   //I know it should be putted to App.config but 
            try{                                                            //I'll leave it here if somebody would change connection string easily
                Console.WriteLine("Connecting . . .");
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();
                Console.WriteLine("Connected");

                //Delete if exists
                try{
                    Console.WriteLine("Dropping existing table . . .");
                    MySqlCommand cmd = new MySqlCommand(@"DROP TABLE IF EXISTS words", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Table dropped");
                }catch (Exception exception){
                    Console.WriteLine(exception);
                }

                //Create table words
                try{
                    Console.WriteLine("Creating table . . .");
                    MySqlCommand cmd = new MySqlCommand(@"CREATE TABLE words(" +
                        "id INTEGER PRIMARY KEY AUTO_INCREMENT," +
                        "word TEXT" +
                    ");", con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Table created");
                }catch (Exception exception){
                    Console.WriteLine(exception);
                }

                //Prepare data from file
                string textFile = @"C:\Users\Guti\Documents\GitHub\HangMan\words.txt"; //local path
                string lines = File.ReadAllText(textFile);

                lines = Regex.Replace(lines, @"[,\n]", String.Empty); //relace \n with \r
                lines = Regex.Replace(lines, @"\r\r", " ");

                string[] words = lines.Split();

                //Insert data to the table
                StringBuilder sb = new StringBuilder("INSERT INTO words (word) VALUES ");
                List<string> values = new List<string>();
                foreach (string word in words)
                    values.Add(string.Format("('{0}')", MySqlHelper.EscapeString(word)));
                
                sb.Append(string.Join(",", values));
                sb.Append(";");

                try{
                    Console.WriteLine("Adding records to database . . .");
                    MySqlCommand cmd = new MySqlCommand(sb.ToString(), con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine($"Added {words.Length} records");
                }catch (Exception exception){
                    Console.WriteLine(exception);
                }

                con.Close();
                Console.WriteLine("Disconnected");
            }catch(Exception exception){
                Console.WriteLine(exception);
            }
        }
    }
}
