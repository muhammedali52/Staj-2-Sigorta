using BusinessLayer.Helpers;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TUpdate(T t);
        void TAdd(T t);
        void TDelete(T t);
        T TGetByID(int id);
        List<T> TGetList();

        public List<Police> TPoliceRide();
    }
}
