using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace CA2.Code
{
	public class BookService
	{
		static readonly string URL = "https://www.googleapis.com/books/v1/volumes?";
		static RestClient Client = new RestClient(URL);



		public BookService()
		{
			
		}

		public RestResponse? getBooks(string tag)
		{
			var request = new RestRequest();
			request.AddParameter("q", tag);
			var response = Client.Execute(request);

			return response;
		}

		public Book[] parseRespone(JObject jsonObject)
		{
			var books = new List<Book>();

			try
			{
				var items = jsonObject["items"];
				if (items == null) {
					return books.ToArray<Book>();
				}
				foreach(var item in items)
				{
					JToken? title = item["volumeInfo"]["title"];
					JToken? subtitle = item["volumeInfo"]["subtitle"];
					JToken? authors = item["volumeInfo"]["authors"];
					JToken? isMature = item["volumeInfo"]["maturityRating"];
					JToken? image = item["volumeInfo"]["imageLinks"]["thumbnail"];
					JToken? link = item["volumeInfo"]["infoLink"];

					Book newBook;
					if (title != null)
					{
						newBook = new Book(title.ToObject<string>());
					}
					else
					{
						//A book must have a title. If none is provided, we skip it
						continue;
					}

					newBook.Subtitle = subtitle == null ? "" : subtitle.ToObject<string>();
					newBook.Authors = authors == null ? new List<String>().ToArray() : authors.ToObject<string[]>();
					
					if(isMature == null)
					{
						newBook.IsMature = MaturityRating.NA;
					}
					else if(isMature.ToObject<string>().Equals("NOT_MATURE"))
					{
						newBook.IsMature = MaturityRating.NOTMATURE;
					}
					else
					{
						newBook.IsMature = MaturityRating.MATURE;
					}

					newBook.Image = image == null ? "" : image.ToObject<string>();
					newBook.Link = link == null ? "" : link.ToObject<string>();

					books.Add(newBook);
				}
			}
			catch(NullReferenceException e)
			{
				Console.WriteLine("Encountered exception while parsing books");
				Console.WriteLine(e.Message);
			}

			return books.ToArray<Book>();
		}
	}
}
