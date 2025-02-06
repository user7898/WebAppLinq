using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace WebAppLinq
{
    [Table(Name ="Employee")]
    public class Employee
    {
        [Column (IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public string Job { get; set; }

        [Column]
        public int Salary { get; set; }

    }
}