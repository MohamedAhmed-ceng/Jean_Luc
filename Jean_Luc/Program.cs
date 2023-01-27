/*1.Jean - Luc Picard’s journal.
Write a program which reads lines of text written by the user in the console and writes them into Captain’s journal.
To start writing into the journal the user should enter “start”. To end writing into the journal the user should enter “stop”.
Whatever the user enters before “start” or after “stop” should be discarded.
After entering the whole content, the program should create a file titled<current-date>.txt
with the content in the following format:
Captain’s log
Stardate<current-date>
First line…
Second line…
…
Jean-Luc Picard*/

string CurrentDate = DateTime.Now.ToString("dd/MM/yyyy");
string[] subs = CurrentDate.Split('/');
string DateToShow = "";
string text = "";
string input = "";
bool start = false;
bool stop = false;
string path = @"C:\Users\PC\source\repos\WSB-MohamedAhmed\Jean_Luc" + DateToShow + ".txt";

Console.WriteLine(CurrentDate);
Console.WriteLine("To begin writing your journal type 'start', and to finish it type 'stop'");

foreach (var Date in subs)
{
    DateToShow += Date;
}

if (!File.Exists(path))
{
    using StreamWriter sw = File.CreateText(path);
}

do
{
    text = Convert.ToString(Console.ReadLine());
    if (text == "start")
    {
        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine("Captain's log");
            sw.WriteLine("Stardate <" + CurrentDate + ">");

            while (!stop)
            {
                input = Console.ReadLine();
                if (input == "stop")
                {
                    stop = true;
                    break;
                }
                sw.WriteLine(input);
                input = "";
            }

            sw.WriteLine("Jean-Luc Picard");
            sw.Close();
        }
    }
    else
    {
        Console.WriteLine("Error! Please, write in your journal");
    }
} while (!stop);