using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BigfootClassinator
{
  public class Adapter
  {
    private static readonly HttpClient client = new HttpClient();

    public Adapter() {
      // client.BaseAddress = new Uri("http://bigfoot-classinator.herokuapp.com");
      client.BaseAddress = new Uri("http://localhost:5000");
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<string> FetchInfo()
    {
      var response = await client.GetAsync("info");
      response.EnsureSuccessStatusCode();
      var json = await response.Content.ReadAsStringAsync();
      return json;
    }

    public async Task<string> ClassinateSighting(string request)
    {
      HttpContent content = new StringContent(request, Encoding.UTF8, "application/json");
      var response = await client.PostAsync("classinate", content);
      response.EnsureSuccessStatusCode();
      var json = await response.Content.ReadAsStringAsync();
      return json;
    }
  }
}
