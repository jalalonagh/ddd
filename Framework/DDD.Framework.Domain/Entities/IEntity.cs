using DDD.Framework.Domain.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDD.Framework.Domain.Entities
{
    public interface IBaseEntity
    {
        public DateTime creation { get; set; }
        public int? priority { get; set; }
    }
    public interface IEntity : IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
    
    public interface IIdentityEntity : IBaseEntity
    {

    }
}
