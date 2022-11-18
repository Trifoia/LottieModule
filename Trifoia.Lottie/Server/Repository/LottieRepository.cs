using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using Trifoia.Lottie.Models;

namespace Trifoia.Lottie.Repository
{
    public class LottieRepository : ILottieRepository, ITransientService
    {
        private readonly LottieContext _db;

        public LottieRepository(LottieContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.Lottie> GetLotties(int ModuleId)
        {
            return _db.Lottie.Where(item => item.ModuleId == ModuleId);
        }

        public Models.Lottie GetLottie(int LottieId)
        {
            return GetLottie(LottieId, true);
        }

        public Models.Lottie GetLottie(int LottieId, bool tracking)
        {
            if (tracking)
            {
                return _db.Lottie.Find(LottieId);
            }
            else
            {
                return _db.Lottie.AsNoTracking().FirstOrDefault(item => item.LottieId == LottieId);
            }
        }

        public Models.Lottie AddLottie(Models.Lottie Lottie)
        {
            _db.Lottie.Add(Lottie);
            _db.SaveChanges();
            return Lottie;
        }

        public Models.Lottie UpdateLottie(Models.Lottie Lottie)
        {
            _db.Entry(Lottie).State = EntityState.Modified;
            _db.SaveChanges();
            return Lottie;
        }

        public void DeleteLottie(int LottieId)
        {
            Models.Lottie Lottie = _db.Lottie.Find(LottieId);
            _db.Lottie.Remove(Lottie);
            _db.SaveChanges();
        }
    }
}
