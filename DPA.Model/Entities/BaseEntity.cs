using System;

namespace DPA.Model
{
    public abstract class BaseEntity
    {
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }
    }
}