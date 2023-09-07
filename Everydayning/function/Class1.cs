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
                System.IO.File.Create(path);
            return JsonConvert.DeserializeObject<T>(System.IO.File.ReadAllText(path));
        }
        public static void Write(int a)
        {
            System.IO.File.WriteAllText("cena.json", $"let a = {a}");
        }
        public static int Read()
        {
            if (!File.Exists("cena.json"))
                File.WriteAllText("cena.json", "");
            string s = System.IO.File.ReadAllText("cena.json");
            if (s == null || s == "")
                return 0;
            string h = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '=' && s[i + 1] == ' ')
                {
                    for (int j = i + 2; j < s.Length; j++)
                    {
                        h += s[j];
                    }
                    break;
                }
            }
            return Convert.ToInt32(h);
        }
    }
}