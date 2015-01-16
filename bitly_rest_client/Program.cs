using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace bitly_rest_client {
    class Program {
        static void Main(string[] args) {
            RunAsync().Wait();
        }

        static async Task RunAsync() {
            //bitly api setup
            const string Login = "your_login";
            const string ApiKey = "your_api_key";
            const string Domain = "http://api-ssl.bitly.com/v3/shorten";
            
            //need trailing slash for url parameters to work properly
            const string Url = "http://www.some_url_to_shorten.com/oh_yea/";
            var urlParameters = "?date=" + DateTime.Now.ToString("MMddyyyy") +"&make=4444";

            var bitlyUrl = "?longUrl=" + Url + urlParameters + "&format=json&login=" + Login + "&apiKey=" + ApiKey;
          
            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(Domain);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(bitlyUrl);
                if (response.IsSuccessStatusCode) {
                    var urlsShortened = await response.Content.ReadAsAsync<BitlyUrl>();
                    Console.WriteLine(urlsShortened.data.url);
                }
            }
        }
    }
}
