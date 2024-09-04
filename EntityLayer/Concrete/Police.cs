using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Police
    {
        [Key]
        public int PoliceID { get; set; }


        [Required(ErrorMessage = "Bu Alan zorunlu")]
        public string Code { get; set; }

        [MaxLength(50,ErrorMessage ="isim alanı en fazla 50 karekter olmalıdır.")]
        [MinLength(3,ErrorMessage ="isim alanı en az 3 karekter olmalıdır.")]
        [Required(ErrorMessage = "Bu Alan zorunlu")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Bu Alan zorunlu")]
        public DateTime StartDate { get; set; }


        [Required(ErrorMessage = "Bu Alan zorunlu")]
        public DateTime EndDate { get; set; }


        [Required(ErrorMessage = "Bu Alan zorunlu")]
        public string VhiclePlate { get; set; }
        //plaka

        [Required(ErrorMessage = "Bu Alan zorunlu")]
        public string VehicleBrandCode { get; set; }
        //marka kodu

        [Required(ErrorMessage = "Bu Alan zorunlu")]
        public string VehicleBrand { get; set; }
        //marka

        [Required(ErrorMessage = "Bu Alan zorunlu")]
        public string VehicleModel { get; set; }
        //model

        [Required(ErrorMessage = "Bu Alan zorunlu")]
        public int VehicleYear { get; set; }
        //yılı

        [Required(ErrorMessage = "Bu Alan zorunlu")]
        public string VehicleType { get; set; }
        //tipi

        [Required(ErrorMessage = "Bu Alan zorunlu")]
        public decimal Lpgamount { get; set; }
        //lpg fiyatı

        [Required(ErrorMessage = "Bu Alan zorunlu")]
        public decimal OtherAccessoriesAmount { get; set; }
        //diğer aksesuarlar

        [Required(ErrorMessage = "Bu Alan zorunlu")]
        public decimal TreatmentCosts { get; set; }
        //tedavi maliyeti

        [Required(ErrorMessage = "Bu Alan zorunlu")]
        public decimal ImmCategory { get; set; }


        [Required(ErrorMessage = "Bu Alan zorunlu")]
        public string InsuredProfession { get; set; }
        //mesleği

        [Required(ErrorMessage = "Bu Alan zorunlu")]
        public decimal TotalAmount { get; set; }
        //toplam fiyat
        public int? CustomerID { get; set; }
        public Customer Customer { get; set; }

    }
}
