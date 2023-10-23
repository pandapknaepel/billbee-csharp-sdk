namespace Panda.NuGet.BillbeeClient.Model
{
    public class DeletedImages
    {
        public List<long>? Deleted { get; set; }
        public List<long>? NotFound { get; set; }
    }
}
