using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Greenbook.Feature.ContentMentionTextBox
{
    /// <summary>
    /// Interaction logic for ContentMentionUserControl.xaml
    /// </summary>
    public partial class ContentMentionUserControl : UserControl
    {
        public ContentMentionUserControl()
        {
            InitializeComponent();

            var items = new List<string>
            {
                "@One",
                "@Two",
                "@Three"
            };

            ListBox.ItemsSource = items;

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(ListBox.ItemsSource);

            collectionView.Filter = FilterItem;
        }

        public static readonly DependencyProperty IsFilteringProperty = DependencyProperty.Register(
            "IsFiltering", typeof(bool), typeof(ContentMentionUserControl));

        public bool IsFiltering
        {
            get { return (bool) GetValue(IsFilteringProperty); }
            set { SetValue(IsFilteringProperty, value); }
        }

        private string filter;

        private int cursorPosition;

        private void UIElement_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Escape)
            {
                IsFiltering = false;

                Debug.WriteLine("Disabled Filtering");
            }
 
            if ((Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)) && e.Key == Key.D2)
            {

                IsFiltering = true;

                filter = string.Empty;

                cursorPosition = TextBox.CaretIndex;

                Debug.WriteLine("Enabled Filtering");
            }
        }

        private bool FilterItem(object obj)
        {
            if (string.IsNullOrWhiteSpace(filter))
            {
                return true;
            }

            return ((string)obj).ToLowerInvariant().Contains(filter);
        }

        private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Debug.WriteLine("TextBox_OnTextChanged");

            if (IsFiltering)
            {
                filter = TextBox.Text.Substring(cursorPosition).ToLowerInvariant();

                ICollectionView collectionView = CollectionViewSource.GetDefaultView(ListBox.ItemsSource);

                collectionView.Refresh();

                ListBox.SelectedIndex = 0;


                Debug.WriteLine($"Refreshed filter: {filter}");
            }
        }
    }
}