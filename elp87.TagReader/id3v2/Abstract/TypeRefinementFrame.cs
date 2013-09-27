using System;
using System.Collections.Generic;
using System.Text;

namespace elp87.TagReader.id3v2.Abstract
{
    public abstract class TypeRefinementFrame
        : Frame
    {
        #region Constructors
        public TypeRefinementFrame()
            : base()
        { }

        public TypeRefinementFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            this.ParseString();
        }
        #endregion

        #region Methods
        protected abstract void ParseString();
        #endregion
    }
}
