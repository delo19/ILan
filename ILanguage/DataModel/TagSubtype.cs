using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILanguage.DataModel
{
    /// <summary>
    /// Obiekty podtypów naszego taga czyli my words, my dictionary, most popular words itp.
    /// Kazdy z tych obiektów będzie miał jakies swoje specjalne ustawienia rozpoznajace obiekt 
    /// a takze liste powiazanych slowek lub przynajmniej wlasciwosci pobierajace slowka
    /// </summary>
    public class TagSubtype
    {
        public String Name { get; set; }
        public TagSubtypeType Type { get; set; }
        public String UniqueId { get; set; }
        public Tag ParentTag { get; set; }
        public ObservableCollection<Word> Words { get; set; }

    }
}
