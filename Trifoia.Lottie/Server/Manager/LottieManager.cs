using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Enums;
using Trifoia.Lottie.Repository;

namespace Trifoia.Lottie.Manager
{
    public class LottieManager : MigratableModuleBase, IInstallable, IPortable
    {
        private ILottieRepository _LottieRepository;
        private readonly ITenantManager _tenantManager;
        private readonly IHttpContextAccessor _accessor;

        public LottieManager(ILottieRepository LottieRepository, ITenantManager tenantManager, IHttpContextAccessor accessor)
        {
            _LottieRepository = LottieRepository;
            _tenantManager = tenantManager;
            _accessor = accessor;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new LottieContext(_tenantManager, _accessor), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new LottieContext(_tenantManager, _accessor), tenant, MigrationType.Down);
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Models.Lottie> Lotties = _LottieRepository.GetLotties(module.ModuleId).ToList();
            if (Lotties != null)
            {
                content = JsonSerializer.Serialize(Lotties);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Models.Lottie> Lotties = null;
            if (!string.IsNullOrEmpty(content))
            {
                Lotties = JsonSerializer.Deserialize<List<Models.Lottie>>(content);
            }
            if (Lotties != null)
            {
                foreach(var Lottie in Lotties)
                {
                    _LottieRepository.AddLottie(new Models.Lottie { ModuleId = module.ModuleId, Name = Lottie.Name });
                }
            }
        }
    }
}