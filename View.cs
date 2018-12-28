using System;
using System.IO;

namespace BigfootClassinator
{
  class View
  {
    public void DisplayHelp()
    {
      Console.WriteLine("Usage: classinator [runtime-options]");
      Console.WriteLine("--help, -h\tShow command line help.");
      Console.WriteLine("--version, -v\tDisplay server version.");
      Console.WriteLine();
    }

    public void DisplayVersion(ApplicationInfo info)
    {
      Console.WriteLine($"{info.Name} v{info.Version}");
      Console.WriteLine();
    }

    public void DisplayClassinationTitles()
    {
      Console.WriteLine("Class A,Class B,Class C,Selected");
    }

    public void DisplayClassination(Classination classination)
    {
      Console.Write($"{classination.ClassA},");
      Console.Write($"{classination.ClassB},");
      Console.Write($"{classination.ClassC},");
      Console.Write($"{classination.Selected}");
      Console.WriteLine();
    }
  }
}
