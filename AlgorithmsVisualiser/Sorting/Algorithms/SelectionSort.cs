using AlgorithmsVisualiser.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace AlgorithmsVisualiser.Sorting.Algorithms
{
    public class SelectionSort : SortAlgorithm
    {
        private int previousMaxIndex;

        public SelectionSort(StackPanel listContainer) : base(listContainer) { }

        public override string Name => "Selection Sort";

        public async override void Sort(IList<int> list)
        {
            for(int i = list.Count - 1; i > 0; i--)
            {
                int imax = i;
                SelectElement(i);
                await Task.Delay(Delay);

                for(int j = 0; j < i; j++)
                {
                    CompareElement(j);
                    if(list[j] > list[imax])
                    {
                        imax = j;
                        SelectMax(j);
                    }
                    await Task.Delay(Delay);
                }

                int temp = list[i];
                list[i] = list[imax];
                list[imax] = temp;
                UpdateContainer(list);
            }
        }

        private void SelectMax(int index)
        {
            ((Label)listContainer.Children[previousMaxIndex]).Background = new SolidColorBrush(Colours.Green);
            ((Label)listContainer.Children[index]).Background = new SolidColorBrush(Colours.Blue);
            previousMaxIndex = index;
        }
    }
}
