namespace Epiphyllum.TemanRS.Core.Abstractions
{
    /// <summary>
    /// Interface for concurrentable entities
    /// </summary>
    public partial interface IConcurrentable
    {
        /// <summary>
        /// Gets or sets the entity row version
        /// </summary>
        byte[] RowVersion { get; set; }
    }
}
