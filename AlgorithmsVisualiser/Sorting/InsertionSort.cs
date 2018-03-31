using AlgorithmsVisualiser.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace AlgorithmsVisualiser.Sorting
{
    public class InsertionSort : SortAlgorithm
    {
        public InsertionSort(StackPanel listContainer) : base(listContainer) { }

        public async override void Sort(IList<int> list)
        {
            UpdateContainer(list);
            for (int i = 1; i < list.Count; i++)
            {
                int h = list[i];
                SelectElement(i);
                await Task.Delay(10);

                int j = i - 1;
                while (j >= 0 && h < list[j])
                {
                    CompareElement(j);
                    await Task.Delay(10);
                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = h;
                UpdateContainer(list);
            }
        }

        public override string Name {
            get {
                return "Insertion Sort";
            }
        }

        /// <summary>
        /// Sets the current 
        /// </summary>
        /// <param name="indexToSelect"></param>
        private void SelectElement(int indexToSelect)
        {
            ((Label)listContainer.Children[indexToSelect]).Background = new SolidColorBrush(Colours.Red);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indexToCompare"></param>
        private void CompareElement(int indexToCompare)
        {
            ((Label)listContainer.Children[indexToCompare]).Background = new SolidColorBrush(Colours.Green);
        }


    }
}
