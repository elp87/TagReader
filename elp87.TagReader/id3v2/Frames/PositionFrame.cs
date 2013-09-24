using elp87.TagReader.id3v2.Abstract;

namespace elp87.TagReader.id3v2.Frames
{
    public class PositionFrame
        : SlashNumericStringFrame
    {
        public PositionFrame()
            : base()
        { }

        public PositionFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        { }
    }
}
