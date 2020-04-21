using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assets.DAL.DTO
{
    public class UserCriteriaDto
    {
        public long? UserId { get; set; }
        public string Name { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public string Position { get; set; }
        public bool? IsExempt { get; set; }
        public bool? PhoneRequired { get; set; }
        public string ActiveDirectoryUser { get; set; }
        public string LastName { get; set; }
        public string LastName2 { get; set; }
    }
}