namespace CloudRestaurant.Shared.Configs
{
    public class AppSettings
    {
        // TODO: Bind to app settings.json and remove static
        public static string MongoConnectionString { get; set; } = "mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&directConnection=true&ssl=false";
    }
}
