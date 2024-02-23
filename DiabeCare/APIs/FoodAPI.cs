using DiabeCare.Models;
using DiabeCare.Utilities;
using Newtonsoft.Json;
using System.Text;

namespace DiabeCare.APIs
{
    public class FoodAPI
    {
        public async Task<SearchInstantResponse> GetSearchInstant(string food)
        {
            string json = string.Empty;
            SearchInstantResponse searchInstantResponse = new();
            try
			{
                using (HttpClientFactory httpClientFactory = new(UrlAndEndpoints.FoodBaseURL))
                {
                    string url = $"{UrlAndEndpoints.SearchInstant}={food}";
                    HttpResponseMessage response = await httpClientFactory.GetAsync(url);
                    json = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        searchInstantResponse = JsonConvert.DeserializeObject<SearchInstantResponse>(json);
                    }
                }
            }
			catch (Exception ex)
			{
                await App.Current.MainPage.DisplayAlert("Error!", $"GetSearchInstant-{ex.Message}", "OK");
            }
            return searchInstantResponse;
        }

        public async Task<NutrientsResponse> GetSearchItem(string upc)
        {
            string json = string.Empty;
            NutrientsResponse nutrientsResponse = new();
            try
            {
                using (HttpClientFactory httpClientFactory = new(UrlAndEndpoints.FoodBaseURL))
                {
                    string url = $"{UrlAndEndpoints.SearchItem}={upc}";
                    HttpResponseMessage response = await httpClientFactory.GetAsync(url);
                    json = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        nutrientsResponse = JsonConvert.DeserializeObject<NutrientsResponse>(json);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return nutrientsResponse;
        }

        public async Task<NutrientsResponse> GetNatutalNutrients(Query query)
        {
            string json = string.Empty;
            NutrientsResponse nutrientsResponse = new();
            try
            {
                using (HttpClientFactory httpClientFactory = new(UrlAndEndpoints.FoodBaseURL))
                {
                    Uri uri = new Uri(httpClientFactory.client.BaseAddress + UrlAndEndpoints.NaturalNutrients);
                    httpClientFactory.client.DefaultRequestHeaders.Add("x-app-id", "f3b183b2");
                    httpClientFactory.client.DefaultRequestHeaders.Add("x-app-key", "c867026f03710c309835b5b2d254e4dc");
                    string userString = JsonConvert.SerializeObject(query);
                    StringContent str = new StringContent(userString, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClientFactory.client.PostAsync(uri, str);
                    json = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK ||
                        response.StatusCode == System.Net.HttpStatusCode.Created ||
                        response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        nutrientsResponse = JsonConvert.DeserializeObject<NutrientsResponse>(json);
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
            return nutrientsResponse;
        }
    }
}
