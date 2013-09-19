namespace elp87.TagReader.id3v2.Abstract
{
    public abstract class Frame
    {
        protected FrameFlagSet _flags;
        protected byte[] _frameData;

        public Frame() { }
        public Frame(FrameFlagSet flags, byte[] frameData)
        {
            this._flags = flags;
            this._frameData = frameData;
        }

        public FrameFlagSet flags
        {
            get
            {
                return _flags;
            }
        }
    }
}
