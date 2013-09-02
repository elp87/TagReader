
namespace elp87.TagReader.id3v2
{
    public class FrameTypeInfo
    {
        public string id { get; set; }
        public string idDescription { get; set; }
        public bool hasEncoding { get; set; }
        public int encogingOffset { get; set; }

        public FrameTypeInfo() { }

        public FrameTypeInfo(string id, string idDescription, bool hasEncoding, int encodingOffset)
        {
            this.id = id;
            this.idDescription = idDescription;
            this.hasEncoding = hasEncoding;
            this.encogingOffset = encogingOffset;
        }

        public FrameTypeInfo(string id, string idDescription, bool hasEncoding)
            : this(id, idDescription, hasEncoding, 1) 
        {
            this.encogingOffset = 1;
        }
    }
}
