using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace The_Oracle
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Tag : UserControl
    {
        private readonly string NeutralColor = "#FF80859E";
        private readonly string SelectedColor = "#FF20359A";
        
        public bool Selected { get; private set; }

        public string Text
        {
            get
            {
                return tbxContent.Text;
            }
            set
            {
                tbxContent.Text = value;
            }
        }

        public Tag(string Text)
        {
            InitializeComponent();
            this.Text = Text;
        }

        private void btnClickCapture_Click(object sender, RoutedEventArgs e)
        {
            ToggleSelection();
        }

        public void ToggleSelection()
        {
            if (Selected)
            {
                Selected = false;
                rtglBackground.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(NeutralColor);
            }
            else
            {
                Selected = true;
                rtglBackground.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(SelectedColor);
            }
        }
    }
}
