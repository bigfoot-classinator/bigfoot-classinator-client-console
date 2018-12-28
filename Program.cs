using System;
using System.IO;

namespace BigfootClassinator
{
  class Program
  {
    static void Main(string[] args)
    {
      var view = new View();

      var info = FetchInfo();
      view.DisplayVersion(info);

      Console.WriteLine();
      Console.Write("Tell us about your Bigfoot sighting: ");

      var sighting = Console.ReadLine();
      var classination = ClassinateSighting(sighting);

      view.DisplayClassinationTitles();
      view.DisplayClassination(classination.classination);
    }

    private static InfoResponse FetchInfo()
    {
      var adapter = new Adapter();
      InfoResponse response = adapter.Info();
      return response;
    }

    private static ClassinationResponse ClassinateSighting(string sighting)
    {
      var adapter = new Adapter();
      var request = new ClassinationRequest { sighting = sighting };
      var response = adapter.Classinate(request);

      return response;
    }
  }
}
