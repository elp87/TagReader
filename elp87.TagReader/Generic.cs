using System;
using System.Collections.Generic;
using System.Text;

namespace elp87.TagReader
{
    /// <summary>
    /// Provides static generic methods
    /// </summary>
    public static class Generic
    {
        /// <summary>
        /// Adds element in the end of array and returns new instance of array.
        /// </summary>
        /// <typeparam name="T">The type of array elements.</typeparam>
        /// <param name="array">Initial array</param>
        /// <param name="element">Element that should be added to array</param>
        /// <returns>New instance of array with added element in the end</returns>
        /// <example>
        /// <code lang="C#">
        /// using elp87.TagReader;
        /// using System;
        /// 
        /// namespace Example
        /// {
        ///     class Program
        ///     {
        ///         static void Main(string[] args)
        ///         {
        ///             int[] array = new int[] { 0, 1, 2, 3, 4 };
        ///             int[] newArray = Generic.Add&lt;int&gt;(array, 5);
        /// 
        ///             foreach (int num in newArray)
        ///             {
        ///                 Console.Write("{0}, ", num);
        ///             }
        ///         }
        ///     }
        /// }
        /// // The example displays the following output:
        /// // 0, 1, 2, 3, 4, 5,
        /// </code>
        /// It is not necessarily to indicate type of elements, but <c>array</c> and <c>element</c> should be the same type
        /// <code lang="C#">
        /// int[] newArray = Generic.Add(array, 5);
        /// </code>
        /// You can get new array as initial one.
        /// <code lang="C#">
        /// int[] array = new int[] { 0, 1, 2, 3, 4 };
        /// array = Generic.Add(array, 5);
        /// </code>
        /// </example>
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
