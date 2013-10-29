using elp87.TagReader.id3v2.Frames;
using System;
using System.Globalization;

namespace elp87.TagReader.id3v2.Frames
{
    /// <summary>
    /// Provides functionality for text info frames with date.
    /// </summary>
    /// <remarks>
    /// This class allows to read TDEN, TDOR, TDRC, TDRL and TDTG frames. For details read "ID3 tag version 2.4.0 - Native Frames"
    /// </remarks>
    public class DateInfoFrame
        : TextInfoFrame        
    {
        #region Fields
        private DateTime _date; 
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.DateInfoFrame"/> that is empty.
        /// </summary>
        protected DateInfoFrame()
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.DateInfoFrame"/> and read frame data
        /// </summary>
        /// <param name="flags">Flag fields of current frame.</param>
        /// <param name="frameData">Byte array that contains frame data excluding frame header and header extra data.</param>
        public DateInfoFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            _date = this.ParseDate();
        }        
        #endregion

        #region Properties
        /// <summary>
        /// Gets date value of frame
        /// </summary>
        public DateTime Date { get { return this._date; } }

        /// <summary>
        /// Gets the year component of the date represented by this instance.
        /// </summary>
        public int Year { get { return this._date.Year; } }
        #endregion

        #region Methods
        private DateTime ParseDate()
        {
            return this.ParseDate(this.ToString());
        }

        private DateTime ParseDate(string dateString)
        {
            string dateFormat;
            switch (dateString.Length)
            {
                case 4:
                    dateFormat = "yyyy"; break;
                case 7:
                    dateFormat = @"yyyy-MM"; break;
                case 10:
                    dateFormat = @"yyyy-MM-dd"; break;
                case 13:
                    dateFormat = @"yyyy-MM-ddTHH"; break;
                case 16:
                    dateFormat = @"yyyy-MM-ddTHH:mm"; break;
                case 19:
                    dateFormat = @"yyyy-MM-ddTHH:mm:ss"; break;
                default:
                    throw new FormatException();
            }
            return DateTime.ParseExact(dateString, dateFormat, CultureInfo.InvariantCulture); 
        }
        
        #endregion
    }
}
