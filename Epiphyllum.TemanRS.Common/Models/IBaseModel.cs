namespace Epiphyllum.TemanRS.Common.Models
{
    /// <summary>
    /// Base model interface.
    /// </summary>
    public interface IBaseModel
    {
        int Id { get; set; }
        byte[] RowVersion { get; set; }
    }
}
