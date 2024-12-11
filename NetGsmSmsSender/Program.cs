class Program
{
    private static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        string apiUrl = "https://api.netgsm.com.tr/sms/send/get/";

        var parameters = new Dictionary<string, string>
        {
            { "usercode", "850XXXXXXX" },
            { "password", "sifre" },
            { "gsmno", "905XXXXXXXXX" },
            { "message", "Deneme mesajıdır." },
            { "msgheader", "BASLIK" },
            { "startdate", "" },
            { "stopdate", "" },
            { "dil", "TR" },
        };

        try
        {
            var formData = new FormUrlEncodedContent(parameters);
            HttpResponseMessage response = await client.PostAsync(apiUrl, formData);

            string responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Yanıt: " + responseContent.ToString() +"\n"+MessagesHandler.HandleError(responseContent));
            }
         
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata: " + ex.Message);
        }
    }
}
