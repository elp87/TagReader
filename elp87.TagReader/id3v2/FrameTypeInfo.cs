
namespace elp87.TagReader.id3v2
{
    public class FrameTypeInfo
    {
        public string Id { get; set; }
        public string IdDescription { get; set; }        

        public FrameTypeInfo() { }

        public FrameTypeInfo(string id, string idDescription)
        {
            this.Id = id;
            this.IdDescription = idDescription;            
        }
        
    }
}
