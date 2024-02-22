namespace WebAppBook.Models
{
    public class SD
    {
        public static string BookAPIBase { get; set; }

        public enum ApiType
        {
            GET, POST, PUT, DELETE
        }

        public enum ContentType
        {
            Json,
            MultipartFormData,
        }
    }
}
