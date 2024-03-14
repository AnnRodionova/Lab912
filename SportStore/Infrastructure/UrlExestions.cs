using System.Runtime.CompilerServices;

namespace SportStore.Infrastructure
{
    public static class UrlExestions
    {
        public static string PathAndQuery (this HttpRequest request)
        {
            return request.QueryString.HasValue?$"{request.Path} {request.QueryString}":
                request.Path.ToString ();
        }
    }
}
