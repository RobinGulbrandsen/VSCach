namespace CachProjectConsole.Models
{
    public class FlickrPhotoSizesModel
    {
        public string Large { set; get; }
        public string LargeSquare { set; get; }
        public string Original { set; get; }
        public string Thumbnail { set; get; }

        public FlickrPhotoSizesModel() { }
        public FlickrPhotoSizesModel(FlickrPhotoSizes sizes)
        {
            foreach (var s in sizes.Size)
            {
                if (s.Label.Equals("Large"))
                {
                    Large = s.Source;
                }
                if (s.Label.Equals("Large Square"))
                {
                    LargeSquare = s.Source;
                }
                if (s.Label.Equals("Original"))
                {
                    Original = s.Source;
                }
                if (s.Label.Equals("Thumbnail"))
                {
                    Thumbnail = s.Source;
                }
            }
        }
    }
}
