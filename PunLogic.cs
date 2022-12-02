using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace The_Oracle
{

    public class PunLogic
    {
        internal class LastUsed
        {
            private int _lastMin = -1;
            private int _lastMax = -1;
            private string[] _lastTags = new string[] { };
            private string[] _lastCategories = new string[] { };
            private bool _lastIncludeUsed;

            public bool stale = false;

            public bool IsNew(int min, int max, string[] tags, string[] categories, bool include_used = false)
            {
                if (!stale && (_lastMin == min && _lastMax == max && _lastTags.Equals(tags)  && _lastCategories.Equals(categories)  && _lastIncludeUsed == include_used))
                {
                    return false;
                }

                _lastMin = min;
                _lastMax = max;
                _lastTags = tags;
                _lastCategories = categories;
                _lastIncludeUsed = include_used;
                stale = false;

                return true;
            }
        }

        int index = 0;
        private PunDatabase punDb = new PunDatabase();
        private LastUsed lastUsed = new LastUsed();
        PunEntry[] lastPunEntries = new PunEntry[0];
        private static Random rng = new Random();

        internal string[] GetAllTags()
        {
            return punDb.FetchAllTags();
        }

        internal string[] GetAllCategories()
        {
            return punDb.FetchAllCategories();
        }

        public PunEntry MarkUsed(PunEntry entry, bool used)
        {
            lastUsed.stale = true;
            return punDb.MarkUsed(entry, used);
        }

        public PunEntry GetRandom(int min, int max, string[] tags, string[] categories, bool include_used = false)
        {
            if (lastPunEntries.Length != 0)
            {
                index = ++index % lastPunEntries.Length; // Cycle back to beginning if we reach the end
            }

            bool isNew = lastUsed.IsNew(min, max, tags, categories, include_used);

            if (isNew)
            {
                lastPunEntries = punDb.Search(min, max, tags, categories, include_used);
                lastPunEntries = lastPunEntries.OrderBy(a => rng.Next()).ToArray();
                index = 0;
            }

            if (lastPunEntries.Length == 0)
            {
                return new PunEntry()
                {
                    Text = "I came here to kick ass and drop wisdom, and I'm all out of wisdom"
                };
            }

            return lastPunEntries[index];
        }
    }
}
