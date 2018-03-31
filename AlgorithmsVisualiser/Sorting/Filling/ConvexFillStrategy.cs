using System.Collections.Generic;


namespace AlgorithmsVisualiser.Sorting.Filling
{
    public class ConvexFillStrategy : IFillStrategy
    {
        public void Fill(IList<int> list, int elementCount)
        {
            int firstHalf = elementCount / 2;
            int secondHalf = elementCount - firstHalf;

            for (int i = 1; i < firstHalf; i++)
            {
                list.Add(i);
            }
            for (int i = secondHalf; i > 0; i--)
            {
                list.Add(i);
            }


        }
    }
}
