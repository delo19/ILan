using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILanguage.DataModel
{
    public class Package
    {
        public String Name { get; set; }
        public Tag ParentTag { get; set; }
        public ObservableCollection<Word> Words { get; set; }

    }
}
