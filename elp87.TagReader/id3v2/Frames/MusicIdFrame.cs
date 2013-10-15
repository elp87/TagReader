using elp87.TagReader.id3v2.Abstract;

namespace elp87.TagReader.id3v2.Frames
{
    public class MusicIdFrame
        : Frame
    {
        #region Fields
        #endregion

        #region Constructors
        protected MusicIdFrame()
            : base()
        { }

        public MusicIdFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        { }
        #endregion

        #region Methods
        public byte[] GetData()
        {
            return (byte[])this._frameData.Clone();
        }
        #endregion
    }
}
