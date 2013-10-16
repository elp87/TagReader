using System;
using System.Collections.Generic;
using System.Text;

namespace elp87.TagReader
{
    public static class Generic
    {
        public static T[] Add<T>(T[] array, T element)
        {
            T[] temp = new T[array.Length];
            for (int i = 0; i < array.Length; i++) { temp[i] = array[i]; }
            T[] newArray = new T[temp.Length + 1];
            for (int i = 0; i < temp.Length; i++) { newArray[i] = temp[i]; }
            newArray[newArray.Length - 1] = element;
            return newArray;            
        }
    }
}
