using System.IO;

using System.Threading.Tasks;

namespace BigfootClassinator
{
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
      view.DisplayClassinationTitles();
      foreach (var sighting in view.ReadSightings())
      {
        var classinationAndSighting = model.Classinate(sighting).Result;
        view.DisplayClassination(classinationAndSighting);
      }
    }
  }
}
