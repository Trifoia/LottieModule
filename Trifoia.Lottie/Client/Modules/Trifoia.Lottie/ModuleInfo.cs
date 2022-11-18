using Oqtane.Models;
using Oqtane.Modules;

namespace Trifoia.Lottie
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Lottie",
            Description = "Lottie",
            Version = "1.0.0",
            ServerManagerType = "Trifoia.Lottie.Manager.LottieManager, Trifoia.Lottie.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "Trifoia.Lottie.Shared.Oqtane",
            PackageName = "Trifoia.Lottie" 
        };
    }
}
