namespace DiabeCare.Models
{
    public class SearchInstantResponse
    {
        public List<InstantCommon> common { get; set; }
        public List<Branded> branded { get; set; }
    }
}
