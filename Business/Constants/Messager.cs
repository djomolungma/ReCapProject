using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messager
    {
        public static string CarAdded = "Araba eklendi";//public değişkenler büyük harf ile başlar, privetlar küçük harf ile başlar
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarsListed = "Arabalar listelendi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string CarDailyPriceInvalid = "Araba günlük fiyat geçersiz";
        public static string CarsWithDetailsListed = "Arabalar detaylı olarak listelendi";
        public static string CarsByBrandIdListed = "Arabalar markaya göre listelendy";
        public static string CarsByColorIdListed = "Arabalar renge göre listelendy";
        public static string CarsByDailyPriceListed = "Arabalar günlük fiyata göre listelendi";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandsListed = "Markalar listelendi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorsListed = "Renkler listelendi";

        public static string ModelAdded = "Model eklendi";
        public static string ModelDeleted = "Model silindi";
        public static string ModelUpdated = "Model güncellendi";
        public static string ModelsListed = "Modeller listelendi";

        public static string MaintenanceTime = "Bakım zamanı";
        
    }
}
