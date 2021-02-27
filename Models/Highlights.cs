using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantApp.Models
{
    public class Highlights
    {
        string attribute;
        int attNum;

        public Highlights(string attribute, int attNum)
        {
            Attribute = attribute;
            AttNum = attNum;
        }
        public Highlights() { }

        public string Attribute { get => attribute; set => attribute = value; }
        public int AttNum { get => attNum; set => attNum = value; }
    }
}