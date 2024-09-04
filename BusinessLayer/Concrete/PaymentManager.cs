using BusinessLayer.Abstract;
using BusinessLayer.Helpers;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public void TDelete(Payment t)
        {
            _paymentDal.Delete(t);
        }

        public Payment TGetByID(int id)
        {
            return _paymentDal.GetByID(id);
        }

        public List<Payment> TGetList()
        {
            return _paymentDal.GetList();
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
            if (!string.IsNullOrEmpty(police.VehicleBrandCode))
            {
                if (decimal.TryParse(police.VehicleBrandCode, out decimal brandCodeValue))
                {
                    immStep = brandCodeValue / 1000;
                }
            }
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

        public void TAdd(Payment t)
        {
            // Police kaydı üzerinden poliçe tutarını hesapla
            var police = t.Police; // İlişkili Police nesnesini al
            t.Amount = CalculatePolicyAmount(police);

            _paymentDal.Insert(t);
        }

        public void TUpdate(Payment t)
        {
            // Police kaydı üzerinden poliçe tutarını hesapla
            var police = t.Police; // İlişkili Police nesnesini al
            t.Amount = CalculatePolicyAmount(police);
            _paymentDal.Update(t);
        }

        public List<Police> TPoliceRide()
        {
            throw new NotImplementedException();
        }
    }
}
