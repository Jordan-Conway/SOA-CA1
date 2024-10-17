namespace CA2.Code
{
	public class Book : Media
	{
		private string? _subtitle;
		private string[]? _authors;
		private MaturityRating? _isMature;
		private string? _image;
		private string? _link;

		public Book(string title)
		{
			Title = title;
			Authors = [];
		}

		public string Subtitle { get; set; }
		public string[] Authors { get; set; }
		public MaturityRating IsMature { get; set; }
		public string Image { get; set; }
		public string Link { get; set; }

	}
}
