using RestSharp;
using System.Web;
using static System.Net.WebRequestMethods;

namespace CA2.Code
{
	public class YoutubeService
	{
		static readonly string URL = "https://www.googleapis.com/youtube/v3/videos?";
		static RestClient Client = new RestClient(URL);

		ConfigurationBuilder ConfigurationBuilder = new ConfigurationBuilder();
		IConfiguration Configuration;
		private readonly string API_KEY;

		public YoutubeService() 
		{
			IConfiguration configuration = ConfigurationBuilder.AddUserSecrets<Program>().Build();
			API_KEY = configuration.GetSection("google")["GoogleApiKey"];
		}

		public RestResponse getVideo(string videoUrl)
		{
			//Sample request
			//https://www.googleapis.com/youtube/v3/videos?key={API-key}&fields=items(snippet(title,description,tags))&part=snippet&id={video_id}
			//Sample video
			//https://www.youtube.com/watch?v=_2cbf1ixygk

			//Parse url to get video id
			Uri youtubeUri = new Uri(videoUrl);
			string videoID = HttpUtility.ParseQueryString(youtubeUri.Query).Get("v");

			Console.WriteLine(youtubeUri);
			Console.WriteLine($"v = {videoID }");

			var request = new RestRequest();

			request.AddParameter("key", API_KEY);
			request.AddParameter("fields", "items(snippet(title,tags))");
			request.AddParameter("part", "snippet");
			request.AddParameter("id", videoID);

			Console.WriteLine(request);

			return Client.Execute(request);
		}
	}
}
