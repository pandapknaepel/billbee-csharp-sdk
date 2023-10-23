using System.Net;

namespace Panda.NuGet.BillbeeClient.Exceptions;

public class BillbeeHttpException : Exception
{
    public BillbeeHttpException(string caller, HttpStatusCode statusCode, string? contentStr) : base(
        $"Panda.NuGet.BillbeeClient | {caller} - Unexpected HTTP Status Code: " + statusCode)
    {
        StatusCode = statusCode;
        ContentStr = contentStr;
    }

    public string? ContentStr { get; set; }

    public HttpStatusCode StatusCode { get; set; }
}