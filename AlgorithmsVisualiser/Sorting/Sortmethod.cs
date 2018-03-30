using System.Collections.Generic;

namespace AlgorithmsVisualiser.Sorting
{
    public abstract class Sortmethod
    {
        public abstract void Sort(IList<int> list);
        public abstract string Name {
            get;
        }
    }
}
