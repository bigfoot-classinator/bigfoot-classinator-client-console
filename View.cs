using System;
using System.IO;

namespace BigfootClassinator
{
  class View
  {
    public void DisplayVersion(InfoResponse info)
    {
      Console.WriteLine($"{info.app} v{info.version}");
      Console.WriteLine();
    }

    public void DisplayClassinationTitles()
    {
      Console.WriteLine("Class A,Class B,Class C,Selected");
    }

    public void DisplayClassination(Classination classination)
    {
      Console.Write($"{classination.class_a},");
      Console.Write($"{classination.class_b},");
      Console.Write($"{classination.class_c},");
      Console.Write($"{classination.selected}");
      Console.WriteLine();
    }
  }
}
