using AlgorithmsVisualiser.Helpers;
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
        /// The height that the value '1' should take. 
        /// Example: If the value of a listitem is 14, the height will be 14 * unitHeight
        /// </summary>
        private double unitHeight;

        /// <summary>
        /// The width that one bar representing a value should take
        /// </summary>
        private double unitWidth;

        /// <summary>
        /// Delay in milliseconds
        /// </summary>
        private int msDelay = 10;

        public MainWindow()
        {
            InitializeComponent();

            SliderSpeed.Value = msDelay;
            LabelSpeed.Content = msDelay;
        }

        void UpdateContainer(IList<int> list)
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
            for (int i = 1; i < list.Count; i++)
            {
                int h = list[i];
                SelectElement(i);
                await Task.Delay(msDelay);

                int j = i - 1;
                while (j >= 0 && h < list[j])
                {
                    CompareElement(j);
                    await Task.Delay(msDelay);
                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = h;
                UpdateContainer(list);
            }
        }

        private void FillListWithRandomValues(List<int> list, int elementCount = 50, int minValue = 1, int maxValue = 100)
        {
            Random random = new Random();
            for (int i = 0; i < elementCount; i++)
            {
                list.Add(random.Next(minValue, maxValue));
            }
        }

        private void FillListInAscendingOrder(List<int> list, int elementCount = 50)
        {
            for (int i = 0; i < elementCount; i++)
            {
                list.Add(i + 1);
            }
        }

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
            InsertionSort(list);
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
            UpdateContainer(list);

        }

        private void SliderSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            msDelay = (int)SliderSpeed.Value;
            LabelSpeed.Content = msDelay;
        }
    }
}