using AlgorithmsVisualiser.Helpers;
using System.Collections.Generic;

using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AlgorithmsVisualiser.Sorting.Algorithms
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

                int j = i - 1;
                while (j >= 0 && h < list[j])
                {
                    CompareElement(j);
                    await Task.Delay(Delay);
                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = h;
                UpdateContainer(list, i , j + 1);
            }

        }

        /// <summary>
        /// Insertion sort should only update the UI from index j to i
        /// </summary>
        /// <param name="list"></param>
        private void UpdateContainer(IList<int> list, int i, int j)
        {
            for(int k = j; k <= i; k++)
            {
                Rectangle rectangle = (Rectangle)listContainer.Children[k];
                rectangle.Fill = new SolidColorBrush(Colours.Black);
                rectangle.Margin = new Thickness(0, listContainer.Height - (list[k] * unitHeight), 0, 0);
            }

        }
    }
}
