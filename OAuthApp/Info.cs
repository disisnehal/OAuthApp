using Microsoft.OpenApi.Models;

namespace OAuthApp
{
    internal class Info : OpenApiInfo
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}