using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EFPoliceDal : GenericRepository<Police>, IPoliceDal
    {
        private readonly Context _context;
        public EFPoliceDal(Context context) : base(context)
        {
            _context = context;
        }
    }
}
