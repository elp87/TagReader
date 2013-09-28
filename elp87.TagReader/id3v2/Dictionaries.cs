using System.Collections.Generic;

namespace elp87.TagReader.id3v2
{
    public static class Dictionaries
    {
        public static Dictionary<string, FrameTypeInfo> frameIDs = new Dictionary<string, FrameTypeInfo>()
        {
            {"TIT1", new FrameTypeInfo("TIT1", "Content group description", true)},
            {"TIT2", new FrameTypeInfo("TIT2", @"Title/Songname/Content description", true)},
            {"TIT3", new FrameTypeInfo("TIT3", @"Subtitle/Description refinement", true)}
        };        

        public static Dictionary<string, string> conformityFrame3To4 = new Dictionary<string, string>()
            /* { 
                 { "TYER", "TDRC" } 
             }*/;
    }
}
