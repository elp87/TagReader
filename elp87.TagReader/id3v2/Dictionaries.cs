using System.Collections.Generic;

namespace elp87.TagReader.id3v2
{
    public static class Dictionaries
    {
        public static Dictionary<string, FrameTypeInfo> frameIDs = new Dictionary<string, FrameTypeInfo>()
        {
            {"TIT1", new FrameTypeInfo("TIT1", "Content group description", true)},
            {"TIT2", new FrameTypeInfo("TIT2", @"Title/Songname/Content description", true)},
            {"TIT3", new FrameTypeInfo("TIT3", @"Subtitle/Description refinement", true)},
            {"TALB", new FrameTypeInfo("TALB", @"Album/Movie/Show title", true)},
            {"TOAL", new FrameTypeInfo("TOAL", @"Original album/movie/show title", true)},
            {"TRCK", new FrameTypeInfo("TRCK", @"Track number/Position in set", false)},
            {"TPOS", new FrameTypeInfo("TPOS", @"Part of a set", false)},
            {"TSST", new FrameTypeInfo("TSST", @"Set subtitle", true)},
            {"TSRC", new FrameTypeInfo("TSRC", @"ISRC", true)},

            {"TPE1", new FrameTypeInfo("TPE1", @"Lead artist/Lead performer/Soloist/Performing group", true)},
            {"TPE2", new FrameTypeInfo("TPE2", @"Band/Orchestra/Accompaniment", true)},
            {"TPE3", new FrameTypeInfo("TPE3", @"Conductor", true)},
            {"TPE4", new FrameTypeInfo("TPE4", @"Interpreted, remixed, or otherwise modified by", true)},
            {"TOPE", new FrameTypeInfo("TOPE", @"Original artist/performer", true)},
            {"TEXT", new FrameTypeInfo("TEXT", @"Lyricist/Text writer", true)},
            {"TOLY", new FrameTypeInfo("TOLY", @"Original lyricist/text writer", true)},
            {"TCOM", new FrameTypeInfo("TCOM", @"Composer", true)},
            {"TMCL", new FrameTypeInfo("TMCL", @"Musician credits list", true)},
            {"TIPL", new FrameTypeInfo("TIPL", @"Involved people list", true)},
            {"TENC", new FrameTypeInfo("TENC", @"Encoded by", true)}
        };        

        public static Dictionary<string, string> conformityFrame3To4 = new Dictionary<string, string>()
            /* { 
                 { "TYER", "TDRC" } 
             }*/;
    }
}
