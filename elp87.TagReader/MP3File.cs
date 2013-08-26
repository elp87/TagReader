using elp87.TagReader.id3v2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elp87.TagReader
{
    public class MP3File
    {
        private ID3V2 _id3v2;

        public MP3File()
        {
        }

        public MP3File(string filename)
        {
            _id3v2 = new ID3V2(filename);
        }

        public ID3V2 id3v2
        {
            get
            {
                return _id3v2;
            }
        }
    }
}
