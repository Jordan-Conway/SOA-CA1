namespace CA2.Code
{
	public class Video
	{
		private string _title;
		private string _description;
		private string[] _tags;

		public Video(string title)
		{
			_title = title;
		}

		public string Title { get; set; }
		public string Description { get; set; }
		public string[] Tags { get; set; }
	}
}
