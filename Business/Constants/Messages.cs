using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MaintenanceTime = "Bakım zamanı";

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
        
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdate = "Müşteri güncellendi";
        public static string CustomersListed = "Müşteriler listelendi";

        public static string RentalAdded = "Kiralama bilgisi eklendi";
        public static string RentalDeleted = "Kiralama bilgisi silindi";
        public static string RentalUpdate = "Kiralama bilgisi güncellendi";
        public static string RentalsListed = "Kiralama bilgileri listelendi";
        public static string RentalReturnDateInvalid = "Teslim tarihi geçersiz";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdate = "Kullanıcı güncellendi";
        public static string UsersListed = "Kullanıcılar listelendi";

        public static string CarImageAdded = "Araba resmi eklendi";
        public static string CarImageUpdated = "Araba resmi güncellendi";
        public static string CarImageDeleted = "Araba resmi silindi";
        public static string CarImagesByCarIdListed = "Seçilen arabaya ait resimler listelendi";
        public static string CarImageLimitExeeded = "Araba başına düşen resim sayısı aşıldı";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kullanıcı kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Başatılı giriş";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "Erişim tokenı oluşturuldu";
    }
}
