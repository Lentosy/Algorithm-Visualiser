﻿using AlgorithmsVisualiser.Helpers;
using AlgorithmsVisualiser.Sorting;
using AlgorithmsVisualiser.Sorting.Algorithms;
using AlgorithmsVisualiser.Sorting.Filling;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

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

        private IList<SortAlgorithm> allSortAlgorithms;
        private SortAlgorithm currentSortAlgorithm;
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            // programmatically sets the margin of each menu item, which is encapsulated in a StackPanel, by drawing 
            // a small rectangle beneath it (acting as a line)
            foreach(StackPanel s in menuContainer.Children)
            {    
                s.Children.Add(new Rectangle
                {
                    Fill = new SolidColorBrush(Colours.Default),
                    Height = 2,
                    Margin = new Thickness(0, 10, 0, 0)
                    
                });
            }


            InitializeSortingAlgorithms();
            InitializeListOrders();

            list.Fill(new AscendingFillStrategy(), 50);
            currentSortAlgorithm = allSortAlgorithms[0]; // Insertion Sort
            currentSortAlgorithm.InitializeContainer(list);
        }

        #region Private methods
        private void InitializeSortingAlgorithms()
        {
            allSortAlgorithms = SortAlgorithms.GetSortAlgorithms(listContainer);
            int index = 0;
            foreach(SortAlgorithm sortAlgorithm in allSortAlgorithms)
            {
                ComboBoxSortingAlgorithms.Items.Add(new ComboBoxItem
                {
                    Content = sortAlgorithm.Name,
                    Tag = index++       // Tag contains the index this algorithm takes in the allAlgorithms list   
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
            currentSortAlgorithm = allSortAlgorithms[(int)cItem.Tag];
        }

        private void SliderElementCount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LabelElementCount.Content = (int)SliderElementCount.Value;
        }

        private void SliderSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int msDelay = (int)SliderSpeed.Value;
            LabelSpeed.Content = msDelay;
            if (currentSortAlgorithm != null)
            {
                currentSortAlgorithm.Delay = msDelay;
            }
        }

        #endregion


    }
}