using System;
using System.Text;

namespace elp87.TagReader.id3v2.Abstract
{
    public abstract class OwnerIDFrame
        : Frame
    {
        #region Fields
        protected string _ownerID;
        protected byte[] _data;
        #endregion

        #region Constructors
        public OwnerIDFrame()
            : base()
        { }

        public OwnerIDFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            this.ParseFrame(frameData);
        }        
        #endregion

        #region Properies
        public string ownerID { get { return this._ownerID; } }
        #endregion

        #region Methods
        #region Public
        public byte[] GetData()
        {
            return (byte[])this._data.Clone();
        }
        #endregion
        #region Private
        protected void ParseFrame(byte[] frameData)
        {
            const byte termByte = 0x00;
            int terminatorPos = Array.IndexOf(frameData, termByte);
            this._data = new byte[frameData.Length - terminatorPos - 1];
            byte[] ownerIdByte = new byte[terminatorPos];
            Array.Copy(frameData, ownerIdByte, terminatorPos);
            this._ownerID = Encoding.ASCII.GetString(ownerIdByte);            
            Array.Copy(frameData, terminatorPos + 1, this._data, 0, frameData.Length - terminatorPos - 1);
        }
        #endregion
        #endregion
    }
}
