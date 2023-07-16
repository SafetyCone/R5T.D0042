using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0042
{
    /// <summary>
    /// De/serializes an object to/from a text file.
    /// </summary>
    /// <remarks>
    /// * Upon writing, note that the optional overwrite argument default value is true.
    /// </remarks>
    [ServiceDefinitionMarker]
    public interface ITextFileSerializer<T> : IServiceDefinition
    {
        /// <summary>
        /// Deserializes an object from a text file.
        /// </summary>
        /// <param name="textFilePath">The rooted text file path to use.</param>
        Task<T> Deserialize(string textFilePath);

        /// <summary>
        /// Serializes an object to a text file.
        /// </summary>
        /// <param name="textFilePath">The rooted text file path to use.</param>
        Task Serialize(string textFilePath, T value, bool overwrite = true);
    }
}
