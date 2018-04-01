using AlgorithmsVisualiser.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AlgorithmsVisualiser.Sorting.Algorithms
{
    public abstract class SortAlgorithm
    {
        #region Attributes
        /// <summary>
        /// The height that the value '1' should take. 
        /// Example: If the value of a listitem is 14, the height will be 14 * unitHeight
        /// </summary>
        protected double unitHeight;

        /// <summary>
        /// The width that one bar representing a value should take
        /// </summary>
        protected double unitWidth;

        /// <summary>
        /// The delay for each significant operation in milliseconds
        /// </summary>
        public int Delay { get; set; }

        protected StackPanel listContainer;
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="listContainer">The container that holds the visual list</param>
        /// <param name="delay">The default delay for each significant operation in milliseconds</param>
        protected SortAlgorithm(StackPanel listContainer, int delay = 10)
        {
            this.listContainer = listContainer;
            Delay = delay;
        }

        #region Public Methods
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
        public void InitializeContainer(IList<int> list)
        {
            unitHeight = listContainer.Height / list.Max();
            unitWidth = listContainer.Width / list.Count;
            listContainer.Children.Clear();
            foreach (int i in list)
            {
                Rectangle listItem = new Rectangle
                {
                    Fill = new SolidColorBrush(Colours.Default),
                    // Margin and not height so the label starts from bottom
                    // The next line sets the top margin for each label. 
                    Margin = new Thickness(0, listContainer.Height - (i * unitHeight), 0, 0),
                    Width = unitWidth
                };
                listContainer.Children.Add(listItem);
            }
        }
        #endregion

        #region Protected methods
        protected void SelectElement(int indexToSelect)
        {
            ((Rectangle)listContainer.Children[indexToSelect]).Fill = new SolidColorBrush(Colours.Red);
        }

        protected void CompareElement(int indexToCompare)
        {
            ((Rectangle)listContainer.Children[indexToCompare]).Fill = new SolidColorBrush(Colours.Green);
        }

        /// <summary>
        /// This method updates the whole container with the list
        /// </summary>
        /// <param name="list"></param>
        protected void UpdateContainer(IList<int> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                Rectangle rectangle = (Rectangle)listContainer.Children[i];
                rectangle.Fill = new SolidColorBrush(Colours.Default);
                rectangle.Margin = new Thickness(0, listContainer.Height - (list[i] * unitHeight), 0, 0);
            }
        }
        #endregion 

    }
}
