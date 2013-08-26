using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace elp87.TagReader
{
    namespace id3v2
    {
        public class ID3V2
        {
            #region Constants
            private readonly byte[] _ID3HeaderMask = { 0x49, 0x44, 0x33 };
            #endregion

            #region Fields
            private string filename;
            private Header _header;
            #endregion

            #region Constructors
            public ID3V2(string filename)
            {
                // TODO: Complete member initialization
                this.filename = filename;
                this.ReadTag();
            }
            #endregion

            #region Properties
            public Header header
            {
                get
                {
                    return _header;
                }
            }
            #endregion
            #region Methods
            #region Public
            #endregion

            #region Private
            private void ReadTag()
            {
                byte[] file = this.LoadFile();
                int headerPosition = this.FindHeader(file);
                _header = new Header(file, headerPosition);
            }

            private byte[] LoadFile()
            {
                return File.ReadAllBytes(filename);
            }

            private int FindHeader(byte[] byteArray)
            {
                return ByteArray.FindSubArray(byteArray, _ID3HeaderMask);
            }
            #endregion


            #region Static

            #endregion
            #endregion

        }
    }
}
