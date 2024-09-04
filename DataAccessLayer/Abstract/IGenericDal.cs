using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T>
    {
        void Update(T t);
        void Insert(T t);
        void Delete(T t);
        T GetByID(int id);
        List<T> GetList();

        public List<Police> PoliceRide();
    }
}
