using DiabeCare.Models;
using DiabeCare.Utilities;
using Newtonsoft.Json;
using RestSharp;
using System.Xml.Serialization;

namespace DiabeCare.APIs
{
    public class MedicineAPI
    {
        public async Task<DrugGroup> GetMedicine(string name)
        {
            string json = string.Empty;
            Rxnormdata rxnormdata = new();
            DrugGroup drugGroup = new();
            try
            {
                string url = $"{UrlAndEndpoints.MedicineBaseURL}{UrlAndEndpoints.PrescribeDrugs}={name}";
                var client = new RestClient(url);
                var request = new RestRequest
                {
                    Method = Method.Get
                };
                RestResponse response = client.Execute(request);
                json = response.Content;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Rxnormdata));
                    using (StringReader reader = new StringReader(json))
                    {
                        rxnormdata = (Rxnormdata)serializer.Deserialize(reader);
                    }
                    if(rxnormdata != null && rxnormdata.DrugGroup != null &&
                        rxnormdata.DrugGroup.ConceptGroup.Count>0)
                    {
                        drugGroup = rxnormdata.DrugGroup;
                    }
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error!", $"GetMedicine-{ex.Message}", "OK");
            }
            return drugGroup;
        }
    }
}
