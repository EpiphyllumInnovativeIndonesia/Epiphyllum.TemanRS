namespace Epiphyllum.TemanRS.Repositories.Helpers
{
    /// <summary>
    /// Represents default values related to data mapping
    /// </summary>
    public static partial class MappingHelpers
    {
        /// <summary>
        /// Gets a name of the unique index column
        /// </summary>
        public static string UniqueIndex => "UIX_{0}_{1}";

        /// <summary>
        /// Gets a name of the index column
        /// </summary>
        public static string Index => "IX_{0}_{1}";
    }
}
