using System;

using System.IO;

using System.Net.Http;
using System.Net.Http.Headers;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using System.Threading.Tasks;

using RestSharp;

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
      var request = new SightingRequest { sighting = sighting };

      var client = new RestClient("http://bigfoot-classinator.herokuapp.com");
      var restRequest = new RestRequest("classinate", Method.POST);
      restRequest.AddJsonBody(request);

      var restResponse = client.Execute<SightingResponse>(restRequest);

      return restResponse.Data.classination.selected;
    }
  }
}
