using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WC_mvc.Models
{
    public class CountryListModel
    {
        public int Country_Id { get; set; }
        public string Name { get; set; }
        public List<int> Scorer_Id = new List<int>();
        public List<string> Surname = new List<string>();
        public int counter = 0;
    }
}