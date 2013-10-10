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
        protected int _terminatorPos;
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
        public string OwnerID { get { return this._ownerID; } }
        #endregion

        #region Methods
        #region Public
        public byte[] GetData()
        {
            return (byte[])this._data.Clone();
        }
        #endregion
        #region Private
        protected virtual void ParseFrame(byte[] frameData)
        {
            const byte termByte = 0x00;
            _terminatorPos = Array.IndexOf(frameData, termByte);
            this._ownerID = this.ReadOwnerID(frameData, _terminatorPos);         
        }

        protected string ReadOwnerID(byte[] frameData, int terminatorPos)
        {
            
            byte[] ownerIdByte = new byte[terminatorPos];
            Array.Copy(frameData, ownerIdByte, terminatorPos);
            return Encoding.ASCII.GetString(ownerIdByte);
        }

        protected abstract byte[] ReadData(byte[] frameData, int position);
        #endregion
        #endregion
    }
}
