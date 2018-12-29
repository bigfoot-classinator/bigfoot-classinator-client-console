using System;

namespace BigfootClassinator
{
  class Program
  {
    static void Main(string[] args)
    {
      var controller = new Controller();

      if (args.Length == 0) {

        if (Console.IsInputRedirected)
        {
          controller.OnClassinate();
        }
        else
        {
          controller.OnHelp();
        }

      } else {

        if (args[0] == "-v" || args[0] == "--version")
        {
          controller.OnVersion();
        }
        else
        {
          controller.OnHelp();
        }

      }
    }
  }
}
