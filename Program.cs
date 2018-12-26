using System;

using System.IO;

using System.Net.Http;
using System.Net.Http.Headers;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using System.Threading.Tasks;

namespace BigfootClassinator
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine(ClassinateSighting().Result);
    }

    private static async Task<SightingResponse> ClassinateSighting()
    {
      // make the request object
      var request = new SightingRequest { Sighting = "I saw bigfoot in the woods" };
      Console.WriteLine(request);

      // serialize it to JSON
      DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SightingRequest));
      MemoryStream ms = new MemoryStream();
      js.WriteObject(ms, request);
      ms.Position = 0;

      StreamReader sr = new StreamReader(ms);
      var requestJson = sr.ReadToEnd();

      sr.Close();
      ms.Close();

      Console.WriteLine(requestJson);

      // setup the http client
      HttpClient client = new HttpClient();
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      client.DefaultRequestHeaders.Add("User-Agent", "Console Classinator");

      // prepare the uri
      Uri uri = new Uri("https://bigfoot-classinator.herokuapp.com/classinate");
      Console.WriteLine(uri);

      // prepare the http body
      HttpContent body = new StringContent(requestJson);
      body.Headers.ContentType = new MediaTypeHeaderValue("application/json");
      Console.WriteLine(body);

      // make the http call with the uri and the body
      HttpResponseMessage httpResponse = await client.PostAsync(uri, body);
      Console.WriteLine(httpResponse.Content);

      // if the server ain't happy, nobody's happy
      if (!httpResponse.IsSuccessStatusCode) throw new Exception("HTTP Request was not successful");

      // parse the response
      SightingResponse response = await httpResponse.Content.ReadAsAsync<SightingResponse>();

      // return it
      return response;
    }
  }

  [DataContract]
  public class SightingRequest
  {
    [DataMember(Name="sighting")]
    public string Sighting { get; set; }

    public override string ToString()
    {
      return $"{this.GetType().Name}: {this.Sighting}";
    }
  }

  [DataContract]
  public class SightingResponse
  {
    [DataMember(Name="sighting")]
    public string Sighting { get; set; }

    [DataMember(Name="classination")]
    public Classination Classination { get; set; }

    public override string ToString()
    {
      return $"{this.GetType().Name}: {this.Sighting} <{this.Classination.ToString()}>";
    }
  }

  [DataContract]
  public class Classination
  {
    [DataMember(Name="class_a")]
    public double ClassA { get; set; }

    [DataMember(Name="class_b")]
    public double ClassB { get; set; }

    [DataMember(Name="class_c")]
    public double ClassC { get; set; }

    [DataMember(Name="selected")]
    public string Selected { get; set; }

    public override string ToString()
    {
      return $"{this.GetType().Name}: ClassA {this.ClassA}, ClassB {this.ClassB}, ClassC {this.ClassC}, Selected {this.Selected}";
    }
  }
}
