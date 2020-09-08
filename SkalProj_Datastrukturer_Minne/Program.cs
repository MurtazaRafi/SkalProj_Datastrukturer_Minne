using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            // Testing to reverse text with stack
            // Console.WriteLine(ReverseText("Hello");

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;

                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        // Fråga 1: Stacken består av lager där varje lager måste köras i tur och ordning. Den håller i minnet bara det lager den jobbar med. 
        // Heap är en utpridd hög med saker som man har tillgång till och kan plocka fram snabbt, men man behöver sköta garbage collection på den


        // Fråga 2: Value types kan sparas både på stacken eller heapen. Medan reference types sparas på heapen. Value type har också en allocerad plats
        //  i minnet. En reference type kan ha pointer till där den är lagrad

        // Fråga 3: I det första fallet har x och y separata platser i minnet (value type). I det andra fallet pekar x och och y till samma plats i minnet
        // och är en reference type

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            // Create an empty list that later one can add or remove names from
            List<string> theList = new List<string>();
            Console.WriteLine("Enter + or - followed by the name that you want to add or remove from the list, like +Adam. Press R to return to the main menu");

            while (true)
            {
                char nav;
                string name;
                CatchEmptyInput(out nav, out name);

                switch (nav)
                {
                    case '+':
                        if (string.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("You must specify a name after the +/- sign");
                        }
                        else
                        {
                            theList.Add(name);
                            Console.WriteLine($"After adding to the list. List count: {theList.Count} List capacity: {theList.Capacity}");
                            // Print(theList);
                        }
                        break;
                    case '-':
                        if (!theList.Contains(name))
                            Console.WriteLine("You can only remove a name that exists in the list");
                        else
                        {
                            theList.Remove(name);
                            Console.WriteLine($"After removing from the list. List count: {theList.Count} List capacity: {theList.Capacity}");
                        }

                        break;
                    default:
                        if (nav != 'R')
                            Console.WriteLine("Use only + or -");
                        break;
                }
                if (nav == 'R')
                {
                    break;
                }
            }

            // Fråga 2 och 3: När det första elementet läggs till i listan (till 4) och sedan när femte läggs till (till 8, till 16) osv.
            // Fråga 5: För att varje gång kapaciteten ökar så kopieras de gamla (och nya) elementen till en ny array. Det här kan bli kostsamt om den gör för varje ökning i count
            // Fråga 5: Nej, den behåller sin kapacitet.
        }

        // Method for checking if an input is not empty
        private static void CatchEmptyInput(out char nav, out string name)
        {
            string input = Console.ReadLine();
            nav = ' ';
            try
            {
                nav = input[0];
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Please enter a + or - sign");
            }

            name = "";
            try
            {
                name = input.Substring(1);

            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("You must specify a name after the +/- sign");
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            Queue<string> theQueue = new Queue<string>();
            Console.WriteLine("Enter + followed by the name that you want to add to the queue, like +Adam or '-' to remove one person from the queue. Press R to return to the main menu");

            while (true)
            {
                char nav;
                string name;
                CatchEmptyInput(out nav, out name);

                switch (nav)
                {
                    case '+':
                        if (string.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("You must specify a name after the +/- sign");
                        }
                        else
                        {
                            theQueue.Enqueue(name);
                            Console.WriteLine("List of persons in the queue after enqueueing");
                            Print(theQueue);
                        }
                        break;
                    case '-':
                        if (!string.IsNullOrEmpty(name))
                            Console.WriteLine("You can only dequeue the first queued person by pressing only '-'");
                        else if (theQueue.Count == 0)
                        {
                            Console.WriteLine("There are no persons in the queue to remove");
                        }

                        else
                        {
                            theQueue.Dequeue();
                            Console.WriteLine("List of persons in the queue after dequeueing");
                            Print(theQueue);
                        }

                        break;
                    default:
                        if (nav != 'R')
                            Console.WriteLine("Use only + or -");
                        break;
                }
                if (nav == 'R')
                {
                    break;
                }
            }
        }

        private static void Print(IEnumerable<string> input)
        {
            foreach (var person in input)
            {
                Console.WriteLine(person);
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            Stack<string> theStack = new Stack<string>();
            Console.WriteLine("Enter + or - followed by the name that you want to add or remove from the stack, like +Adam. Press R to return to the main menu");

            while (true)
            {
                char nav;
                string name;
                CatchEmptyInput(out nav, out name);

                switch (nav)
                {
                    case '+':
                        if (string.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("You must specify a name after the +/- sign");
                        }
                        else
                        {
                            theStack.Push(name);
                            Console.WriteLine("Stack of persons after pushing");
                            Print(theStack);
                        }
                        break;
                    case '-':
                        if (!string.IsNullOrEmpty(name))
                            Console.WriteLine("You can only pop the last pushed person by pressing only '-'");
                        else if (theStack.Count == 0)
                        {
                            Console.WriteLine("There are no persons in the stack to remove");
                        }

                        else
                        {
                            theStack.Pop();
                            Console.WriteLine("Stack of persons after poping");
                            Print(theStack);
                        }

                        break;
                    default:
                        if (nav != 'R')
                            Console.WriteLine("Use only + or -");
                        break;
                }
                if (nav == 'R')
                {
                    break;
                }
            }

            // Fråga 1: För att när två personer (först person 1) ställer sig i kö måste så måste person 2 lämna kön för att person 1 ska kunna lämna kön (FILO)
        }

        // Method for reversing a string with stack
        static string ReverseText(string text)
        {
            Stack<char> charStack = new Stack<char>();
            foreach (char c in text.ToCharArray())
            {
                charStack.Push(c);
            }

            string reversedText = "";
            foreach (var c in charStack)
            {
                reversedText += c;
            }

            return reversedText;
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            // Jag vill använda stack för att man kan ta den senaste öppna parantesen och jämföra med stängningsparantesen

            while (true)
            {
                Console.WriteLine("Enter a string with paranthesis to check if the parthesis are opened and closed correctly");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    Console.WriteLine("You must give a string input");
                else
                {
                    Stack<char> stack = new Stack<char>();
                    bool error = false;
                    foreach (var c in input.ToCharArray())
                    {
                        if (c == '(' || c == '{' || c == '[')
                            stack.Push(c);
                        else if (c == ')' || c == '}' || c == ']')
                        {
                            if (stack.Peek() != ComplementParanthesis(c))
                            {
                                error = true;
                                break;
                            }
                            stack.Pop();
                        }
                    }
                    //ToDo fixa så att ")" och ()( ej accepteras  

                    if (error)
                        Console.WriteLine("The paranthesis are not closed correctly");
                    else
                        Console.WriteLine("The paranthesis are closed correctly");
                    break;

                }
            }
        }

        // Help function for CheckParanthesis method
        private static char ComplementParanthesis(char c)
        {
            char complementParanthesis;

            switch (c)
            {
                case ')':
                    complementParanthesis = '(';
                    break;
                case '}':
                    complementParanthesis = '{';
                    break;
                case ']':
                    complementParanthesis = '[';
                    break;
                default:
                    complementParanthesis = ' ';
                    break;
            }
            return complementParanthesis;
        }
    }
}


