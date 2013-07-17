using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILanguage.DataModel
{
    /// <summary>
    /// Klasa odpowiada za pobranie z odpowiedniego źródła tagów. Tutaj to zapewne beda settingsy użytkownika
    /// </summary>
    public sealed class TagCollection
    {

        private static TagCollection _tagCollection = new TagCollection();
        /// <summary>
        /// Zbiór zwracanych tagów
        /// </summary>
        private ObservableCollection<Tag> _allTags = new ObservableCollection<Tag>();
        public ObservableCollection<Tag> AllTags
        {
            get { return this._allTags; }
        }

        public TagCollection()
        {
            PrepareData();

        }

        #region AccessMethods 

        public static IEnumerable<Tag> GetTags(string uniqueId)
        {
            if (!uniqueId.Equals("AllTags")) throw new ArgumentException("Only 'AllGroups' is supported as a collection of groups");

            return _tagCollection.AllTags;
        }

        public static Tag GetGroup(string uniqueId)
        {
            // Simple linear search is acceptable for small data sets
            var matches = _tagCollection.AllTags.Where((group) => group.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public static TagSubtype GetItem(string uniqueId)
        {
            // Simple linear search is acceptable for small data sets
            var matches = _tagCollection.AllTags.SelectMany(group => group.TagSubtypes).Where((item) => item.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        #endregion

        /// <summary>
        /// metoda odpowiedzialna za pobranie danych do naszej aplikacji. Ma za zadanie wybrane tagi wczytac, dopasowac subtagi, 
        /// w miare mozliwosci pobrac rekordy z bazy danych aby wyswietlić je w naszej aplikacji 
        /// </summary>
        private void PrepareData()
        {

        }
    }
}
