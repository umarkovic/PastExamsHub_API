using System;

namespace PastExamsHub.Base.Domain.Common
{
    public interface IAuditableEntity
    {
        public DateTime CreatedDateTimeUtc { get; set; }
        public string CreatedByUserUid { get; set; }
        public DateTime? LastModifiedDateTimeUtc { get; set; }
        public string LastModifiedByUserUid { get; set; }
        public DateTime? DeletedDateTimeUtc { get; set; }
        public string DeletedByUserUid { get; set; }
    }
}
