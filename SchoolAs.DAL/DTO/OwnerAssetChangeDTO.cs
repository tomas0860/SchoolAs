using Assets.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assets.DAL.DTO
{
    public class OwnerAssetChangeDto
    {
            public long OwnerAssetChangeId { get; set; }
            public long AssetId { get; set; }
            public long CurrentDepartmentId { get; set; }
            public long NewDepartmentId { get; set; }
            public Nullable<bool> CurrentDepartmentApproved { get; set; }
            public bool? NewDepartmentApproved { get; set; }
            public string Status { get; set; }
            public string CurrentDepartmentComments { get; set; }
            public string NewDepartmentComments { get; set; }

            public Asset Asset { get; set; }
            public virtual Department Department { get; set; }
        }
    }