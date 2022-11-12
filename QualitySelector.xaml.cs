using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;

namespace The_Oracle
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class QualitySelector : UserControl
    {
        private string unselected = "#FF575963";
        private string selected = "#FF20359A";

        public int Min { get; private set; }
        public int Max { get; private set; }

        public QualitySelector()
        {
            InitializeComponent();
            Clear();
        }

        public void Clear()
        {
            rctOption1.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOption2.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOption3.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOption4.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOption5.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOptionModerate.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);

            Min = 0;
            Max = 4;
        }

        private void btnOption1_Click(object sender, RoutedEventArgs e)
        {
            rctOption1.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(selected);
            rctOption2.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOption3.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOption4.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOption5.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOptionModerate.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);

            Min = 0;
            Max = 0;
        }

        private void btnOption2_Click(object sender, RoutedEventArgs e)
        {
            rctOption1.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOption2.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(selected);
            rctOption3.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOption4.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOption5.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOptionModerate.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);

            Min = 1;
            Max = 1;
        }

        private void btnOption3_Click(object sender, RoutedEventArgs e)
        {
            rctOption1.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOption2.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOption3.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(selected);
            rctOption4.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOption5.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOptionModerate.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);

            Min = 2;
            Max = 2;
        }

        private void btnOption4_Click(object sender, RoutedEventArgs e)
        {
            rctOption1.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOption2.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOption3.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOption4.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(selected);
            rctOption5.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOptionModerate.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);

            Min = 3;
            Max = 3;
        }

        private void btnOptionModerate_Click(object sender, RoutedEventArgs e)
        {
            rctOption1.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOption2.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(selected);
            rctOption3.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(selected);
            rctOption4.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(selected);
            rctOption5.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOptionModerate.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(selected);

            Min = 1;
            Max = 3;
        }

        private void btnOption5_Click(object sender, RoutedEventArgs e)
        {
            rctOption1.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOption2.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOption3.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOption4.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);
            rctOption5.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(selected);
            rctOptionModerate.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(unselected);

            Min = 4;
            Max = 4;
        }
    }
}
