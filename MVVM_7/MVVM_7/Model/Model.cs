using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_7.Model
{
    internal class User
    {
        public string Name { get; set; }
        public string Type { get; set; }
        private int Money;
        public int money
        {
            get { return Money; }
            set
            {
                Money = Math.Abs(value);
            }
        }
        public bool isincome { get; set; }
        public DateTime? data;

        public User(DateTime? selectedDate, string text1, string v, int text2, bool isin)
        {
            data = selectedDate;
            Name = text1;
            Type = v;
            money = text2;
            isincome = isin;
        }
    }
    internal class Jsonka
    {
        public static void Ser<T>(string path, T ato)
        {
            System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(ato));
        }
        public static T Des<T>(string path)
        {
            if (!System.IO.File.Exists(path))
                File.WriteAllText(path, "");
            return JsonConvert.DeserializeObject<T>(System.IO.File.ReadAllText(path));
        }
    }
}
