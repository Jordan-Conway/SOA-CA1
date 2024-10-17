namespace CA2.Code
{
    public class Data
    {
        private string? _selectedTag;
        private string[]? _tags;

        public string? SelectedTag { get; set; }
        public string[]? Tags { get; set; }

        public Data(string? selectedTag, string[]? tags)
        {
            SelectedTag = selectedTag;
            Tags = tags;
        }
    }
}
