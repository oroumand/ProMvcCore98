using System;

namespace Session08.Entities
{
    public class DataChangeHistory
    {
        public int DataChangeHistoryId { get; set; }
        public string EntityType { get; set; }
        public string EntityId { get; set; }
        public string SerializedData { get; set; }
        public DateTime RegistrationDate { get; set; }

    }
}
