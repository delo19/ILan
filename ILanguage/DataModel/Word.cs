using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ILanguage.DataModel
{
    public class Word
    {
        public String Key { get; set; }
        public String Value { get; set; }
        public String Description  { get; set; }
        public String Example { get; set; }
        public int Priority { get; set; }
        public int Popularity { get; set; }
        public TagSubtype ParentTagSubtype { get; set; }
        public String Category { get; set; }
    }
}
