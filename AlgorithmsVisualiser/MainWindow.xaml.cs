using AlgorithmsVisualiser.Helpers;
using AlgorithmsVisualiser.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

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
        /// The height that the value '1' should take. 
        /// Example: If the value of a listitem is 14, the height will be 14 * unitHeight
        /// </summary>
        private double unitHeight;

        /// <summary>
        /// The width that one bar representing a value should take
        /// </summary>
        private double unitWidth;

        public MainWindow()
        {
            InitializeComponent();

            // add random values
            {
                list.Add(10);
                list.Add(5);
                list.Add(7);
                list.Add(6);
                list.Add(1);
                list.Add(3);
                list.Add(17);
                list.Add(9);
                list.Add(15);
                list.Add(30);
                list.Add(20);
            }

            unitHeight = listContainer.Height / list.Max();
            unitWidth  = listContainer.Width / list.Count;

            UpdateContainer(list);
            InsertionSort(list);
            UpdateContainer(list);
        }



        void UpdateContainer(IList<int> list)
        {
            listContainer.Children.Clear();
            foreach (int i in list)
            {
                Label listItem = new Label
                {
                    Background = SystemColors.ActiveBorderBrush,
                    // Margin and not height so the label starts from bottom
                    Margin = new Thickness(0, listContainer.Height - (i * unitHeight), 0, 0),
                    Content = i,
                    Width = unitWidth
                };
                listContainer.Children.Add(listItem);
            }
        }

        void SelectElement(int indexToSelect)
        {
            ((Label)listContainer.Children[indexToSelect]).Background = new SolidColorBrush(Colours.Red);
        }

        void CompareElement(int indexToCompare)
        {
            ((Label)listContainer.Children[indexToCompare]).Background = new SolidColorBrush(Colours.Green);
        }

        private async void InsertionSort(IList<int> list)
        {
            await Task.Delay(5000);
            for (int i = 1; i < list.Count; i++)
            {
                UpdateContainer(list);
                int h = list[i];
                await Task.Delay(1000);
                SelectElement(i);

                int j = i - 1;
                while(j >= 0 && h < list[j])
                {
                    CompareElement(j);
                    await Task.Delay(1000);
                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = h;
            }   
        }

        private void FillListInAscendingOrder(List<int> l)
        {
            for (int i = 0; i < listContainer.Width; i++)
            {
                l.Add(i);
            }
        }
        
    }
}



/*
 * OPERATIONS:
 *  ACCESS AN ELEMENT
 *  COMPARE AN ELEMENT WITH AN OTHER ELEMENT
 *  SWAP AN ELEMENT WITH ANOTHER ELEMENT
 *  
 * 
 * 
 * 
 */ 