using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;

namespace Trifoia.Lottie.Repository
{
    public class LottieContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.Lottie> Lottie { get; set; }

        public LottieContext(ITenantManager tenantManager, IHttpContextAccessor accessor) : base(tenantManager, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
