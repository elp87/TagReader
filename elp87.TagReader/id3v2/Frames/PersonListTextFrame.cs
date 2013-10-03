using elp87.TagReader.id3v2.Abstract;

namespace elp87.TagReader.id3v2.Frames
{
    public class PersonListTextFrame
        : TextFrame
    {
        #region Subclasses
        public class PersonMapItem
        {
            public string person { get; set; }
            public string role { get; set; }                        
        }

        public class PersonListItemFrame
            : TextFrame
        {
            #region Constructors
            public PersonListItemFrame(FrameFlagSet flags, byte[] frameData)
                : base(flags, frameData)
            { } 
            #endregion

            #region Methods
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
        public PersonListTextFrame()
        {
            this._persons = new PersonMapItem[0];
            this._itemStarted = false;
        }
        #endregion

        #region Methods
        #region Public
        public PersonMapItem GetValue(int index)
        {
            return this._persons[index];
        }
        #endregion

        #region Private
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

        #region Properties
        public int ListCount
        {
            get
            {
                return this._persons.Length;
            }
        }
        #endregion
    }
}
