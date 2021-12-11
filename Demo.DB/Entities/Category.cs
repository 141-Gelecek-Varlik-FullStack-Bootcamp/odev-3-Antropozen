using System;
using System.Collections.Generic;

#nullable disable

namespace Demo.DB.Entities
{
    public partial class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime IdateTime { get; set; }
        public DateTime? UdateTime { get; set; }
        public int Iuser { get; set; }
        public int? Uuser { get; set; }

        public virtual User IuserNavigation { get; set; }
    }
}
