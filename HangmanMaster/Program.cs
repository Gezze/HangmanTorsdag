using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanAlfa
{
    class Program
    {
        //
        static string playerName;
        static int lives = 7;
        //static string attempts;
        static string secretWord;
       // static string guessedLetter;
        static int levelChosen;
        static string[] maskedWord;
        static bool isTryAgain = true;



        static void Main(string[] args)
        {
            Welcome();


            while (isTryAgain)                    ///HÄR STARTAR SPEL-LOOPEN
            {
                PlayerName();
                MenuStart();
                Difficulty();
                WordGenerator();
                //CountLetters();
                GuessedLetter();
                TryAgain();


            }                                   //HÄR SLUTAR SPEL-LOOPEN
            //ShowLetter();
            //IncorrectLetter();
            // ShowWrong();
            
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
            Console.Clear();
            Console.WriteLine("\n1: Start");
            Console.WriteLine("2: How To");
            Console.WriteLine("3: Quit");
            string input = Console.ReadLine();
            int inputInt = int.Parse(input);
            while (inputInt>3 || inputInt<1)
            
            {
                Console.WriteLine("Choose 1,2 or 3!");
                input = Console.ReadLine();
                inputInt = int.Parse(input);
            }
                 switch (inputInt)
                {
                    case 1: WordGenerator(); break;
                    case 2: HowTo(); break;
                    case 3: Quit(); break;
                    default: break;

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


            Console.Write("Enter your name: ");                     //MIN TRE BOKSTÄVER I Namnet
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
                Console.Clear();
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



        static void WordGenerator()                           ///HÄR SKAPAS OLIKA ORD PER SVÅRHETSGRAD
        {
            // ska slumpa ett ord från en ordbank, 
            //utvecklas senare med array när vi har fler ord

            string[] easyWords = new string[3];
            easyWords[1] = "waterboy";

            string[] normalWords = new string[3];
            normalWords[1] = "flower";

            string[] hardWords = new string[3];
            hardWords[1] = "jazz";



            if (levelChosen == 1)
            {
                secretWord = easyWords[1];
            }
            else if (levelChosen == 2)
            {
                secretWord = normalWords[1];
            }

            else if (levelChosen == 3)
            {
                secretWord = hardWords[1];
            }
            
        }

        static void Lives(bool letterCorrect)
        {
            // hanterar liven, utvecklas med if senare
            Console.WriteLine(letterCorrect);
        }
        
        static void GuessedLetter()
        {
            maskedWord = new string[secretWord.Length];
            
            Console.WriteLine("The word has " + secretWord.Length + " letters in it.\nGuess a letter:");
            for (int i = 0; i < maskedWord.Length; i++)

            {
                maskedWord[i] = "_ ";
                Console.Write(maskedWord[i]);
                

            }
            
            bool gameWon = false;
            int lettersRevealed = 0;
            while (!gameWon)
            {
                string input = Console.ReadLine();
                for (int i = 0; i <secretWord.Length; i++)
                {
                    if (input == secretWord[i].ToString())
                    {
                        maskedWord[i] = input;
                        lettersRevealed++;
                    }
                }
                for (int i = 0; i < maskedWord.Length; i++)
                
                {
                    
                    Console.Write(maskedWord[i]);
                }
                Console.Write("\nGuess a letter: ");
                if (lettersRevealed==secretWord.Length)
                {
                    gameWon = true;
                }
            }
            

            /*
            Console.WriteLine("\nGuess a letter!"); //Kommer bytas ut mot en bokstav senare
            guessedLetter = Console.ReadLine();
            if (guessedLetter.ToLower() == secretWord)
            {

                GameWon();
            }

            else
            {
                IncorrectLetter();
            }
            */
            //Lives(true);
        }
        static void ShowUsedLetter()
        {
            //Visar bokstäver som använts
           // Console.WriteLine(guessedLetter);
            Console.ReadLine();
        }
        static void IncorrectLetter()
        {
            // Räknar ner liv
            Console.WriteLine("IncorrectLetter");
            //Lives(false);
            lives--;
            Console.WriteLine("You have " + lives + " lives left");
            if (lives > 0)
            {
                GuessedLetter();
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
            Console.Clear();
            Console.WriteLine("Good job " + playerName + "!");
            Console.WriteLine("The word is " + secretWord);
            Console.ReadLine();
            TryAgain();
        }
        static void TryAgain()
        {

           
            // Frågar om spelaren vill spela igen
            Console.WriteLine("Try again? (Y/N");
            string inputTry = Console.ReadLine();
            while (inputTry.ToUpper() != "Y" || inputTry.ToUpper() != "N")
            {
                
            }
            if (inputTry.ToUpper() == "Y")
            {
                isTryAgain = true;
            }
            if (inputTry.ToUpper() == "N")
            {
                Quit();
            }

            else
            {
                Console.WriteLine("You have to press 'Y' or 'N', stupid!");
                inputTry = Console.ReadLine();
            }
                
            
            

            // anropa quit eller meny
        }
        
        static void HowTo()
        {
            Console.Clear();
            Console.WriteLine("\n*******************RULES*************************");
            Console.WriteLine("The goal of the game is to guess the hidden word.");
            Console.WriteLine("To do this you type in one letter at a time.");
            Console.WriteLine("If a correct letter is chosen it will be placed in the word.");
            Console.WriteLine("When the wrong letter is chosen you lose a life.");
            Console.WriteLine("When your lives reach 0 or the word is completed the game will end.");
            Console.ReadLine();
            MenuStart();
        }
    }

}

			

			