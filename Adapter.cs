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

    public ClassinationResponse Classinate(ClassinationRequest classinationRequest)
    {
      var restRequest = BuildClassinationRequest(classinationRequest);
      var restResponse = client.Execute<ClassinationResponse>(restRequest);
      return restResponse.Data;
    }

    private RestRequest BuildInfoRequest()
    {
      var restRequest = new RestRequest("info", Method.GET);
      return restRequest;
    }

    private RestRequest BuildClassinationRequest(ClassinationRequest classinationRequest)
    {
      var restRequest = new RestRequest("classinate", Method.POST);
      restRequest.AddJsonBody(classinationRequest);
      return restRequest;
    }
  }
}
