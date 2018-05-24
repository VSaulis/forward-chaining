using System;

namespace ForwardChaining
{
    public class Program
    {
        static void Main(string[] args) {
            string path = @"C:\Users\Vytautas\source\repos\ForwardChaining\ForwardChaining\tests\";
            ForwardChaining forwardChaining = new ForwardChaining(path+"Test7.txt");
            if (forwardChaining.Iterate()) {
                Log.AddToLog("Success");
                Log.WriteToFile();
            }
            else {
                Log.AddToLog("Fail");
                Log.WriteToFile();
            }
        }
    }
}
