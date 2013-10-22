using elp87.TagReader.id3v2;

namespace elp87.TagReader
{
    public class MP3File
    {
        #region Fields
        private ID3V2 _id3v2;
        private string _filename;
        #endregion

        #region Constructors
        public MP3File()
        {
        }

        public MP3File(string filename)
        {
            this._filename = filename;
            _id3v2 = new ID3V2(filename);
        }
        #endregion

        #region Properties
        public ID3V2 Id3v2 { get { return _id3v2; } }

        public string Performer
        {
            get
            {
                if (_id3v2 == null || _id3v2.PersonsFrames.TPE1 == null) { return ""; }
                else { return _id3v2.PersonsFrames.TPE1.ToString(); }
            }
        }

        public string Album
        {
            get
            {
                if (_id3v2 == null || _id3v2.IdentificationFrames.TALB == null) { return ""; }
                else { return _id3v2.IdentificationFrames.TALB.ToString(); }
            }
        }

        public string Title
        {
            get
            {
                if (_id3v2 == null || _id3v2.IdentificationFrames.TIT2 == null) { return ""; }
                else { return _id3v2.IdentificationFrames.TIT2.ToString(); }
            }
        }

        public string Year
        {
            get
            {
                if (_id3v2 == null || _id3v2.OtherFrames.TDRC == null) { return ""; }
                else { return _id3v2.OtherFrames.TDRC.Year.ToString(); }
            }
        }

        public string Filename
        {
            get
            {
                if (_filename == null) { return ""; }
                else { return _filename; }
            }
        }

        public int Size
        {
            get
            {
                if (_id3v2 == null) { return 0; }
                else { return _id3v2.GetFileSize(); }
            }
        }
        #endregion
    }
}
