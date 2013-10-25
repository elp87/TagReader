using System;
using System.Text;

namespace elp87.TagReader.id3v2.Abstract
{
    /// <summary>
    /// This abstract base class provides general functionality for all frames owner identification
    /// </summary>
    public abstract class OwnerIDFrame
        : Frame
    {
        #region Fields
        /// <summary>
        /// Owner identifier
        /// </summary>
        protected string _ownerID;
        /// <summary>
        /// Actual byte data
        /// </summary>
        protected byte[] _data;
        /// <summary>
        /// Position of string terminator
        /// </summary>
        protected int _terminatorPos;
        #endregion

        #region Constructors
        /// <summary>
        /// Inheritable constructor for <see cref="elp87.TagReader.id3v2.Abstract.OwnerIDFrame"/> class
        /// </summary>
        public OwnerIDFrame()
            : base()
        { }

        /// <summary>
        /// Main inheritable constructor for <see cref="elp87.TagReader.id3v2.Abstract.OwnerIDFrame"/> class.
        /// </summary>
        /// <param name="flags">Flag fields of current frame.</param>
        /// <param name="frameData">Byte array that contains frame data excluding drame header and header extra data.</param>
        public OwnerIDFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            this.ParseFrame(frameData);
        }        
        #endregion

        #region Properies
        /// <summary>
        /// Gets owner identifier
        /// </summary>
        public string OwnerID { get { return this._ownerID; } }
        #endregion

        #region Methods
        #region Public
        /// <summary>
        /// Returns byte data
        /// </summary>
        /// <returns></returns>
        public byte[] GetData()
        {
            return (byte[])this._data.Clone();
        }
        #endregion
        #region Private
        /// <summary>
        /// Virtual method that parse frame data to compliant fields
        /// </summary>
        /// <param name="frameData">Frame  byte array</param>
        protected virtual void ParseFrame(byte[] frameData)
        {
            const byte termByte = 0x00;
            _terminatorPos = Array.IndexOf(frameData, termByte);
            this._ownerID = this.ReadOwnerID(frameData, _terminatorPos);         
        }

        /// <summary>
        /// Reads owner identifier from frame byte array
        /// </summary>
        /// <param name="frameData">Frame  byte array</param>
        /// <param name="terminatorPos">Position of string terminator</param>
        /// <returns>Owner ID string</returns>
        protected string ReadOwnerID(byte[] frameData, int terminatorPos)
        {
            
            byte[] ownerIdByte = new byte[terminatorPos];
            Array.Copy(frameData, ownerIdByte, terminatorPos);
            return Encoding.ASCII.GetString(ownerIdByte);
        }

        /// <summary>
        /// Reads actual byte data from frame byta array
        /// </summary>
        /// <param name="frameData">Frame  byte array</param>
        /// <param name="position">Position of string terminator</param>
        /// <returns>Actual data</returns>
        protected abstract byte[] ReadData(byte[] frameData, int position);
        #endregion
        #endregion
    }
}
