using System.Threading.Tasks;

using Newtonsoft.Json;

namespace BigfootClassinator
{
  class Model
  {
    private Adapter adapter = new Adapter();

    public async Task<ApplicationInfo> Info()
    {
      string response = await adapter.FetchInfo();
      return JsonConvert.DeserializeObject<ApplicationInfo>(response);
    }

    public async Task<ClassinationAndSighting> Classinate(Sighting sighting)
    {
      var request = JsonConvert.SerializeObject(sighting);
      string response = await adapter.ClassinateSighting(request);
      return JsonConvert.DeserializeObject<ClassinationAndSighting>(response);
    }
  }
}
