using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assets.WebAPI.Models
{
    public class CoreValue
    {
        public string Description{ set; get; }
        public Row AlphabetSoup{ set; get; }
    }

    public class Row
    {
        public IEnumerable<string> Row1 { set; get; }
        public IEnumerable<string> Row2 { set; get; }
        public IEnumerable<string> Row3 { set; get; }
        public IEnumerable<string> Row4 { set; get; }
        public IEnumerable<string> Row5 { set; get; }
        public IEnumerable<string> Row6 { set; get; }
        public IEnumerable<string> Row7 { set; get; }
        public IEnumerable<string> Row8 { set; get; }
        public IEnumerable<string> Row9 { set; get; }
        public IEnumerable<string> Row10 { set; get; }
        public IEnumerable<string> Row11 { set; get; }
        public IEnumerable<string> Row12 { set; get; }
        public IEnumerable<string> Row13 { set; get; }
        public IEnumerable<string> Row14 { set; get; }
        public IEnumerable<string> Row15 { set; get; }
    }

    public class GFTCore
    {
        public string[] Core { set; get; }
    }
}