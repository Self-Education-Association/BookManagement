﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace BookMng.Models
{
    public class Borrow
    {
        public int ID { get; set; }

        public int BookID { get; set; }

        public int ApplicationUserID { get; set; }

        public DateTime BorrowDate{ get; set; }

        public DateTime ReturnDate
        {
            get { return ReturnDate; }
            set
            {
                ReturnDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));

                ReturnDate.AddMonths(1);
            }
        }

        public bool Subscribe { get; set; }

        public string SubscribeDate { get; set; }

        public Book Book { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }


}