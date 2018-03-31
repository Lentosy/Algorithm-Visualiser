using AlgorithmsVisualiser.Helpers;
using AlgorithmsVisualiser.Sorting;
using AlgorithmsVisualiser.Sorting.Filling;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

            list.Fill(new AscendingFillStrategy(), 50);
            currentSortAlgorithm.InitializeContainer(list);
        }

        #region Private methods
        private void InitializeSortingAlgorithms()
        {
            ComboBoxSortingAlgorithms.Items.Add(new ComboBoxItem()
            {
                Tag = ESortingAlgorithm.INSERTION_SORT,
                Content = "Insertion Sort",
                IsSelected = true
            });

            ComboBoxSortingAlgorithms.Items.Add(new ComboBoxItem()
            {
                Tag = ESortingAlgorithm.SELECTION_SORT,
                Content = "Selection Sort",
            });

            currentSortAlgorithm = new InsertionSort(listContainer);
        }

        private void InitializeListOrders()
        {
            ComboBoxListOrder.Items.Add(new ComboBoxItem
            {
                Tag = EOrder.ASCENDING,
                Content = "Ascending",
                IsSelected = true
            });
            ComboBoxListOrder.Items.Add(new ComboBoxItem
            {
                Tag = EOrder.DESCENDING,
                Content = "Descending"
            });
            ComboBoxListOrder.Items.Add(new ComboBoxItem
            {
                Tag = EOrder.RANDOM,
                Content = "Random"
            });
            ComboBoxListOrder.Items.Add(new ComboBoxItem
            {
                Tag = EOrder.CONCAVE,
                Content = "Concave"
            });
            ComboBoxListOrder.Items.Add(new ComboBoxItem
            {
                Tag = EOrder.CONVEX,
                Content = "Convex"
            });
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

        private void SliderElementCount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LabelElementCount.Content = (int)SliderElementCount.Value;
        }
        

        private void SliderSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            msDelay = (int)SliderSpeed.Value;
            LabelSpeed.Content = msDelay;
            if(currentSortAlgorithm != null)
            {
                currentSortAlgorithm.Delay = msDelay;
            }

        }

        private void ComboBoxSortingAlgorithms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cItem = (ComboBoxItem)ComboBoxSortingAlgorithms.SelectedItem;
            switch (cItem.Tag) {
                case ESortingAlgorithm.INSERTION_SORT:
                    currentSortAlgorithm = new InsertionSort(listContainer);
                    break;
                case ESortingAlgorithm.SELECTION_SORT:
                    currentSortAlgorithm = new SelectionSort(listContainer);
                    break;
            }

        }
        #endregion
    }
}