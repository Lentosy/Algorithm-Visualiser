using AlgorithmsVisualiser.Helpers;
using AlgorithmsVisualiser.Sorting;
using AlgorithmsVisualiser.Sorting.Algorithms;
using AlgorithmsVisualiser.Sorting.Filling;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AlgorithmsVisualiser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Attributes
        /// <summary>
        /// The to be sorted list
        /// </summary>
        private SortList list = new SortList();

        private SortAlgorithm currentSortAlgorithm;
        #endregion

        public MainWindow()
        {



            InitializeComponent();

            ResizeMode = ResizeMode.NoResize;

            InitializeSortingAlgorithms();
            InitializeListOrders();

            currentSortAlgorithm = new InsertionSort(listContainer);
            list.Fill(new AscendingFillStrategy(), 50);
            currentSortAlgorithm.InitializeContainer(list);


        }

        #region Private methods
        private void InitializeSortingAlgorithms()
        {
            foreach (ESortingAlgorithm sortingAlgorithm in Enum.GetValues(typeof(ESortingAlgorithm)))
            {
                string[] parts = sortingAlgorithm.ToString().Split('_');
                StringBuilder name = new StringBuilder();
                foreach (string s in parts)
                {
                    name.Append(s.InitCap());
                    name.Append(" ");
                }

                ComboBoxSortingAlgorithms.Items.Add(new ComboBoxItem
                {
                    Tag = sortingAlgorithm,
                    Content = name.ToString(),
                });
            }

            ((ComboBoxItem)ComboBoxSortingAlgorithms.Items[0]).IsSelected = true;
        }

        private void InitializeListOrders()
        {
            foreach (EOrder order in Enum.GetValues(typeof(EOrder)))
            {
                string name = order.ToString().ToLower();

                ComboBoxListOrder.Items.Add(new ComboBoxItem
                {
                    Tag = order,
                    Content = order.ToString().InitCap()
                });
            }

            ((ComboBoxItem)ComboBoxListOrder.Items[0]).IsSelected = true;
        }
        #endregion

        #region Events
        /// <summary>
        /// Starts the sorting process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStartSort_Click(object sender, RoutedEventArgs e)
        {
            currentSortAlgorithm.Sort(list);
        }

        /// <summary>
        /// Generates a list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonGenerateList_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cItem = (ComboBoxItem)ComboBoxListOrder.SelectedItem;
            int elementCount = (int)SliderElementCount.Value;

            list.Clear();

            IFillStrategy fillStrategy;
            //should make this even better somehow
            switch (cItem.Tag)
            {
                case EOrder.ASCENDING:
                    fillStrategy = new AscendingFillStrategy();
                    break;
                case EOrder.DESCENDING:
                    fillStrategy = new DescendingFillStrategy();
                    break;
                case EOrder.RANDOM:
                    fillStrategy = new RandomFillStrategy();
                    break;
                case EOrder.CONCAVE:
                    fillStrategy = new ConcaveFillStrategy();
                    break;
                case EOrder.CONVEX:
                    fillStrategy = new ConvexFillStrategy();
                    break;
                default:
                    fillStrategy = new AscendingFillStrategy();
                    break;
            }
            list.Fill(fillStrategy, elementCount);
            currentSortAlgorithm.InitializeContainer(list);
        }

        private void ComboBoxSortingAlgorithms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cItem = (ComboBoxItem)ComboBoxSortingAlgorithms.SelectedItem;
            switch (cItem.Tag)
            {
                case ESortingAlgorithm.INSERTION_SORT:
                    currentSortAlgorithm = new InsertionSort(listContainer);
                    break;
                case ESortingAlgorithm.SELECTION_SORT:
                    currentSortAlgorithm = new SelectionSort(listContainer);
                    break;
                case ESortingAlgorithm.BOGO_SORT:
                    currentSortAlgorithm = new BogoSort(listContainer);
                    break;
            }

        }

        private void SliderElementCount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LabelElementCount.Content = (int)SliderElementCount.Value;
        }


        private void SliderSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int msDelay = (int)SliderSpeed.Value;
            LabelSpeed.Content = msDelay;
            if(currentSortAlgorithm != null)
            {
                currentSortAlgorithm.Delay = msDelay;
            }
        }

        #endregion


    }
}