using RestSharp;

namespace BigfootClassinator
{
  class Adapter
  {
    private const string BaseUrl = "http://bigfoot-classinator.herokuapp.com";
    private RestClient client = new RestClient(BaseUrl);

    public ClassinationResponse ClassinateSighting(ClassinationRequest request)
    {
      var restRequest = BuildClassinationRequest(request);
      var restResponse = client.Execute<ClassinationResponse>(restRequest);
      return restResponse.Data;
    }

    private RestRequest BuildClassinationRequest(ClassinationRequest request)
    {
      var restRequest = new RestRequest("classinate", Method.POST);
      restRequest.AddJsonBody(request);

      return restRequest;
    }
  }
}