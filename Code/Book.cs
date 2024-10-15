namespace CA2.Code
{
	public class Book
	{
		private string _title;
		private string? _subtitle;
		private string[]? _authors;
		private bool? _isMature;
		private string? _image;
		private string? _link;

		public Book(string title)
		{
			_title = title;
		}

		public string Title { get; set; }
		public string Subtitle { get; set; }
		public string[] Authors { get; set; }
		public bool IsMature { get; set; }
		public string Image { get; set; }
		public string Link { get; set; }

	}
}
