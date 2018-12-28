using System;
using System.IO;

using System.Threading.Tasks;

namespace BigfootClassinator
{
  class Program
  {
    static void Main(string[] args)
    {
      string s = ProcessRequests().Result;
    }

    private static async Task<string> ProcessRequests()
    {
      var model = new Model();
      var view = new View();

      var info = await model.Info();
      view.DisplayVersion(info);

      Console.WriteLine();
      Console.Write("Tell us about your Bigfoot sighting: ");

      var sighting = new Sighting() { Text = Console.ReadLine() };
      var classination = await model.Classinate(sighting);

      view.DisplayClassinationTitles();
      view.DisplayClassination(classination.Classination);

      return "foo";
    }
  }
}
