using System;
using System.IO;
using System.Collections.Generic;
using CsvHelper;

namespace BigfootClassinator
{
  class View
  {
    public IEnumerable<Sighting> ReadSightings()
    {
      var sightings = new StringWriter();

      string line = Console.ReadLine();
      while (line != null)
      {
        sightings.WriteLine(line);
        line = Console.ReadLine();
      }

      var reader = new StringReader(sightings.ToString());
      var csv = new CsvReader(reader);
      csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
      var records = csv.GetRecords<Sighting>();

      return records;
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
      Console.WriteLine($"{info.Attribution}");
      Console.WriteLine();
    }

    public void DisplayClassinationTitles()
    {
      Console.WriteLine("Class A,Class B,Selected,Sighting");
    }

    public void DisplayClassination(ClassinationAndSighting classination)
    {
      Console.Write($"{classination.Classination.ClassA},");
      Console.Write($"{classination.Classination.ClassB},");
      Console.Write($"{classination.Classination.Selected},");
      Console.Write($"\"{classination.Sighting.Replace("\"", "\\\"")}\"");
      Console.WriteLine();
    }
  }
}
