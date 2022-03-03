using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.Swagger;

namespace ManageAmericaAPI
{
    internal class OpenApiInfo : Info
    {
        public string Title { get; set; }
        public string Version { get; set; }
        public string Description { get; internal set; }
    }
}