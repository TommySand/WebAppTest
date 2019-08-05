using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppTest.Models
{
    public class MedalWithTrophy
    {

        public MedalWithTrophy()
        {

        }

        public MedalWithTrophy(Medal m, Trophy t)
        {
            this.Medal = m;
            this.Trophy = t;
        }

        public Medal Medal { get; set; }
        public Trophy Trophy { get; set; }

    }
}