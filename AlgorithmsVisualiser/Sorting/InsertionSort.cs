using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace AlgorithmsVisualiser.Sorting
{
    public class InsertionSort : SortAlgorithm
    {
        public InsertionSort(StackPanel listContainer) : base(listContainer) { }

        public override string Name => "Insertion Sort";

        public async override void Sort(IList<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {

                int h = list[i];
                SelectElement(i);
                await Task.Delay(Delay);

                int j = i - 1;
                while (j >= 0 && h < list[j])
                {
                    CompareElement(j);
                    await Task.Delay(Delay);
                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = h;
                UpdateContainer(list);
            }

        }
    }
}
