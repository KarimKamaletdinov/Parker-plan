using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ParkerPlan.Site.Data
{
    public abstract class Filter<T>
    {
        public FilterItem[] Items;

        public abstract bool Accord(T item);

        public bool Accord(T[] item)
        {
            return item.All(Accord);
        }
    }

    public record FilterItem
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public char Sign { get; set; }
    }
}
