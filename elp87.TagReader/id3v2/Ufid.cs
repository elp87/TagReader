using System.Text;

namespace elp87.TagReader.id3v2
{
    public class Ufid
    {
        public string owner { get; set; }
        public byte[] id { get; set; }

        public string GetStringID()
        {
            return Encoding.UTF8.GetString(id);
        }
    }
}
