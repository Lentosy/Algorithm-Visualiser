using System.Collections.Generic;


namespace AlgorithmsVisualiser.Sorting.Filling
{
    public class ConcaveFillStrategy : IFillStrategy
    {
        public void Fill(IList<int> list, int elementCount)
        {
            int firstHalf = elementCount / 2;
            int secondHalf = elementCount - firstHalf;

            for(int i = firstHalf; i > 0; i--)
            {
                list.Add(i);
            }

            for(int i = 1; i < secondHalf; i++)
            {
                list.Add(i);
            }
        }
    }
}
