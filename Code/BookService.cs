using Microsoft.Extensions.Configuration;
using RestSharp;

namespace CA2.Code
{
	public class BookService
	{
		static readonly string URL = "https://www.googleapis.com/books/v1/volumes?";
		static RestClient client = new RestClient(URL);



		public BookService()
		{
			
		}

		public RestResponse? getBooks(string tag)
		{
			var request = new RestRequest();
			request.AddParameter("q", tag);
			var response = client.Execute(request);

			return response;
		}
	}
}
