using elp87.TagReader.id3v2;

namespace elp87.TagReader
{
    /// <summary>
    /// This class provides reading mp3 files info.
    /// </summary>
    public class MP3File
    {
        #region Fields
        private ID3V2 _id3v2;
        private string _filename;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="MP3File"/> that is empty.
        /// </summary>
        public MP3File()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MP3File"/> and read file.
        /// </summary>
        /// <param name="filename">The file to open for reading.</param>
        public MP3File(string filename)
        {
            this._filename = filename;
            _id3v2 = new ID3V2(filename);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Returns id3v2 tag information.
        /// </summary>
        public ID3V2 Id3v2 { get { return _id3v2; } }

        /// <summary>
        /// Returns performer or artist of this instance
        /// </summary>
        /// <remarks>
        /// <para>If instance of <see cref="P:elp87.TagReader.MP3File.Id3v2"/> is empty or it has no artists, this property returns "".</para>
        /// <para>This property returns only first performer if there are several. For full array of performers use Id3v2.PersonsFrames.TPE1.</para>
        /// <code lang="C#">
        /// MP3File file = new MP3File(filename);
        /// string[] performers = file.Id3v2.PersonsFrames.TPE1.GetValues();
        /// </code>
        /// </remarks>
        /// <seealso cref="P:elp87.TagReader.id3v2.Frames.PersonsFrameSet.TPE1"/>
        public string Performer
        {
            get
            {
                if (_id3v2 == null || _id3v2.PersonsFrames.TPE1 == null) { return ""; }
                else { return _id3v2.PersonsFrames.TPE1.ToString(); }
            }
        }

        /// <summary>
        /// Returns Album/Movie/Show title of this instance.
        /// </summary>
        /// <remarks>
        /// <para>If instance of <see cref="P:elp87.TagReader.MP3File.Id3v2"/> is empty or it has no album titles, this property returns "".</para>
        /// <para>This property returns only first title if there ara several. For full array of titles use Id3v2.IdentificationFrames.TALB.</para>
        /// <code lang="C#">
        /// MP3File file = new MP3File(filename);
        /// string[] albumTitles = file.Id3v2.IdentificationFrames.TALB.GetValues();
        /// </code>
        /// </remarks>
        /// <seealso cref="P:elp87.TagReader.id3v2.Frames.IdentificationFrameSet.TALB"/>
        public string Album
        {
            get
            {
                if (_id3v2 == null || _id3v2.IdentificationFrames.TALB == null) { return ""; }
                else { return _id3v2.IdentificationFrames.TALB.ToString(); }
            }
        }

        /// <summary>
        /// Returns title of this instance
        /// </summary>
        /// <remarks>
        /// <para>If instance of <see cref="P:elp87.TagReader.MP3File.Id3v2"/> is empty or it has no titles, this property returns "".</para>
        /// <para>This property returns only first title if there ara several. For full array of titles use Id3v2.IdentificationFrames.TIT2.</para>
        /// <code lang="C#">
        /// MP3File file = new MP3File(filename);
        /// string[] titles = file.Id3v2.IdentificationFrames.TIT2.GetValues();
        /// </code>
        /// </remarks>
        /// <seealso cref="P:elp87.TagReader.id3v2.Frames.IdentificationFrameSet.TIT2"/>
        public string Title
        {
            get
            {
                if (_id3v2 == null || _id3v2.IdentificationFrames.TIT2 == null) { return ""; }
                else { return _id3v2.IdentificationFrames.TIT2.ToString(); }
            }
        }

        /// <summary>
        /// Returns year of recording of this instance
        /// </summary>
        /// <remarks>
        /// <para>If instance of <see cref="P:elp87.TagReader.MP3File.Id3v2"/> is empty or it has no recording date, this property returns "".</para>
        /// <para>For full date in <see cref="T:System.DateTime"/> use Id3v2.OtherFrames.TDRC.Date.</para>
        /// <code lang="C#">
        /// MP3File file = new MP3File(filename);
        /// DateTime recordingDate = file.Id3v2.OtherFrames.TDRC.Date;
        /// </code>
        /// </remarks>
        /// <seealso cref="P:elp87.TagReader.id3v2.Frames.OtherFrameSet.TDRC"/>
        public string Year
        {
            get
            {
                if (_id3v2 == null || _id3v2.OtherFrames.TDRC == null) { return ""; }
                else { return _id3v2.OtherFrames.TDRC.Year.ToString(); }
            }
        }

        /// <summary>
        /// Returns full file name of this instance
        /// </summary>
        /// <remarks>
        /// <para>If this instance of <see cref="MP3File"/> is empty, this property returns "". </para>
        /// </remarks>
        public string Filename
        {
            get
            {
                if (_filename == null) { return ""; }
                else { return _filename; }
            }
        }

        /// <summary>
        /// Returns size of file in bytes.
        /// </summary>
        /// <remarks>
        /// <para>If instance of <see cref="P:elp87.TagReader.MP3File.Id3v2"/> is empty, this property returns 0</para>
        /// </remarks>
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
