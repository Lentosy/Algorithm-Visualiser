using AlgorithmsVisualiser.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AlgorithmsVisualiser.Sorting.Algorithms
{
    public abstract class SortAlgorithm
    {


        /// <summary>
        /// The delay for each significant operation in milliseconds
        /// </summary>
        public int Delay { get; set; }

        protected SortView sortView;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="listContainer">The container that holds the visual list</param>
        /// <param name="delay">The default delay for each significant operation in milliseconds</param>
        protected SortAlgorithm(SortView listContainer, int delay = 10)
        {
            sortView = listContainer;
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
        /// Waits for the given amount of the property Delay
        /// </summary>
        public async Task Wait() {
            await Task.Delay(Delay);
            return;
        }

        /// <summary>
        /// This method will intiliaze the default GUI before sorting the list.
        /// </summary>
        /// <param name="list"></param>
        public void InitializeContainer(IList<int> list)
        {
            sortView.InitializeView(list);
        }
        #endregion

        #region Protected methods
        protected void SelectElement(int indexToSelect)
        {
            ((Rectangle)sortView.Children[indexToSelect]).Fill = new SolidColorBrush(Colours.Red);
        }

        protected void CompareElement(int indexToCompare)
        {
            ((Rectangle)sortView.Children[indexToCompare]).Fill = new SolidColorBrush(Colours.Green);
        }

        /// <summary>
        /// This method updates the whole container with the list
        /// </summary>
        /// <param name="list"></param>
        protected void UpdateContainer(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Rectangle rectangle = (Rectangle)sortView.Children[i];
                rectangle.Fill = new SolidColorBrush(Colours.Default);
                rectangle.Margin = new Thickness(0, sortView.Height - (list[i] * sortView.UnitHeight), 0, 0);
            }
        }
        #endregion 

    }
}
