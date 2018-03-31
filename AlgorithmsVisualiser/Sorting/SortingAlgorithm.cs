using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AlgorithmsVisualiser.Sorting
{
    public abstract class SortAlgorithm
    {
        /// <summary>
        /// The height that the value '1' should take. 
        /// Example: If the value of a listitem is 14, the height will be 14 * unitHeight
        /// </summary>
        protected double unitHeight;

        /// <summary>
        /// The width that one bar representing a value should take
        /// </summary>
        protected double unitWidth;

        protected StackPanel listContainer;
        protected SortAlgorithm(StackPanel listContainer)
        {
            this.listContainer = listContainer;
        }

        /// <summary>
        /// This method sorts the list supplied as the only parameter. Time complexity depends on the sorting
        /// algorithm that is used as the concrete implementation.
        /// </summary>
        /// <param name="list">The list to sort</param>
        public abstract void Sort(IList<int> list);
        /// <summary>
        /// Gets the name of the sorting algorithm
        /// </summary>
        public abstract string Name {
            get;
        }

        /// <summary>
        /// This method will intiliaze the default GUI before sorting the list.
        /// </summary>
        /// <param name="list"></param>
        public void  InitializeContainer(IList<int> list)
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

        /// <summary>
        /// This method gets called everytime the sorting algorithm swaps an element
        /// </summary>
        /// <param name="list"></param>
        protected void UpdateContainer(IList<int> list)
        {
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
