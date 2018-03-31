﻿using AlgorithmsVisualiser.Helpers;
using AlgorithmsVisualiser.Sorting;
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
        /// <summary>
        /// The to be sorted list
        /// </summary>
        private List<int> list = new List<int>();



        /// <summary>
        /// Delay in milliseconds
        /// </summary>
        private int msDelay = 10;

        public MainWindow()
        {
            InitializeComponent();

            
        }


        /// <summary>
        /// Fills the list with elements in random order (64, 1, ..., 9, ...)
        /// </summary>
        /// <param name="list">The list to fill</param>
        /// <param name="elementCount">The amount of elements to fill</param>
        /// <param name="minValue">The minimum value of the random range</param>
        /// <param name="maxValue">The maximum value of the random range</param>
        private void FillListWithRandomValues(List<int> list, int elementCount = 50, int minValue = 1, int maxValue = 100)
        {
            Random random = new Random();
            for (int i = 0; i < elementCount; i++)
            {
                list.Add(random.Next(minValue, maxValue));
            }
        }

        /// <summary>
        /// Fills the list with elements in ascending order (1, 2, ..., 100)
        /// </summary>
        /// <param name="list">The list to fill</param>
        /// <param name="elementCount">The amount of elements to fill</param>
        private void FillListInAscendingOrder(List<int> list, int elementCount = 50)
        {
            for (int i = 0; i < elementCount; i++)
            {
                list.Add(i + 1);
            }
        }

        /// <summary>
        /// Fills the list with numbers in descending order (100, 99, ..., 1)
        /// </summary>
        /// <param name="list">The list to fill</param>
        /// <param name="elementCount">The amount of elements to fill</param>
        private void FillListInDescendingOrder(List<int> list, int elementCount = 50)
        {
            for (int i = elementCount; i > 0; i--)
            {
                list.Add(i);
            }
        }

        /// <summary>
        /// Starts the sorting process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStartSort_Click(object sender, RoutedEventArgs e)
        {
            SortAlgorithm sortmethod = new InsertionSort(listContainer);
            FillListWithRandomValues(list);
            sortmethod.Sort(list);
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
            switch (cItem.Tag)
            {
                case "ASC":
                    FillListInAscendingOrder(list, elementCount);
                    break;
                case "DESC":
                    FillListInDescendingOrder(list, elementCount);
                    break;
                case "RAND":
                    FillListWithRandomValues(list, elementCount);
                    break;
            }
        }

        private void SliderElementCount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LabelElementCount.Content = (int)SliderElementCount.Value;
        }
        

        private void SliderSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            msDelay = (int)SliderSpeed.Value;
            LabelSpeed.Content = msDelay;
        }


    }
}