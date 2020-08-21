using System;


namespace R5T.D0042
{
    /// <summary>
    /// De/serializes an object to/from a text file.
    /// </summary>
    /// <remarks>
    /// * Upon writing, note that the optional overwrite argument default value is true.
    /// </remarks>
    public interface ITextFileSerializer<T>
    {
        /// <summary>
        /// Deserializes an object from a text file.
        /// </summary>
        /// <param name="filePath">The rooted text file path to use.</param>
        T Deserialize(string textFilePath);

        /// <summary>
        /// Serializes an object to a text file.
        /// </summary>
        /// <param name="textFilePath">The rooted text file path to use.</param>
        void Serialize(string textFilePath, T value, bool overwrite = true);
    }
}
