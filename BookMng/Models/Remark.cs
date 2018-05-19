using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BookMng.Models
{
    public class Remark
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
        public Book Book { get; set; }
        public ApplicationUser People { get; set; }
    }

}