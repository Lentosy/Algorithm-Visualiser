
using AlgorithmsVisualiser.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AlgorithmsVisualiser.Sorting
{
    public class SortView : StackPanel
    {

        /// <summary>
        /// The height that the value '1' should take. 
        /// Example: If the value of a listitem is 14, the height will be 14 * unitHeight
        /// </summary>
        
        public double UnitHeight { get; set; }

        /// <summary>
        /// The width that one bar representing a value should take
        /// </summary>
        public double UnitWidth { get; set; }

        public void InitializeView(IList<int> list)
        {
            UnitHeight = Height / list.Max();
            UnitWidth = Width / list.Count;
            Children.Clear();
            foreach (int i in list)
            {
                Rectangle listItem = new Rectangle
                {
                    Stroke = new SolidColorBrush(Colours.White), // outline
                    Fill = new SolidColorBrush(Colours.Default), 
                    // Margin and not height so the label starts from bottom
                    // The next line sets the top margin for each label. 
                    Margin = new Thickness(0, Height - (i * UnitHeight), 0, 0),

                    Width = UnitWidth
                };
                Children.Add(listItem);
            }
        }

    }
}
