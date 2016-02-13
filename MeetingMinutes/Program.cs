using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
namespace MeetingMinutes
{
    class Program
    {
        static void Header()
        {

            Console.Clear();
            string title = "Meeting Minutes";
            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
            Console.WriteLine(title + "\n\n", Console.Title);

            Console.WriteLine("Main Menu");
            Console.WriteLine("1: Create Meeting");
            Console.WriteLine("2: View Team");
            Console.WriteLine("3: Exit");

        }


        static int NumberCheck(string input)
        {
            int menuItem;

            do
            {


                bool numVer = int.TryParse(input, out menuItem);
                if ((menuItem != 0))
                {
                    return menuItem;
                }
                else if (menuItem == 0)
                {
                    Console.WriteLine("That is not a valid entry, pleae enter a number");
                    input = Console.ReadLine();
                }
            }
            while (menuItem == 0);
            return menuItem;
        }





        static void Main(string[] args)
        {
            List<string> meetingType = new List<string>() { "EDUCATIONAL SERVICES", "FINANCIAL SERVICES", "MINISTRY OF MEETING MAKERS", "OUTDOOR ASSOCIATES", "ALL DEPARTMENTS" };
            List<string> topicNotesL = new List<string>();
            Dictionary<string, string> topicNotesD = new Dictionary<string, string>();
            Dictionary<string, string> peopleDept = new Dictionary<string, string>();
            peopleDept.Add("JIM JONES", "EDUCATIONAL SERVICES");
            peopleDept.Add("JAN JAMES", "MINISTRY OF MEETING MAKERS");
            peopleDept.Add("ANN AMES", "FINANCIAL SERVICES");
            peopleDept.Add("BO BRIDGES", "MINISTRY OF MEETING MAKERS");
            peopleDept.Add("CAL KALEE", "OUTDOOR ASSOCIATES");
            peopleDept.Add("WILL WILLIAMS", "OUTDOOR ASSOCIATES");
            peopleDept.Add("BILL BOT", "EDUCATIONAL SERVICES");
            peopleDept.Add("JILL JONAS", "EDUCATIONAL SERVICES");
            peopleDept.Add("SARA ARAS", "MINISTRY OF MEETING MAKERS");
            peopleDept.Add("GILL GREEN", "FINANCIAL SERVICES");
            peopleDept.Add("WORKER WORKERMAN", "FINANCIAL SERVICES");
            peopleDept.Add("PHILL PHILLIPSON", "OUTDOOR ASSOCIATES");

           
            bool restart = true;
            bool restart2 = true;
           
            while (restart == true)
            {
                Header();
                string input = Console.ReadLine();
                int userInput = NumberCheck(input);

                switch (userInput)
                {
                    case 1:

                        {

                            topicNotesD.Clear();
                            Console.WriteLine("\nEnter Name Of Team Member Recording Minutes:");
                            
                            string recorder = Console.ReadLine();
                     
                            Header();

                            Console.WriteLine("\nEnter Name Of Meeting Leader");
                            string leader = Console.ReadLine();

                            Header();
                            Console.WriteLine("\nEnter Meeting Date:MMDDYY");
                            string meetingDate = Console.ReadLine();
                        
                            Header();

                            Console.WriteLine("\nEnter Type of Meeting:\n");
                            for (int i = 0; i < meetingType.Count; i++)

                            {
                                if (i < meetingType.Count)
                                {
                                    Console.WriteLine((i + 1) + ": " + meetingType[i]);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            string meetingInput = Console.ReadLine();
                            int meetingInputInt = NumberCheck(meetingInput);
                            Header();
                            {

                                bool moreNotesCheck = false;
                                do
                                {

                                    Console.WriteLine("\nEnter Meeting Topic: ");
                                    string meetingTopic = Console.ReadLine();
                                    if (topicNotesD.ContainsKey(meetingTopic))
                                    {
                                        Console.WriteLine("Please Choose Another Topic. That One Was Already Used Today");
                                        {
                                            moreNotesCheck = true;

                                            continue;

                                        }
                                    }
                                    else
                                    {
                                        topicNotesD.Add(meetingTopic, null);
                                    }

                                    Header();
                                    Console.WriteLine("\nEnter Notes For Topic");
                                    string topicNotesString = Console.ReadLine();
                                    if (topicNotesD.ContainsKey(meetingTopic))
                                    {
                                        topicNotesD[meetingTopic] = topicNotesString;
                                    }
                                    Console.WriteLine("\nWould You Like to Enter Any Additional Notes (Y/N)?");
                                    string moreNotes = Convert.ToString(Console.ReadLine());

                                    if (moreNotes.ToUpper() == "Y")
                                    {
                                        moreNotesCheck = true;

                                    }
                                    else
                                    {
                                        moreNotesCheck = false;
                                    }


                                }
                                while (moreNotesCheck == true);

                            }

                            StreamWriter writer = new StreamWriter("Minutes" + meetingDate + ".txt");
                            using (writer)
                            {
                                writer.WriteLine("XYZ LLC Co.");
                                writer.WriteLine("1234 BirdReference, Anytown, U.S. 44114");
                                writer.WriteLine("\"Meeting Minutes\"");

                                writer.WriteLine("\r\n\r\nMinutes Recorded By: " + recorder.ToUpper());

                                writer.WriteLine("\r\nMeeting Led By: " + leader.ToUpper());

                                writer.WriteLine("\r\nMeeting Type: " + (meetingType[meetingInputInt - 1]));

                                foreach (KeyValuePair<string, string> pair in topicNotesD)
                                {
                                    writer.WriteLine("\r\nTopic:" + pair.Key + "\r\nNotes: " + pair.Value);
                                }

                            }
                          
                            Console.Clear();
                            Console.WriteLine("\nFile Preview\n");
                            using (StreamReader sr = File.OpenText("Minutes" + meetingDate + ".txt"))
                            {
                                string s = "";
                                while ((s = sr.ReadLine()) != null)
                                {

                                    Console.WriteLine(s);

                                }
                                                      
                            }

                            Console.WriteLine("\nPress Any Key To Return To The Main Menu");

                            
                                Console.ReadKey();
        

                            break;

                        }

                    case 2:
                        do
                        {    restart2 = true;
                            Console.Clear();
                            Console.WriteLine("TEAM MENU:");
                            Console.WriteLine("1: VIEW ALL TEAM MEMBERS");
                            Console.WriteLine("2: VIEW EDUCATIONAL SERVICES TEAM");
                            Console.WriteLine("3: VIEW FINANCIAL SERVICES TEAM");
                            Console.WriteLine("4: VIEW MINISTRY OF MEETING MAKERS");
                            Console.WriteLine("5: OUTDOOR ASSOCIATES");
                            Console.WriteLine("6: RETURN TO MAIN MENU");
                            input = Console.ReadLine();
                            userInput = NumberCheck(input);

                            switch (userInput)

                            {
                                case 1:
                                    {
                                        
                                        Console.Clear();
                                        Console.WriteLine("VIEW ALL TEAM MEMBERS:\n");
                                        foreach (KeyValuePair<string, string> pair in peopleDept)

                                        {
                                            Console.WriteLine(pair.Key + " (" + pair.Value + ")");

                                        }

                                        Console.WriteLine("Press Any Key To Return to Team Menu");
                                        Console.ReadKey();
                                        Console.Clear();
                                        continue;

                                    }
                                case 2:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("EDUCATIONAL SERVICES TEAM:\n");
             
                                        {

                                            foreach (KeyValuePair<string, string> pair in peopleDept)

                                            {
                                                if (pair.Value == "EDUCATIONAL SERVICES")
                                     

                                                    Console.WriteLine(pair.Key);
                                                }
                                             }

                                        Console.WriteLine("Press Any Key To Return to Team Menu");
                                        Console.ReadKey();
                                        Console.Clear();
                                        continue;
                                    }


                                case 3:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("FINANCIAL SERVICES TEAM:\n");

                                        {

                                            foreach (KeyValuePair<string, string> pair in peopleDept)

                                            {
                                                if (pair.Value == "FINANCIAL SERVICES")


                                                    Console.WriteLine(pair.Key);
                                            }
                                        }

                                        Console.WriteLine("Press Any Key To Return to Team Menu");
                                        Console.ReadKey();
                                        Console.Clear();
                                        continue;
                                    }
                                case 4:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("MINISTRY OF MEETING MAKERS TEAM:\n");

                                        {

                                            foreach (KeyValuePair<string, string> pair in peopleDept)

                                            {
                                                if (pair.Value == "MINISTRY OF MEETING MAKERS")


                                                    Console.WriteLine(pair.Key);
                                            }
                                        }

                                        Console.WriteLine("Press Any Key To Return to Team Menu");
                                        Console.ReadKey();
                                        Console.Clear();
                                        continue;
                                    }

                                case 5:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("OUTDOOR ASSOCIATES SQUAD:\n");

                                        {

                                            foreach (KeyValuePair<string, string> pair in peopleDept)

                                            {
                                                if (pair.Value == "OUTDOOR ASSOCIATES")


                                                    Console.WriteLine(pair.Key);
                                            }
                                        }

                                        Console.WriteLine("Press Any Key To Return to Team Menu");
                                        Console.ReadKey();
                                        Console.Clear();
                                        continue;
                                    }

                                case 6:
                                    restart2 = false;
                                    {
                                        break;
                                    }
                            }
                        }
                        while (restart2 == true);

                        break;
                       


                     case 3:

                        Console.Clear();
                        Console.WriteLine("GoodBye");
                        Thread.Sleep(2000);
                        Environment.Exit(0);

                        {
                            break;

                        }
                    default:
                        Header();
                        Console.WriteLine("Invalid Entry, Hit Any Key To Try Again");
                        Console.ReadKey();
                        restart = true;
                        {
                            break;

                        }
                }
            }
        }

    }
}

            
        
    


    




    
