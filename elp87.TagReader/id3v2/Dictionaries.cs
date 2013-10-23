using System.Collections.Generic;

namespace elp87.TagReader.id3v2
{
    /// <summary>
    /// Provides dictionaries for work with id3v2 tags
    /// </summary>
    public static class Dictionaries
    {
        /// <summary>
        /// Dictionary of supported frame types
        /// </summary>
        public static Dictionary<string, FrameTypeInfo> frameIDs = new Dictionary<string, FrameTypeInfo>()
        {
            {"TIT1", new FrameTypeInfo("TIT1", "Content group description")},
            {"TIT2", new FrameTypeInfo("TIT2", @"Title/Songname/Content description")},
            {"TIT3", new FrameTypeInfo("TIT3", @"Subtitle/Description refinement")},
            {"TALB", new FrameTypeInfo("TALB", @"Album/Movie/Show title")},
            {"TOAL", new FrameTypeInfo("TOAL", @"Original album/movie/show title")},
            {"TRCK", new FrameTypeInfo("TRCK", @"Track number/Position in set")},
            {"TPOS", new FrameTypeInfo("TPOS", @"Part of a set")},
            {"TSST", new FrameTypeInfo("TSST", @"Set subtitle")},
            {"TSRC", new FrameTypeInfo("TSRC", @"ISRC")},

            {"TPE1", new FrameTypeInfo("TPE1", @"Lead artist/Lead performer/Soloist/Performing group")},
            {"TPE2", new FrameTypeInfo("TPE2", @"Band/Orchestra/Accompaniment")},
            {"TPE3", new FrameTypeInfo("TPE3", @"Conductor")},
            {"TPE4", new FrameTypeInfo("TPE4", @"Interpreted, remixed, or otherwise modified by")},
            {"TOPE", new FrameTypeInfo("TOPE", @"Original artist/performer")},
            {"TEXT", new FrameTypeInfo("TEXT", @"Lyricist/Text writer")},
            {"TOLY", new FrameTypeInfo("TOLY", @"Original lyricist/text writer")},
            {"TCOM", new FrameTypeInfo("TCOM", @"Composer")},
            {"TMCL", new FrameTypeInfo("TMCL", @"Musician credits list")},
            {"TIPL", new FrameTypeInfo("TIPL", @"Involved people list")},
            {"TENC", new FrameTypeInfo("TENC", @"Encoded by")},

            {"TBPM", new FrameTypeInfo("TBPM", @"BPM")},
            {"TLEN", new FrameTypeInfo("TLEN", @"Length")},
            {"TKEY", new FrameTypeInfo("TKEY", @"Initial key")},
            {"TLAN", new FrameTypeInfo("TLAN", @"Language")},
            {"TCON", new FrameTypeInfo("TCON", @"Content type")},
            {"TFLT", new FrameTypeInfo("TFLT", @"File type")},
            {"TMED", new FrameTypeInfo("TMED", @"Media type")},
            {"TMOO", new FrameTypeInfo("TMOO", @"Mood")},

            {"TCOP", new FrameTypeInfo("TCOP", @"Copyright message")},
            {"TPRO", new FrameTypeInfo("TPRO", @"Produced notice")},
            {"TPUB", new FrameTypeInfo("TPUB", @"Publisher")},
            {"TOWN", new FrameTypeInfo("TOWN", @"File owner/licensee")},
            {"TRSN", new FrameTypeInfo("TRSN", @"Internet radio station name")},
            {"TRSO", new FrameTypeInfo("TRSO", @"Internet radio station owner")},

            {"TOFN", new FrameTypeInfo("TOFN", @"Original filename")},
            {"TDLY", new FrameTypeInfo("TDLY", @"Playlist delay")},
            {"TDEN", new FrameTypeInfo("TDEN", @"Encoding time")},
            {"TDOR", new FrameTypeInfo("TDOR", @"Original release time")},
            {"TDRC", new FrameTypeInfo("TDRC", @"Recording time")},
            {"TDRL", new FrameTypeInfo("TDRL", @"Release time")},
            {"TDTG", new FrameTypeInfo("TDTG", @"Tagging time")},
            {"TSSE", new FrameTypeInfo("TSSE", @"Software/Hardware and settings used for encoding")},
            {"TSOA", new FrameTypeInfo("TSOA", @"Album sort order")},
            {"TSOP", new FrameTypeInfo("TSOP", @"Performer sort order")},
            {"TSOT", new FrameTypeInfo("TSOT", @"Title sort order")},

            {"TXXX", new FrameTypeInfo("TXXX", @"User defined text information")},

            {"WCOM", new FrameTypeInfo("WCOM", @"Commercial information")},
            {"WCOP", new FrameTypeInfo("WCOP", @"Copyright/Legal information")},
            {"WOAF", new FrameTypeInfo("WOAF", @"Official audio file webpage")},
            {"WOAR", new FrameTypeInfo("WOAR", @"Official artist/performer webpage")},
            {"WOAS", new FrameTypeInfo("WOAS", @"Official audio source webpage")},
            {"WORS", new FrameTypeInfo("WORS", @"Official Internet radio station homepage")},
            {"WPAY", new FrameTypeInfo("WPAY", @"Payment")},
            {"WPUB", new FrameTypeInfo("WPUB", @"Publishers official webpage")},

            {"WXXX", new FrameTypeInfo("WXXX", @"User defined URL link")},

            {"UFID", new FrameTypeInfo("UFID", @"Unique file identifier")},
            {"MCDI", new FrameTypeInfo("MCDI", @"Music CD identifier")},

            {"USLT", new FrameTypeInfo("USLT", @"Unsynchronised lyrics/text transcription")},
            {"COMM", new FrameTypeInfo("COMM", @"Comments")},

            {"APIC", new FrameTypeInfo("APIC", @"Attached picture")},
            {"PRIV", new FrameTypeInfo("PRIV", @"Private frame")},
        };

        internal static Dictionary<string, string> conformityFrame3To4 = new Dictionary<string, string>()
            /* { 
                 { "TYER", "TDRC" } 
             }*/;
    }
}
