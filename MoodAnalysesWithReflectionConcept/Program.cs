using MoodAnalysesWithCore;
using System;

namespace MoodAnalysesWithReflectionConcept
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Mood Analyses With Reflection");
            MoodAnalyser analyser = new MoodAnalyser("I am in sad Mood");
            Console.WriteLine(analyser.AnalyserMethod());
            Console.ReadLine();
        }
    }
}
