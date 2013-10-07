using System;
using System.Collections.Generic;

namespace elp87.TagReader.id3v2.Frames
{
    public class ContentTypeFrame
        : TextInfoFrame
    {
        #region Fields
        private Dictionary<int, string> _genreList;
        #endregion

        #region Constructors
        public ContentTypeFrame()
        {
            this.InitGenreDictionary();
        }

        public ContentTypeFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            this.InitGenreDictionary();
            for (int i = 0; i < _values.Length; i++)
            {
                _values[i] = ParseGenre(_values[i]);
            }
        }
        #endregion
        
        #region Methods
        #region Private
        private void InitGenreDictionary()
        {
            _genreList = new Dictionary<int, string>();
            _genreList.Add(0, @"Blues");
            _genreList.Add(1, @"Classic Rock");
            _genreList.Add(2, @"Country");
            _genreList.Add(3, @"Dance");
            _genreList.Add(4, @"Disco");
            _genreList.Add(5, @"Funk");
            _genreList.Add(6, @"Grunge");
            _genreList.Add(7, @"Hip-Hop");
            _genreList.Add(8, @"Jazz");
            _genreList.Add(9, @"Metal");
            _genreList.Add(10, @"New Age");
            _genreList.Add(11, @"Oldies");
            _genreList.Add(12, @"Other");
            _genreList.Add(13, @"Pop");
            _genreList.Add(14, @"R&B");
            _genreList.Add(15, @"Rap");
            _genreList.Add(16, @"Reggae");
            _genreList.Add(17, @"Rock");
            _genreList.Add(18, @"Techno");
            _genreList.Add(19, @"Industrial");
            _genreList.Add(20, @"Alternative");
            _genreList.Add(21, @"Ska");
            _genreList.Add(22, @"Death Metal");
            _genreList.Add(23, @"Pranks");
            _genreList.Add(24, @"Soundtrack");
            _genreList.Add(25, @"Euro-Techno");
            _genreList.Add(26, @"Ambient");
            _genreList.Add(27, @"Trip-Hop");
            _genreList.Add(28, @"Vocal");
            _genreList.Add(29, @"Jazz+Funk");
            _genreList.Add(30, @"Fusion");
            _genreList.Add(31, @"Trance");
            _genreList.Add(32, @"Classical");
            _genreList.Add(33, @"Instrumental");
            _genreList.Add(34, @"Acid");
            _genreList.Add(35, @"House");
            _genreList.Add(36, @"Game");
            _genreList.Add(37, @"Sound Clip");
            _genreList.Add(38, @"Gospel");
            _genreList.Add(39, @"Noise");
            _genreList.Add(40, @"AlternRock");
            _genreList.Add(41, @"Bass");
            _genreList.Add(42, @"Soul");
            _genreList.Add(43, @"Punk");
            _genreList.Add(44, @"Space");
            _genreList.Add(45, @"Meditative");
            _genreList.Add(46, @"Instrumental Pop");
            _genreList.Add(47, @"Instrumental Rock");
            _genreList.Add(48, @"Ethnic");
            _genreList.Add(49, @"Gothic");
            _genreList.Add(50, @"Darkwave");
            _genreList.Add(51, @"Techno-Industrial");
            _genreList.Add(52, @"Electronic");
            _genreList.Add(53, @"Pop-Folk");
            _genreList.Add(54, @"Eurodance");
            _genreList.Add(55, @"Dream");
            _genreList.Add(56, @"Southern Rock");
            _genreList.Add(57, @"Comedy");
            _genreList.Add(58, @"Cult");
            _genreList.Add(59, @"Gangsta");
            _genreList.Add(60, @"Top 40");
            _genreList.Add(61, @"Christian Rap");
            _genreList.Add(62, @"Pop/Funk");
            _genreList.Add(63, @"Jungle");
            _genreList.Add(64, @"Native American");
            _genreList.Add(65, @"Cabaret");
            _genreList.Add(66, @"New Wave");
            _genreList.Add(67, @"Psychadelic");
            _genreList.Add(68, @"Rave");
            _genreList.Add(69, @"Showtunes");
            _genreList.Add(70, @"Trailer");
            _genreList.Add(71, @"Lo-Fi");
            _genreList.Add(72, @"Tribal");
            _genreList.Add(73, @"Acid Punk");
            _genreList.Add(74, @"Acid Jazz");
            _genreList.Add(75, @"Polka");
            _genreList.Add(76, @"Retro");
            _genreList.Add(77, @"Musical");
            _genreList.Add(78, @"Rock & Roll");
            _genreList.Add(79, @"Hard Rock");
        }

        private string GetGenreFromDictionary(int index)
        {
            string genre = "";
            if (index >= 0 && index <= 79) { genre = _genreList[index]; }
            else { genre = index.ToString(); }
            return genre;
        }

        private string ParseGenre(string genreString)
        {
            string curGenre;
            int openBracket = genreString.IndexOf('(');
            int closeBracket = genreString.IndexOf(')');
            if (openBracket != -1 && closeBracket != 1)
            {
                int startIndex = openBracket + 1;
                int length = closeBracket - openBracket - 1;
                string numString = genreString.Substring(startIndex, length);
                try
                {
                    int genreNumber = Convert.ToInt32(numString);
                    curGenre = GetGenreFromDictionary(genreNumber);
                }
                catch (FormatException)
                {
                    curGenre = genreString;
                }
            }
            else
            {
                curGenre = genreString;
            }
            return curGenre;
        }
        #endregion
        #endregion
        

        
    }
}
