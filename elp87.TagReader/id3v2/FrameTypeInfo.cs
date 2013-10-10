
namespace elp87.TagReader.id3v2
{
    public class FrameTypeInfo
    {
        public string Id { get; set; }
        public string IdDescription { get; set; }
        public bool HasEncoding { get; set; }
        public int EncogingOffset { get; set; }

        public FrameTypeInfo() { }

        public FrameTypeInfo(string id, string idDescription, bool hasEncoding, int encodingOffset)
        {
            this.Id = id;
            this.IdDescription = idDescription;
            this.HasEncoding = hasEncoding;
            this.EncogingOffset = EncogingOffset;
        }

        public FrameTypeInfo(string id, string idDescription, bool hasEncoding)
            : this(id, idDescription, hasEncoding, 1) 
        {
            this.EncogingOffset = 1;
        }
    }
}
