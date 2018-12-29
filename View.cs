using System;
using System.IO;
using System.Collections.Generic;

namespace BigfootClassinator
{
  class View
  {
    public Sighting[] ReadSightings()
    {
      List<Sighting> sightings = new List<Sighting>();
      string sightingText = Console.ReadLine();
      while (sightingText != null)
      {
        sightings.Add(new Sighting() { Text =sightingText });
        sightingText = Console.ReadLine();
      }

      return sightings.ToArray();
    }

    public void DisplayHelp()
    {
      Console.WriteLine("Usage: classinator [runtime-options]");
      Console.WriteLine("--help, -h\tShow command line help.");
      Console.WriteLine("--version, -v\tDisplay server version.");
      Console.WriteLine("");
      Console.WriteLine("To classinate, redirect input using | or <.");
      Console.WriteLine();
    }

    public void DisplayVersion(ApplicationInfo info)
    {
      Console.WriteLine($"{info.Name} v{info.Version}");
      Console.WriteLine();
    }

    public void DisplayClassinationTitles()
    {
      Console.WriteLine("Class A,Class B,Class C,Selected,Sighting");
    }

    public void DisplayClassination(ClassinationAndSighting classination)
    {
      Console.Write($"{classination.Classination.ClassA},");
      Console.Write($"{classination.Classination.ClassB},");
      Console.Write($"{classination.Classination.ClassC},");
      Console.Write($"{classination.Classination.Selected},");
      Console.Write($"\"{classination.Sighting.Replace("\"", "\\\"")}\"");
      Console.WriteLine();
    }
  }
}
