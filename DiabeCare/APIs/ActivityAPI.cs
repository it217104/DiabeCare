using DiabeCare.Models;
using DiabeCare.Utilities;
using Newtonsoft.Json;
using System.Text;

namespace DiabeCare.APIs
{
    public class ActivityAPI
    {
        public async Task<ExerciseResponse> GetNatutalExercise(ActivityRequest query)
        {
            string json = string.Empty;
            ExerciseResponse exerciseResponse = new();
            try
            {
                using (HttpClientFactory httpClientFactory = new(UrlAndEndpoints.FoodBaseURL))
                {
                    Uri uri = new Uri(httpClientFactory.client.BaseAddress + UrlAndEndpoints.NaturalExercise);
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
                        exerciseResponse = JsonConvert.DeserializeObject<ExerciseResponse>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error!", $"GetNatutalExercise-{ex.Message}", "OK");
            }
            return exerciseResponse;
        }
    }
}
