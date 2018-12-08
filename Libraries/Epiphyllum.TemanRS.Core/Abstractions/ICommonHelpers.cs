namespace Epiphyllum.TemanRS.Core.Abstractions
{
    /// <summary>
    /// Represents a common helpers
    /// </summary>
    public interface ICommonHelpers : IRegisterSingleton
    {
        /// <summary>
        /// Verifies that a string is endoded format
        /// </summary>
        /// <param name="providedString">String to verify</param>
        /// <returns>True if the string is endoded and false if it's not</returns>
        bool IsBase64Encoded(string providedString);
    }
}
