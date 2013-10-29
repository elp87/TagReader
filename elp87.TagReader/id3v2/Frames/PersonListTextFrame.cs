using elp87.TagReader.id3v2.Abstract;

namespace elp87.TagReader.id3v2.Frames
{
    /// <summary>
    /// Provides functionality for frames that contain mapping between people and their roles.
    /// </summary>
    /// <remarks>This class allows to read TMCL and TIPL frames. For details read "ID3 tag version 2.4.0 - Native Frames".</remarks>
    public class PersonListTextFrame
        : TextFrame
    {
        #region Subclasses
        /// <summary>
        /// This structure represents person and his role.
        /// </summary>
        public struct PersonMapItem
        {
            /// <summary>
            /// Gets and sets person name.
            /// </summary>
            public string person { get; set; }

            /// <summary>
            /// Gets and sets current person's role.
            /// </summary>
            public string role { get; set; }                        
        }

        /// <summary>
        /// Represents a frame reader that can read TMCL or TIPL frame.
        /// </summary>
        public class PersonListItemFrame
            : TextFrame
        {
            #region Constructors
            /// <summary>
            /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.PersonListTextFrame.PersonListItemFrame"/> and read frame data.
            /// </summary>
            /// <param name="flags">Flag fields of current frame.</param>
            /// <param name="frameData">Byte array that contains frame data excluding frame header and header extra data.</param>
            public PersonListItemFrame(FrameFlagSet flags, byte[] frameData)
                : base(flags, frameData)
            { } 
            #endregion

            #region Methods
            /// <summary>
            /// Returns string value of frame.
            /// </summary>
            /// <returns>Frame value.</returns>
            public string GetString()
            {
                return this.GetString(this._frameData);
            } 
            #endregion
        }
        #endregion

        #region Fields
        private PersonMapItem[] _persons;
        private bool _itemStarted;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.PersonListTextFrame"/> that is empty.
        /// </summary>
        public PersonListTextFrame()
        {
            this._persons = new PersonMapItem[0];
            this._itemStarted = false;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the number of elements actually contained in this type of frames
        /// </summary>
        public int ListCount
        {
            get
            {
                return this._persons.Length;
            }
        }
        #endregion

        #region Methods
        #region Public
        /// <summary>
        /// Read standart frame data and add information to "person-role" array.
        /// </summary>
        /// <param name="flags">Flag fields of current frame.</param>
        /// <param name="byteArray">Byte array that contains frame data excluding frame header and header extra data.</param>
        public void AddData(FrameFlagSet flags, byte[] byteArray)
        {
            if (this._itemStarted == false)
            {
                this._persons = this.AddNewElementToPersons(this._persons);
                PersonListItemFrame roleItem = new PersonListItemFrame(flags, byteArray);
                string role = roleItem.GetString();
                this._persons[this._persons.Length - 1].role = role;
                this._itemStarted = true;
            }
            else
            {
                PersonListItemFrame personItem = new PersonListItemFrame(flags, byteArray);
                string person = personItem.GetString();
                this._persons[this._persons.Length - 1].person = person;
                this._itemStarted = false;
            }
        }

        /// <summary>
        /// Returns pair "role-person" at the specified index 
        /// </summary>
        /// <param name="index">The zero-based index of the element to get</param>
        /// <returns>Instance of <see cref="elp87.TagReader.id3v2.Frames.PersonListTextFrame.PersonMapItem"/> that represent a pair "role-person"</returns>
        public PersonMapItem GetValue(int index)
        {
            return this._persons[index];
        }
        #endregion

        #region Private
        private PersonMapItem[] AddNewElementToPersons(PersonMapItem[] initialPersonList)
        {
            PersonMapItem[] tempPersonList = this.ClonePersonList(initialPersonList);
            PersonMapItem[] newPersonList = new PersonMapItem[initialPersonList.Length + 1];
            this._persons = new PersonMapItem[tempPersonList.Length + 1];
            for (int i = 0; i < tempPersonList.Length; i++)
            {
                newPersonList[i] = tempPersonList[i];
            }
            newPersonList[newPersonList.Length - 1] = new PersonMapItem();
            return newPersonList;

        }

        private PersonMapItem[] ClonePersonList(PersonMapItem[] clonePersonList)
        {
            PersonMapItem[] clonedList = new PersonMapItem[clonePersonList.Length];
            for (int i = 0; i < clonePersonList.Length; i++)
            {
                clonedList[i] = clonePersonList[i];
            }
            return clonedList;
        }  
        #endregion
        #endregion        
    }
}
