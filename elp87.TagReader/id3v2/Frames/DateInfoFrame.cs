using elp87.TagReader.id3v2.Frames;
using System;
using System.Globalization;

namespace elp87.TagReader.id3v2.Frames
{
    public class DateInfoFrame
        : TextInfoFrame        
    {
        #region Fields
        private DateTime _date; 
        #endregion

        #region Constructors
        protected DateInfoFrame()
        { }

        public DateInfoFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            _date = this.ParseDate();
        }        
        #endregion

        #region Properties
        public DateTime Date { get { return this._date; } }
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
