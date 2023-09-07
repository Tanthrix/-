using Newtonsoft.Json;

namespace function
{
    public class Jsonka
    {
        public static void Ser<T>(string path, T ato)
        {
            System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(ato));
        }
        public static T Des<T>(string path)
        {
            if (!System.IO.File.Exists(path))
                System.IO.File.WriteAllText(path, "");
            return JsonConvert.DeserializeObject<T>(System.IO.File.ReadAllText(path));
        }
    }
}