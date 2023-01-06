using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PunLogic punLogic = new PunLogic();
        PunEntry activeEntry = null;

        public MainWindow()
        {
            InitializeComponent();

            UpdateTags();
            UpdateCategories();
        }

        private void UpdateTags()
        {
            string[] topics = punLogic.GetAllTags();
            wrpTags.Children.Clear();
            foreach (string topic in topics)
            {
                wrpTags.Children.Add(new Tag(topic));
            }
        }

        private void UpdateCategories()
        {
            string[] topics = punLogic.GetAllCategories();
            wrpCategories.Children.Clear();
            foreach (string topic in topics)
            {
                wrpCategories.Children.Add(new Tag(topic));
            }
        }

        //private void btnSearchByCriteria_Click(object sender, RoutedEventArgs e)
        //{
        //    List<string> tags = new List<string>();
        //    foreach (Tag tag in this.wrpTags.Children)
        //    {
        //        if (tag.Selected)
        //        {
        //            tags.Add(tag.Text);
        //        }
        //    }

        //    List<string> categories = new List<string>();
        //    foreach (Tag category in this.wrpCategories.Children)
        //    {
        //        if (tag.Selected)
        //        {
        //            categories.Add(category.Text);
        //        }
        //    }

        //    PunEntry entry = punLogic.GetRandom(qtslQuality.Min, qtslQuality.Max, tags.ToArray(), categories.ToArray());
        //    tbxPunDisplay.Text = entry.Text;
        //}

        private void btnFetchAPun_Click(object sender, RoutedEventArgs e)
        {
            List<string> tags = new List<string>();
            foreach (Tag tag in this.wrpTags.Children)
            {
                if (tag.Selected)
                {
                    tags.Add(tag.Text);
                }
            }

            List<string> categories = new List<string>();
            foreach (Tag category in this.wrpCategories.Children)
            {
                if (category.Selected)
                {
                    categories.Add(category.Text);
                }
            }

            activeEntry = punLogic.GetRandom(qtslQuality.Min, qtslQuality.Max, tags.ToArray(), categories.ToArray());
            UpdateDisplayedInfo();
        }

        private void UpdateDisplayedInfo()
        {
            if (activeEntry != null && activeEntry.UID > 0)
            {
                tbxPunDisplay.Text = activeEntry.Text;
                lblQuality.Content = "Quality: " + (activeEntry.Quality + 1);
                wrpEntryTags.Children.Clear();
                foreach (string tag in activeEntry.SplitTags)
                {
                    wrpEntryTags.Children.Add(new BasicTag(tag));
                }
                if (activeEntry.Used)
                {
                    imgComplete.Visibility = Visibility.Visible;
                    btnMarkUsed.Content = "Mark Unused";
                }
                else
                {
                    imgComplete.Visibility = Visibility.Hidden;
                    btnMarkUsed.Content = "Mark Used";
                }
            }
        }

        private void btnMarkUsed_Click(object sender, RoutedEventArgs e)
        {
            if (activeEntry != null && activeEntry.UID > 0)
            {
                activeEntry = punLogic.MarkUsed(activeEntry, !activeEntry.Used);
            }

            UpdateDisplayedInfo();
            UpdateTags();
            UpdateCategories();
        }

        private void btnClearTags_Click(object sender, RoutedEventArgs e)
        {
            foreach (Tag tag in this.wrpTags.Children)
            {
                if (tag.Selected)
                {
                    tag.ToggleSelection();
                }
            }
        }

        private void btnClearQuality_Click(object sender, RoutedEventArgs e)
        {
            qtslQuality.Clear();
        }

        private void btnAllTags_Click(object sender, RoutedEventArgs e)
        {
            foreach(Tag tag in this.wrpTags.Children)
            {
                if (!tag.Selected)
                {
                    tag.ToggleSelection();
                }
            }
        }
    }
}
