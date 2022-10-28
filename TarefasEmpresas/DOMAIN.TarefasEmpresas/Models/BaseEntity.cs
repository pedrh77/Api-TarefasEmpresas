using System;
using System.Text.Json.Serialization;

namespace DOMAIN.TarefasEmpresas.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? LastUpdatedAt { get; set; }
        [JsonIgnore]
        public bool IsDeleted { get; set; } = false;
    }
}
