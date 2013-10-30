using elp87.TagReader.id3v2.Abstract;
using System.Text;

namespace elp87.TagReader.id3v2.Frames
{
    /// <summary>
    /// Provides functionality for most of URL link frames.
    /// </summary>
    /// <remarks>For details read "ID3 tag version 2.4.0 - Native Frames" section 4.3.</remarks>
    /// <seealso cref="P:elp87.TagReader.id3v2.ID3V2.UrlFrames"/>
    public class UrlFrame
        : Frame
    {
        #region Fields
        private string _link;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.UrlFrame"/> that is empty.
        /// </summary>
        protected UrlFrame()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.UrlFrame"/> and read frame data.
        /// </summary>
        /// <param name="flags">Flag fields of current frame.</param>
        /// <param name="frameData">Byte array that contains frame data excluding frame header and header extra data.</param>
        public UrlFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            this.ParseFrame();
        }        
        #endregion

        #region Methods
        private void ParseFrame()
        {
            this._link = Encoding.ASCII.GetString(this._frameData);
        } 
        #endregion

        #region Properties
        /// <summary>
        /// Gets actual frame URL link.
        /// </summary>
        public string Link { get { return this._link; } }
        #endregion
    }
}
