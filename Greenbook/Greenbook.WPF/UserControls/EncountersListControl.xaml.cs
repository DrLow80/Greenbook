using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Greenbook.WPF.UserControls
{
    /// <summary>
    /// Interaction logic for EncountersListControl.xaml
    /// </summary>
    public partial class EncountersListControl : UserControl
    {
        public EncountersListControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty RemoveCommandProperty = DependencyProperty.Register(
            "RemoveCommand", typeof(ICommand), typeof(EncountersListControl), new PropertyMetadata(default(ICommand)));

        public ICommand RemoveCommand
        {
            get { return (ICommand)GetValue(RemoveCommandProperty); }
            set { SetValue(RemoveCommandProperty, value); }
        }

        public static readonly DependencyProperty AddCommandProperty = DependencyProperty.Register(
            "AddCommand", typeof(ICommand), typeof(EncountersListControl), new PropertyMetadata(default(ICommand)));

        public ICommand AddCommand
        {
            get { return (ICommand)GetValue(AddCommandProperty); }
            set { SetValue(AddCommandProperty, value); }
        }
    }
}