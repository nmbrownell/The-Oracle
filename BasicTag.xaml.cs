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

namespace The_Oracle
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class BasicTag : UserControl
    {
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

        public BasicTag(string Text)
        {
            InitializeComponent();
            this.Text = Text;
        }
    }
}
