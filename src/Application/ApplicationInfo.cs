using Microsoft.Extensions.Configuration;

namespace netHelpers.Framework.Application
{
    /// <summary>
    /// Implements <see cref="IApplicationInfo"/>
    /// </summary>
    public class ApplicationInfo : IApplicationInfo
    {
        private readonly IConfiguration _configuration;

        public string Name { get; set; }
        public string Version { get; set; }
        public string Code { get; set; }

        public ApplicationInfo(IConfiguration configuration, string name, string version)
        {
            _configuration = configuration;
            Name = _configuration[name];
            Version = _configuration[version];
        }

        public ApplicationInfo(IConfiguration configuration, string name, string version, string code)
            : this(configuration, name, version)
        {
            Code = _configuration[code];
        }
    }
}
