namespace DiabeCare.APIs
{
    public class UrlAndEndpoints
    {
        public const string FoodBaseURL = "https://trackapi.nutritionix.com/v2/";
        public const string MedicineBaseURL = "https://rxnav.nlm.nih.gov/REST/";

        public static string NaturalNutrients = "natural/nutrients";
        public static string SearchInstant = "search/instant/?query";
        public static string SearchItem = "search/item/?upc";

        public static string NaturalExercise = "natural/exercise";

        public static string PrescribeDrugs = "Prescribe/drugs.xml?name";
    }
}
