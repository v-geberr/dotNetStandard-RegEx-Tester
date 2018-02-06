using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/***
 * Testing regex on .net
 * 
 * SO - LUIS - https://stackoverflow.com/questions/40514958/training-luis-to-recognise-a-job-ticket-number
 */

namespace RegExTester
{
    class Program
    {
        // usage
        // -p [sS]{1}\d+ 
        // -u What is that status on S344?    

        // response
        // Group: 0, Value: S344


        static void Main(string[] args)
        {
            const string patternCommand = "-p";
            const string utteranceCommand = "-u";

            string pattern = "";
            string utterance = "";

            string line;


            while(1==1)
            {
                // instructions
                consoleInstructions();

                // input
                line = Console.ReadLine();

                // exit?
                if (line == "exit") break;

                // set regex pattern
                if (line.IndexOf(patternCommand) !=-1)
                {
                    pattern = line.Substring(line.IndexOf(patternCommand) + patternCommand.Length+1).TrimEnd();
                    Console.WriteLine("pattern is " + pattern);
                }
                // set utterance
                if (line.IndexOf("-u") != -1)
                {
                    utterance = line.Substring(line.IndexOf(utteranceCommand) + utteranceCommand.Length+1).TrimEnd();
                    Console.WriteLine("utterance is " + utterance);
                }
                // run regex test
                if((!String.IsNullOrEmpty(pattern) && !String.IsNullOrEmpty(utterance)))
                {
                    Regex expression = new Regex(pattern);
                    GroupCollection groups = expression.Match(utterance).Groups;

                    // show any matches
                    foreach (string groupName in expression.GetGroupNames())
                    {
                        Console.WriteLine(
                           "Group: {0}, Value: {1}",
                           groupName,
                           groups[groupName].Value);
                    }
                }
            }

            return;

        }
        static void consoleInstructions()
        {
            Console.WriteLine("-p pattern");
            Console.WriteLine("-u utterance");
            Console.WriteLine("exit");
            Console.Write("");
        }
    }
}
