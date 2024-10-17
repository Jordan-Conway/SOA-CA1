namespace CA2.Code
{
	public class Video : Media
	{
		private string? _description;
		private string[]? _tags;

		public Video(string title)
		{
			Title = title;
		}

		public string Description { get; set; }
		public string[] Tags { get; set; }
	}
}
