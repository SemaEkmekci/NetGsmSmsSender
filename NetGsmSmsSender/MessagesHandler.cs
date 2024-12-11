public static class MessagesHandler
{
    public static string HandleError(string responseContent)
    {
        var result = string.Empty;

        switch (responseContent)
        {
            case "20":
                result = "Hata: Mesaj metninde problem var veya maksimum karakter sayısı aşıldı.";
                break;
            case "30":
                result = "Hata: Geçersiz kullanıcı adı, şifre veya API erişim izni yok.";
                break;
            case "40":
                result = "Hata: Mesaj başlığı sistemde tanımlı değil.";
                break;
            case "50":
                result = "Hata: Abone hesabıyla İYS kontrollü gönderim yapılamaz.";
                break;
            case "51":
                result = "Hata: Aboneliğe tanımlı İYS Marka bilgisi bulunamadı.";
                break;
            case "70":
                result = "Hata: Hatalı sorgulama. Parametrelerden biri hatalı veya eksik.";
                break;
            case "85":
                result = "Hata: Mükerrer gönderim sınır aşıldı. Aynı numaraya 1 dakika içinde 20'den fazla gönderim yapılamaz.";
                break;
            case "00":
                result = "Başarı: Görevinizin tarih formatında bir hata yok.";
                break;
            case "01":
                result = "Başarı: Mesaj gönderim başlangıç tarihinde hata var, sistem tarihi ile değiştirilip işleme alındı.";
                break;
            case "02":
                result = "Başarı: Mesaj gönderim sonlandırılma tarihinde hata var. Sistem tarihi ile değiştirilip işleme alındı.";
                break;
            case "347022009":
                result = "Başarı: Gönderdiğiniz SMS başarıyla sistemimize ulaştı. Bu görev ID'si ile sorgulama yapabilirsiniz.";
                break;
            default:
                if (responseContent.StartsWith("00 "))
                {
                    result = "Başarı: Gönderdiğiniz SMS başarıyla sistemimize ulaştı.\n 5 dakika boyunca ard arda gönderdiğiniz SMS'lerin sistemimiz tarafında çoklanarak (biriktirilerek) 1 dakika içerisinde gönderilecektir. Görev (bulkID) bilgisi: " + responseContent.Substring(3);
                }
                else
                {
                    result = "Hata: Bilinmeyen bir hata oluştu. Yanıt: " + responseContent;
                }
                break;
        }

        return result;
    }
}