using Panda.NuGet.BillbeeClient.Enums;

namespace Panda.NuGet.BillbeeClient.Model
{
    public class LayoutTemplate
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ReportTemplates Type { get; set; }
    }
}