using RestSharp;

namespace BigfootClassinator
{
  class Adapter
  {
    private RestClient client = new RestClient("http://bigfoot-classinator.herokuapp.com");

    public InfoResponse Info()
    {
      var restRequest = BuildInfoRequest();
      var restResponse = client.Execute<InfoResponse>(restRequest);
      return restResponse.Data;
    }

    public ClassinationResponse Classinate(ClassinationRequest request)
    {
      var restRequest = BuildClassinationRequest(request);
      var restResponse = client.Execute<ClassinationResponse>(restRequest);
      return restResponse.Data;
    }

    private RestRequest BuildInfoRequest()
    {
      var restRequest = new RestRequest("info", Method.GET);
      return restRequest;
    }

    private RestRequest BuildClassinationRequest(ClassinationRequest request)
    {
      var restRequest = new RestRequest("classinate", Method.POST);
      restRequest.AddJsonBody(request);
      return restRequest;
    }
  }
}
