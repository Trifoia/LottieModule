using System.Collections.Generic;
using System.Threading.Tasks;
using Trifoia.Lottie.Models;

namespace Trifoia.Lottie.Services
{
    public interface ILottieService 
    {
        Task<List<Models.Lottie>> GetLottiesAsync(int ModuleId);

        Task<Models.Lottie> GetLottieAsync(int LottieId, int ModuleId);

        Task<Models.Lottie> AddLottieAsync(Models.Lottie Lottie);

        Task<Models.Lottie> UpdateLottieAsync(Models.Lottie Lottie);

        Task DeleteLottieAsync(int LottieId, int ModuleId);
    }
}
