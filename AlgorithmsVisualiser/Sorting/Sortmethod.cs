using AlgorithmsVisualiser.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AlgorithmsVisualiser.Sorting
{
    public abstract class SortAlgorithm
    {
        /// <summary>
        /// The height that the value '1' should take. 
        /// Example: If the value of a listitem is 14, the height will be 14 * unitHeight
        /// </summary>
        private double unitHeight;

        /// <summary>
        /// The width that one bar representing a value should take
        /// </summary>
        private double unitWidth;

        protected StackPanel listContainer;
        protected SortAlgorithm(StackPanel listContainer)
        {
            this.listContainer = listContainer;
        }

        /// <summary>
        /// This method sorts the list supplied as the only parameter. Time complexity depends on the sorting
        /// algorithm that is used as the concrete implementation
        /// </summary>
        /// <param name="list">The list to sort</param>
        public abstract void Sort(IList<int> list);
        /// <summary>
        /// Gets the name of the sorting algorithm
        /// </summary>
        public abstract string Name {
            get;
        }

        protected void UpdateContainer(IList<int> list)
        {
            unitHeight = listContainer.Height / list.Max();
            unitWidth = listContainer.Width / list.Count;
            listContainer.Children.Clear();
            foreach (int i in list)
            {
                Label listItem = new Label
                {
                    Background = SystemColors.ActiveBorderBrush,
                    // Margin and not height so the label starts from bottom
                    Margin = new Thickness(0, listContainer.Height - (i * unitHeight), 0, 0),
                    Width = unitWidth
                };
                listContainer.Children.Add(listItem);
            }
        }

    }
}
