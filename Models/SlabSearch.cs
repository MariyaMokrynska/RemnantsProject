using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RemnantsProject.Data;

namespace RemnantsProject.Models
{

    public class SlabSearch
    {
        public SoldState SoldState { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public int MinWidth { get; set; }
        public int MaxWidth { get; set; }
        public int Thickness { get; set; }

    }
}
