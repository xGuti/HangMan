using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    public class Game
    {
        private string word { get; set; }
        private List<char> availableLetters = new List<char>();
        private int lives { get; set; }

        public Game()
        {
            lives = 8;
            for (int i = 65; i <= 90; i++)
                availableLetters.Append((char)i);
            this.word = "hangman";
        }
        public Game(string word)
        {
            this.lives = 8;
            for (int i = 65; i <= 90; i++)
                this.availableLetters.Add((char)i);
            this.word = word;
        }

        public bool CheckLetter(char letter)
        {
            if (this.word is null)
            {
                throw new ArgumentNullException(nameof(this.word));
            }

            return this.word.Contains(letter);
        }
    }
}
