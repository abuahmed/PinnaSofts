using System.ComponentModel.DataAnnotations.Schema;


namespace PinnaSofts.Entity.Models.Interfaces
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}
