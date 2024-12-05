using Newtonsoft.Json;
using System.Collections;
using System.Net.Http;
using System.Threading.Tasks;


namespace ProductApplication;

public class Program
{
    public static async Task Main(string[] args)
    {
        string webFormUrl = "http://122.187.28.27:81/api/ItemDetailsGetApi"; // Replace with the actual URL of your WebForm page

        string apiBaseUrl = "http://localhost:55987/drRequest.aspx";

        try
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(10);

                HttpResponseMessage response = await client.GetAsync(webFormUrl);
                string content = await response.Content.ReadAsStringAsync();
               
                var formData = new Dictionary<string, string>
                {
                    { "zeeTech", "AllProductList" },
                    { "contentData", content }
                };
                var contentData = new FormUrlEncodedContent(formData);
                HttpResponseMessage apiResponse = await client.PostAsync(apiBaseUrl, contentData);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("WebForm page content:");
                }


                if (apiResponse.IsSuccessStatusCode)
                {
                    string apiContent = await apiResponse.Content.ReadAsStringAsync();

                    Console.WriteLine("data is" + apiContent);
                }
                else
                {
                    Console.WriteLine($"Failed to call the WebForm page. Status code: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex) { Console.WriteLine("error"); }
    }
}