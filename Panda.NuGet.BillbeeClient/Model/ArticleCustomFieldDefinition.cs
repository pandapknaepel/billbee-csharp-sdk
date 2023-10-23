namespace Panda.NuGet.BillbeeClient.Model
{
    public enum ApiArticleCustomFieldType
    {
        TextField,
        Textarea,
        NumberInput,
        SelectInput,
    }

    public class ArticleCustomFieldDefinition
    {
        public long? Id;

        public string Name;

        public object Configuration;

        public ApiArticleCustomFieldType? Type;

        public bool IsNullable;
    }
}
