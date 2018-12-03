using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PotluckWebApp.Models
{
    public class MemberViewModel
    {
        public List<Member> Members { get; set; }
        public List<Potluck> Potlucks { get; set; }
    }
}