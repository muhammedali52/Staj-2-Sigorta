using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EFAppUserDal : GenericRepository<Customer>, IAppUserDal
    {
        public EFAppUserDal(Context context) : base(context)
        {
        }
    }
}
