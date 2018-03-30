using AlgorithmsVisualiser.Sorting;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AlgorithmsVisualiser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> list = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
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

            double unitHeight = listContainer.Height / list.Max();
            double unitWidth = listContainer.Width / list.Count;
            
            foreach(int i in list)
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

        void FillListInAscendingOrder(List<int> l)
        {
            for (int i = 0; i < listContainer.Width; i++)
            {
                l.Add(i);
            }
        }
        
    }
}
