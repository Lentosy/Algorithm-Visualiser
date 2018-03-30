using System.Collections.Generic;

namespace AlgorithmsVisualiser.Sorting
{
    public class InsertionSort : Sortmethod
    {
        public override void Sort(IList<int> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                int h = list[i];
                int j = i - 1;
                while(j >= 0 && h < list[j])
                {
                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = h;
            }
        }

        public override string Name {
            get {
                return "Insertion Sort";
            }
        }
    }
}
