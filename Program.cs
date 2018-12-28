using System;
using System.IO;

namespace BigfootClassinator
{
  class Program
  {
    static void Main(string[] args)
    {

      Console.WriteLine("Bigfoot Classinator");

      Console.WriteLine();
      Console.Write("Tell us about your Bigfoot sighting: ");

      var sighting = Console.ReadLine();
      var classination = ClassinateSighting(sighting);

      Console.WriteLine();
      Console.WriteLine(classination);
    }

    private static string ClassinateSighting(string sighting)
    {
      var adapter = new Adapter();
      var request = new ClassinationRequest { sighting = sighting };
      var response = adapter.Classinate(request);

      return response.classination.selected;
    }
  }
}
