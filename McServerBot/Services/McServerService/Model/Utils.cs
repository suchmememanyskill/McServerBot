using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace JevilNet.Services.Model;

public static class Utils
{
    public async static Task<T> Get<T>(string endPoint)
    {
        using var httpClient = new HttpClient();
        // Please don't steal this url. I pay for this and am too lazy to add auth
        var response = await httpClient.GetAsync($"{Program.API_URL}/{endPoint}");
        response.EnsureSuccessStatusCode();
        return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync())!;
    }
    
    public async static Task Post(string endPoint, object data)
    {
        string strData = JsonConvert.SerializeObject(data);
        using var httpClient = new HttpClient();
        // Please don't steal this url. I pay for this and am too lazy to add auth
        var response = await httpClient.PostAsync($"{Program.API_URL}/{endPoint}", new StringContent(strData, Encoding.Default, "application/json"));

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(await response.Content.ReadAsStringAsync());
        }
    }
    
    public async static Task PostFile(string endPoint, Stream data)
    {
        using var httpClient = new HttpClient();
        // Please don't steal this url. I pay for this and am too lazy to add auth
        using var formData = new MultipartFormDataContent();
        formData.Add(new StreamContent(data), "file", "world.zip");
        var response = await httpClient.PostAsync($"{Program.API_URL}/{endPoint}", formData);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(await response.Content.ReadAsStringAsync());
        }
    }

    public static async Task Put(string endPoint, object data)
    {
        string strData = JsonConvert.SerializeObject(data);
        using var httpClient = new HttpClient();
        // Please don't steal this url. I pay for this and am too lazy to add auth
        var response = await httpClient.PutAsync($"{Program.API_URL}/{endPoint}", new StringContent(strData, Encoding.Default, "application/json"));

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(await response.Content.ReadAsStringAsync());
        }
    }

    public static async Task Delete(string endPoint)
    {
        using var httpClient = new HttpClient();
        // Please don't steal this url. I pay for this and am too lazy to add auth
        var response = await httpClient.DeleteAsync($"{Program.API_URL}/{endPoint}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(await response.Content.ReadAsStringAsync());
        }
    }
}