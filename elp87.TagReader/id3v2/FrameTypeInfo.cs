
namespace elp87.TagReader.id3v2
{
    /// <summary>
    /// This class provides information about frame type.
    /// </summary>
    public class FrameTypeInfo
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="elp87.TagReader.id3v2.FrameTypeInfo"/> class that is empty.
        /// </summary>
        public FrameTypeInfo() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="elp87.TagReader.id3v2.FrameTypeInfo"/> class.
        /// </summary>
        /// <param name="id">Frame identificator</param>
        /// <param name="idDescription">Frame description</param>
        public FrameTypeInfo(string id, string idDescription)
        {
            this.Id = id;
            this.IdDescription = idDescription;
        } 
        #endregion

        #region Properties
        /// <summary>
        /// Gets and sets frame identificator.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets and sets frame decription.
        /// </summary>
        public string IdDescription { get; set; }      
        #endregion        
    }
}
