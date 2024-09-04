using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPoliceService:IGenericService<Police>
    {

        public decimal CalculatePolicyAmount(Police police);
        public List<Police> TPoliceRide();

    }
}
