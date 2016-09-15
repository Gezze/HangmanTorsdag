using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanAlfa
{
    class Program
    {
        static string playerName;
        static int lives = 7;
        //static string attempts;
        static string secretWord;
        static string guessedLetter;
        static int levelChosen;
        static string tryAgain;

        static void Main(string[] args)
        {
            Welcome();

            bool tryAgain = true;

            while (tryAgain)                    ///HÄR STARTAR SPEL-LOOPEN
            {
                PlayerName();
                MenuStart();
                Difficulty();
                WordGenerator();
                //CountLetters();
                GuessedWord();


            }                                   //HÄR SLUTAR SPEL-LOOPEN
            //ShowLetter();
            //IncorrectLetter();
            // ShowWrong();
            //GameWon();
            //GameLost();
            //TryAgain();
            //GameEngine();
        }
        static void Welcome()
        {
            Console.WriteLine("Welcome to the award winning Hangman Game made by the Alpha Team\n");


        }
        static void MenuStart()
        {
            // Låter spelaren välja mellan 1 och 2
            Console.WriteLine("1: Start");
            Console.WriteLine("2: How To");
            Console.WriteLine("3: Quit");
            string input = Console.ReadLine();
            int inputInt = int.Parse(input); // behöver felhantering

            switch (inputInt)
            {
                case 1: WordGenerator(); break;
                case 2: HowTo(); break;
                case 3: Quit(); break;
                default: Console.WriteLine("Choose 1,2 or 3!"); Console.ReadLine(); MenuStart(); break;

            }
            //Console.ReadLine();  // ska lägga till en if sats,
        }
        static void Quit()
        {
            // Credits avslutningsgrafik
            Environment.Exit(0);
        }
        static void PlayerName()
        {
            // Spelaren skriver in sitt namn och det 
            //kontrolleras att det är minst 3 bokstäver långt


            Console.WriteLine("Enter your name: ");                     //MIN TRE BOKSTÄVER I Namnet
            playerName = Console.ReadLine();
            while (playerName.Length < 3)
            {
                Console.WriteLine("invalid name, min 3 characters");
                playerName = Console.ReadLine();
            }


        }

        static int Difficulty()
        {
            bool levelChosenLoop = true;


            while (levelChosenLoop)                          ///HÄR STARTAR LOOPEN FÖR CHOSEN LEVEL                                                                           
            {
                Console.WriteLine("Choose level");
                Console.WriteLine("1: Easy");
                Console.WriteLine("2: Normal");
                Console.WriteLine("3: Hard");

                string input = Console.ReadLine();
                levelChosen = int.Parse(input);


                switch (levelChosen)
                {
                    case 1: Console.WriteLine("Easy level chosen"); levelChosenLoop = false; break;
                    case 2: Console.WriteLine("Normal level chosen"); levelChosenLoop = false; break;
                    case 3: Console.WriteLine("Hard level chosen"); levelChosenLoop = false; break;
                        // default: break;

                }

            }                                                  ///HÄR SLUTAR LOOPEN FÖR CHOSEN LEVEL
            return levelChosen;
        }



        static string WordGenerator()                           ///HÄR SKAPAS OLIKA ORD PER SVÅRHETSGRAD
        {
            // ska slumpa ett ord från en ordbank, 
            //utvecklas senare med array när vi har fler ord

            if (levelChosen == 1)
            {
                secretWord = "waterboy";
            }
            else if (levelChosen == 2)
            {
                secretWord = "flower";
            }

            else if (levelChosen == 3)
            {
                secretWord = "jazz";
            }
            return secretWord;
        }

        static void Lives(bool letterCorrect)
        {
            // hanterar liven, utvecklas med if senare
            Console.WriteLine(letterCorrect);
        }
        static int CountLetters()
        {
            // presenterar antal bokstäver i ordet
            int wordCharacters;
            return wordCharacters = secretWord.Length;
        }
        static void GuessedWord()
        {
            Console.WriteLine("The word has " + CountLetters() + " letters in it.");
            Console.WriteLine("Guess a word!"); //Kommer bytas ut mot en bokstav senare
            guessedLetter = Console.ReadLine();
            if (guessedLetter.ToLower() == secretWord)
            {
                GameWon();
            }

            else
            {
                IncorrectLetter();
            }
            //Lives(true);
        }
        static void ShowLetter()
        {
            //Visar bokstäver som använts
            Console.WriteLine(guessedLetter);
            Console.ReadLine();
        }
        static void IncorrectLetter()
        {
            // Räknar ner liv
            Console.WriteLine("IncorrectLetter");
            //Lives(false);
            lives--;
            Console.WriteLine("You have " + lives + " lives left");
            Console.ReadLine();
            if (lives > 0)
            {
                GuessedWord();
            }
            else
            {
                GameLost();
            }
        }

        static void ShowWrong()
        {
            // ska visa vilka bokstäver som är fel
        }

        static void GameLost()
        {
            // Visar ett meddelande om förlust
            Console.WriteLine("You are useless, you are a shame to the human kind " + playerName + "!");
            Console.ReadLine();
            TryAgain();
        }
        static void GameWon()
        {
            // Visar ett meddelande om vinst
            Console.WriteLine("Good job " + playerName + "!");
            Console.ReadLine();
            TryAgain();
        }
        static void TryAgain()
        {
            // Frågar om spelaren vill spela igen
            Console.WriteLine("Try again? Y/N");
            string testBokstav = Console.ReadLine();
            if (testBokstav.ToUpper() == "Y")
            {
                tryAgain = "bok";
            }
            else if (testBokstav.ToUpper() == "N")
            {

            }
            else
            {
                Console.WriteLine("MEN SKRIV Y ELLER N");
            }

            // anropa quit eller meny
        }
        static void GameEngine()
        {
            // Kontrollerar spelares liv och gissningar 
            //i en loop till spelets slut (provosorisk)
        }
        static void HowTo()
        {
            Console.WriteLine("Regler and shit");
            Console.ReadLine();
            MenuStart();
        }
    }

}
