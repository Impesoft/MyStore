using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore
{
    internal interface IProduct
    {
        public int Id { get; }
        public string Name { get; set; }

        public string Description { get; set; }
    }
}