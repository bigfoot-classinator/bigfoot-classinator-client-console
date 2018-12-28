using System;
using System.IO;

using System.Threading.Tasks;

namespace BigfootClassinator
{
  class Program
  {
    static void Main(string[] args)
    {
      var controller = new Controller();

      if (args.Length == 0) {
        controller.OnClassinate();
      } else if (args[0] == "-v" || args[0] == "--version") {
        controller.OnVersion();
      } else {
        controller.OnHelp();
      }
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

  public class Controller
  {
    private Model model = new Model();
    private View view = new View();

    public void OnHelp()
    {
      view.DisplayHelp();
    }

    public void OnVersion()
    {
      var info = model.Info().Result;
      view.DisplayVersion(info);
    }

    public void OnClassinate()
    {
      Console.WriteLine();
      Console.Write("Tell us about your Bigfoot sighting: ");

      var classination = model.Classinate(new Sighting() { Text = Console.ReadLine() }).Result;

      view.DisplayClassinationTitles();
      view.DisplayClassination(classination.Classination);
    }

  }
}
