using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Message
    {
        public static string CarAdded = "Yeni Araç Eklendi!";
        public static string CarDeleted = "Araç Silindi!";
        public static string CarUpdated = "Araç Bilgileri Güncellendi!";
        public static string BrandAdded = "Yeni Marka Eklendi!";
        public static string BrandNameInvalid = "Marka Adı En Az 2 Karakte Olmalıdır";
        public static string BrandUpdated = "Marka Bilgisi Güncellendi!";
        public static string BrandDeleted = "Marka Silindi!";
        public static string ColorAdded = "Yeni Renk Eklendi!";
        public static string ColorDeleted = "Renk Silindi!";
        public static string ColorUpdated = "Renk Bilgileri Güncellendi!";
        public static string AllColors = "Tüm Renkler Listelendi";
        public static string CustomerAdded = "Yeni Müşteri Eklendi!";
        public static string CustomerDeleted = "Müşteri Silindi!";
        public static string CustomerUpdated = "Müşteri Bilgileri Güncellendi!";
        public static string CarUnavailable = "Araç Müsait Değil";
        public static string RentalAdded = "Araç Kiralandı";
        public static string RentalDeleted = "Kiralama Kaydı Silindi!";
        public static string RentalUpdated = "Kiralama Kaydı Güncellendi!";
        public static string CarReturn = "Araç Teslim Alındı";
        public static string CarReturnError = "Araç Teslim Kaydı Oluşturulamadı.Bilgileri Kontrol Ediniz!";
        public static string CarImageAdded = "Araç İçin Resim Eklendi";
        public static string CarImageDeleted = "Araç Resmi Silindi";
        public static string CarImageUpdated = "Araç Resmi Güncellendi";
        public static string CarImageLimitExceded = "Bir Araç İçin En Fazla 5 Resim Eklenebilir";
        public static string CarImageCantAdded = "Araç Resmi Eklenemedi. Lütfen bilgileri kontrol ediniz.";
        public static string AuthorizationDenied = "Yetkiniz Yok.";
        public static string UserRegistered = "Kayıt İşlemi Gerçekleşti.";
        public static string UserNotFound = "Kullanıcı Bulunamadı.";
        public static string PasswordError = "Parola Hatalı";
        public static string UserAlreadyExists = "Kullanıcı Mevcut";
        public static string SuccessfulLogin = "Bağlanma Başarılı";
        public static string AccessTokenCreated = "AccessToken Üretildi";
        public static string UserAdded= "Kullanıcı Eklendi.";
        public static string CarImageNotSuitable = "Resim Ekleme İşlemi İçin Uygun Değil";
    }
}
