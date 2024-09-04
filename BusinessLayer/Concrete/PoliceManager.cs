using BusinessLayer.Abstract;
using BusinessLayer.Helpers;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class PoliceManager : IPoliceService
    {
        private readonly IPoliceDal _policeDal;

        public PoliceManager(IPoliceDal policeDal)
        {
            _policeDal = policeDal;
        }

        public void TDelete(Police t)
        {
            _policeDal.Delete(t);
        }

        public Police TGetByID(int id)
        {
            return _policeDal.GetByID(id);
        }

        public List<Police> TGetList()
        {
            return _policeDal.GetList();
        }
        public decimal CalculatePolicyAmount(Police police)
        {
            decimal policyAmount = 0;

            // 1. Model Yılına Göre Tutar
            if (police.VehicleYear < 2018)
            {
                policyAmount += 200;
            }
            else
            {
                policyAmount += 250;
            }

            decimal accessoriesTotal = ((police.Lpgamount) + (police.OtherAccessoriesAmount) + (police.TreatmentCosts)) / 5;
            policyAmount += accessoriesTotal;

            // 3. İ.M.M Kademesi Hesaplaması
            decimal immStep = 0;

            immStep = police.ImmCategory / 1000;
            policyAmount += immStep;

            // İndirimleri Uygula
            if (police.InsuredProfession == "Doktor")
            {
                policyAmount *= 0.95m; // %5 indirim
            }
            else if (police.InsuredProfession == "Avukat")
            {
                policyAmount -= immStep * 0.03m; // İ.M.M tutarından %3 indirim
            }
            else if (police.InsuredProfession == "Serbest Meslek")
            {
                policyAmount -= accessoriesTotal * 0.03m; // Aksesuar tutarından %3 indirim
            }

            return policyAmount;
        }
        public void TAdd(Police t)
        {

            t.TotalAmount = CalculatePolicyAmount(t);
            _policeDal.Insert(t);

        }

        public void TUpdate(Police t)
        {
            _policeDal.Update(t);
        }
        public List<Police> TPoliceRide()
        {
            return _policeDal.PoliceRide();
        }
    }
}





