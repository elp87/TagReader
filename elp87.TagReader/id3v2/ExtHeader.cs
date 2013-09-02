using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace elp87.TagReader.id3v2
{
    public class ExtHeader
    {
        private bool _update;
        private bool _CRC;
        private bool _restrictions;

        public int size { get; set; }
        public bool update { get { return _update; } }
        public bool CRC { get { return _CRC; } }
        public bool restrictions { get { return _restrictions; } }

        internal void ParseFlagField(byte flagByte)
        {
            _update = Convert.ToBoolean((flagByte & 0x40) >> 6);
            _CRC = Convert.ToBoolean((flagByte & 0x20) >> 5);
            _restrictions = Convert.ToBoolean((flagByte & 0x10) >> 4);
            if ((flagByte & 0x8F) != 0) throw new Exceptions.NotUsableFlagException("Invalid flag field in Ext Header. Undefined flags are set", Convert.ToString(flagByte, 2), DateTime.Now);            
        }
    }
}
