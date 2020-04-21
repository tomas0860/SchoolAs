using System;
using System.Collections.Generic;

namespace Assets.DAL.DTO
{
    public class OwnerAssetChangeCriteriaDto
    {
        public long? OwnerAssetChangeId { get; set; }
        public long? AssetId { get; set; }
        public long? CurrentDepartmentId { get; set; }
        public long? NewDepartmentId { get; set; }
    }
}
