using System;

namespace PastExamsHub.Base.Domain.Common
{
    public abstract class AuditableEntity : IAuditableEntity
    {
        public DateTime CreatedDateTimeUtc { get; set; }
        public string CreatedByUserUid { get; set; }
        public DateTime? LastModifiedDateTimeUtc { get; set; }
        public string LastModifiedByUserUid { get; set; }
        public DateTime? DeletedDateTimeUtc { get; set; }
        public string DeletedByUserUid { get; set; }

        public void AddAuditTrailForCreate(string userUid, DateTime now)
        {
            CreatedByUserUid = userUid;
            CreatedDateTimeUtc = now;
        }

        public void AddAuditTrailForUpdate(string userUid, DateTime now)
        {
            LastModifiedByUserUid = userUid;
            LastModifiedDateTimeUtc = now;
        }
        public void AddAuditTrailForDelete(string userUid, DateTime now)
        {
            DeletedByUserUid = userUid;
            DeletedDateTimeUtc = now;
        }
    }
}
