using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elp87.TagReader.id3v2
{
    public static class Dictionaries
    {
        public static Dictionary<string, FrameTypeInfo> frameIDs = new Dictionary<string, FrameTypeInfo>()
        {
            {"TALB", new FrameTypeInfo("TALB", "album", true)},
            {"TDRC", new FrameTypeInfo("TDRC", "year", true)},
            {"TIT2", new FrameTypeInfo("TIT2", "title", true)},
            {"TPE1", new FrameTypeInfo("TPE1", "performer", true)},
            {"TRCK", new FrameTypeInfo("TRCK", "trackNumber", true)}
        };

        public static Dictionary<string, string> conformityFrame3To4 = new Dictionary<string, string>() 
        { 
            { "TYER", "TDRC" } 
        };
    }
}
