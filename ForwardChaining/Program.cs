using System;

namespace ForwardChaining
{
    public class Program
    {
        static void Main(string[] args) {
            string path = @"C:\Users\Vytautas\Desktop\AI\ForwardChaining\ForwardChaining\tests\";
            ForwardChaining forwardChaining = new ForwardChaining(path+"Test2.txt");
            if (forwardChaining.Iterate()) {
                string rulesPath = "";

                for (int i = 0; i < forwardChaining.GetUserRules().Count; i++) {
                    rulesPath += "R" + forwardChaining.GetUserRules()[i].GetNumber();
                    if (i != forwardChaining.GetUserRules().Count - 1) {
                        rulesPath += " -> ";
                    }
                }

                Log.AddToLog("--------------------End--------------------");
                Log.AddToLog("Rules path : " + rulesPath);
                Log.AddToLog("Success");
                Log.WriteToFile();
            }
            else {
                string rulesPath = "";

                for (int i = 0; i < forwardChaining.GetUserRules().Count; i++) {
                    rulesPath += "R" + forwardChaining.GetUserRules()[i].GetNumber();
                    if (i != forwardChaining.GetUserRules().Count - 1) {
                        rulesPath += " -> ";
                    }
                }

                Log.AddToLog("--------------------End--------------------");
                Log.AddToLog("Rules path : " + rulesPath);
                Log.AddToLog("Fail");
                Log.WriteToFile();
            }
        }
    }
}
