using System;
using System.IO;

namespace BigfootClassinator
{
  class View
  {
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
