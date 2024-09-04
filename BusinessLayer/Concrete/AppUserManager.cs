using BusinessLayer.Abstract;
using BusinessLayer.Helpers; // Result sınıfının bulunduğu namespace
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void TDelete(Customer t)
        {
            _appUserDal.Delete(t);
        }

        public Customer TGetByID(int id)
        {
            return _appUserDal.GetByID(id);
        }

        public List<Customer> TGetList()
        {
            return _appUserDal.GetList();
        }
        private bool IsTcNumberUnique(string tcNumber)
        {
            return !_appUserDal.GetList().Any(u => u.IdentityNumber == tcNumber);
        }
        public void TAdd(Customer t)
        {
            if (!IsTcNumberUnique(t.IdentityNumber))
            {
                throw new InvalidOperationException("Bu TC kimlik numarası zaten mevcut.");
            }

            _appUserDal.Insert(t);
        }


        public void TUpdate(Customer t)
        {
            _appUserDal.Update(t);
        }

        public List<Police> TPoliceRide()
        {
            throw new NotImplementedException();
        }
    }
}
