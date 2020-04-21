using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assets.WebAPI.Models
{
    public class User
    {
        public int Id { set; get; }
        public string Name{ set; get; }
        public string LastName{ set; get; }
        public string DistributionList { set; get; }
        public string Country { set; get; }
    }
}