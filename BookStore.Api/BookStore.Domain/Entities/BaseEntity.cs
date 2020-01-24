using System;

namespace BookStore.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        private DateTime? _createAt;
        public DateTime? CreatedAt
        {
            get { return _createAt; }
            set { _createAt = (value == null ? DateTime.UtcNow : value); }
        }
        public DateTime? UpdateAt { get; set; }
    }
}
