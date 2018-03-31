using AlgorithmsVisualiser.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace AlgorithmsVisualiser.Sorting
{
    public class SelectionSort : SortAlgorithm
    {
        public SelectionSort(StackPanel listContainer) : base(listContainer) { }

        public override string Name => "Selection Sort";

        public async override void Sort(IList<int> list)
        {
            for(int i = list.Count - 1; i > 0; i--)
            {
                int imax = i;
                SelectElement(i);
                await Task.Delay(10);

                for(int j = 0; j < i; j++)
                {
                    CompareElement(j);
                    if(list[j] > list[imax])
                    {
                        imax = j;
                        SelectMax(j);

                    }
                    await Task.Delay(10);
                }

                int temp = list[i];
                list[i] = list[imax];
                list[imax] = temp;
                UpdateContainer(list);
            }
        }

        private void SelectMax(int index)
        {
            ((Label)listContainer.Children[index]).Background = new SolidColorBrush(Colours.Blue);
        }
    }
}
