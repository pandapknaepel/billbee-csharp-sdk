namespace Panda.NuGet.BillbeeClient.Models
{
    public class DeletedImages
    {
        public List<long>? Deleted { get; set; }
        public List<long>? NotFound { get; set; }
    }
}
