using elp87.TagReader.id3v2.Abstract;
using System.Text;

namespace elp87.TagReader.id3v2.Frames
{
    public class UrlFrame
        : Frame
    {
        #region Fields
        private string _link;
        #endregion

        #region Constructors
        protected UrlFrame()
            : base()
        { }
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
        public string Link { get { return this._link; } }
        #endregion
    }
}
