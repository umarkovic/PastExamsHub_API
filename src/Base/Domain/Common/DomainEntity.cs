using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PastExamsHub.Base.Domain.Common
{
    public class DomainEntity
    {
        /*
        #region IHasDomainEvents

        [JsonIgnore]
        [NotMapped]
        public ICollection<DomainEvent> DomainEvents { get; private set; } = new List<DomainEvent>();

        #endregion

        public void AddDomainEvent(DomainEvent domainEvent) //TODO: consider protected
        {
            DomainEvents.Add(domainEvent);
        }
        */

        [OpenApiExclude]
        [JsonIgnore]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Uid { get; set; }
    }
}
