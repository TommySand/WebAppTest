using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppTest.Models
{
    public class Medal
    {

        public Medal()
        {

        }

        public Medal(Inventory i)
        {
            this.Inventory = i;
        }

        public Inventory Inventory { get; set; }

    }
}