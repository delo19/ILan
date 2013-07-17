using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILanguage.DataModel
{
    public class Tag : ILanguage.Common.BindableBase
    {
        public ObservableCollection<TagSubtype> TagSubtypes { get; set; }
        public String UniqueId { get; set; }
        public String ImagePath { get; set; }
        public String Name { get; set; }//nazwa taga np polsko-angielski
        public int Popularity { get; set; }


    }
}
