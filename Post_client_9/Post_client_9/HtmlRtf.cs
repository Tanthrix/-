using Spire.Doc;
using System.IO;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Documents;

namespace HtmlRtf
{
    internal class HtmlRtfConverter
    {
        public static void ToRtf(string html)
        {
            try
            {
                File.WriteAllText("msg.html", html);
                var d = new Spire.Doc.Document("msg.html", FileFormat.Html);
                d.SaveToFile("msg.rtf", FileFormat.Rtf);
                d.Close();
                File.Delete("msg.html");
            }
            catch {
                MessageBox.Show("Сообщение невозможно прочитать из-за неверного формата письма");
            }
        }

        public static void ToHtml(TextRange rtf)
        {
            var fs = new FileStream("send.rtf", FileMode.Create);
            rtf.Save(fs, DataFormats.Rtf);
            fs.Close();
            var d = new Spire.Doc.Document("send.rtf", FileFormat.Rtf);
            d.SaveToFile("send.html", FileFormat.Html);
            d.Close();
            File.Delete("send.rtf");
        }
    }
}
