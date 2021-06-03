using System;

namespace Bonus3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int randomNum = RandomNumber();
            int i= 0;
            int userNum = -1;
            string input1 = GetUserInput("I am thinking of a number between 1-100, can you guess what one?");
            bool goOn = true;

            while (randomNum != userNum || goOn==true)
            {
                string input = GetUserInput("Try to get it this time. Enter in another number");
                try
                {
                    userNum = int.Parse(input);
                    if (userNum >100)
                    { throw new Exception("Sorry, out of range. Please enter a number below 100"); }
                    if (userNum <1 )
                    { throw new Exception("Sorry, out of range. Please enter a number above 0"); }

                    string readBack = TooHighOrTooLow(randomNum, userNum, i);
                    
                    Console.WriteLine(readBack);
                    GetContinue();
                    if (randomNum != userNum)
                    {
                        i++;
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("That's not a vaild number, please try again");
                }
                catch (Exception e)
                { Console.WriteLine(e.Message); }


            }
            

        }
        public static bool GetContinue()
        {
            Console.WriteLine("Would you like to continue? y/n");
            string answer = Console.ReadLine();

            //There are 3 cases we care about 
            //1) y - we want to continue 
            //2) n - we want to stop 
            //3) anything else - we want to try again

            if (answer == "y")
            {
                return true;
            }
            else if (answer == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("I didn't understand that, please try again");
                //Calling a method inside itself is called recursion
                //Think of this as just trying again 
                return GetContinue();
            }
        }


        public static string TooHighOrTooLow(int randomNum, int userNum, int i)
        { 
            if (randomNum + 10 < userNum)
            {
                string writeLine = userNum + " is way too high than the number I am thinking of";
                return writeLine;
            }
            else if (randomNum < userNum)
            {
                string writeLine = userNum + " is too high than the number I am thinking of";
                return writeLine;
            }
            else if (randomNum - 10 > userNum)
            {
                string writeLine = userNum + " is way too low than the number I am thinking of";
                return writeLine;
            }
            else if (randomNum > userNum)
            {
                string writeLine = userNum + " is way low than the number I am thinking of";
                return writeLine;
            }
            else if (randomNum == userNum)
            {
                string writeLine = "Congrats! it took you " + i +" times, but you picked the right number!";

            
                return writeLine;

            }
            else
            {
                string writeLine = "Sorry I have no idea what you are talking about, try again";
                return writeLine;
            }
        }

        public static int RandomNumber()
        {
            Random r = new Random();
            int randomNum = r.Next(1, 101);
            return randomNum;
        }


        public static string GetUserInput(string desiredInput)
        {
            Console.WriteLine($"{desiredInput}");
            string input = Console.ReadLine();
            

            return input;
        }

    }
}
