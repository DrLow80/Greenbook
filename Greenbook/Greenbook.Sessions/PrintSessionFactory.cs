using Greenbook.Entities;
using Greenbook.Extensions;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Greenbook.Sessions
{
    public class PrintSessionFactory
    {
        private static readonly double FiveInches = ConvertLength("5in");
        private static readonly double FourInches = ConvertLength("4in");
        private static readonly double ThreeAndHalfInches = ConvertLength("3.5in");

        private static double ConvertLength(string value)
        {
            LengthConverter lengthConverter = new LengthConverter();

            double result = (double)lengthConverter.ConvertFrom(value);

            return result;
        }

        public static FlowDocument Print(PrintSessionRequest printSessionRequest)
        {
            var flowDocument = new FlowDocument();

            var blocks = BuildBlocks(printSessionRequest);

            flowDocument.Blocks.AddRange(blocks);

            return flowDocument;
        }

        private static IEnumerable<Block> BuildBlocks(PrintSessionRequest printSessionRequest)
        {
            yield return BuildSessionBlock(printSessionRequest.Session);

            foreach (var encounter in printSessionRequest.Encounters) yield return BuildEncounterBlock(encounter);

            foreach (var contentItems in printSessionRequest.ContentItems.ToBatches(4))
                yield return BuildContentItemsBlock(contentItems);
        }

        private static Block BuildContentItemBlock(ContentItem contentItem)
        {
            var uri = new Uri(contentItem.ImageSource);

            var bitmapImage = new BitmapImage(uri);

            var image = new Image { Source = bitmapImage };

            var viewbox = new Viewbox { Child = image };

            var textBlock = new TextBlock
            {
                Text = contentItem.Name,
                Margin = new Thickness(5),
                TextWrapping = TextWrapping.Wrap
            };

            var border = new Border
            {
                Child = textBlock,
                Background = Brushes.White,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            var grid = new Grid
            {
                Height = FiveInches,
                Width = FourInches,
                Background = Brushes.Red
            };

            grid.Children.Add(viewbox);

            grid.Children.Add(border);

            var blockUiContainer = new BlockUIContainer(grid);

            return blockUiContainer;
        }

        private static UIElement BuildImage(string imageSource)
        {
            Viewbox viewbox = new Viewbox();

            if (string.IsNullOrEmpty(imageSource))
            {
                return viewbox;
            }

            var uri = new Uri(imageSource);

            var bitmapImage = new BitmapImage(uri);

            var image = new Image { Source = bitmapImage };

            viewbox = new Viewbox { Child = image };

            return viewbox;
        }

        private static UIElement BuildContentItemGrid(ContentItem contentItem)
        {


            var textBlock = new TextBlock
            {
                Text = contentItem.Name,
                Margin = new Thickness(5),
                TextWrapping = TextWrapping.Wrap
            };

            var border = new Border
            {
                Child = textBlock,
                Background = Brushes.White,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            var grid = new Grid
            {
                Height = FiveInches,
                Width = ThreeAndHalfInches,
                Margin = new Thickness(2)
            };

            grid.Children.Add(BuildImage(contentItem.ImageSource));

            grid.Children.Add(border);

            border = new Border
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                Child = grid
            };

            return border;
        }

        private static Block BuildContentItemsBlock(IEnumerable<ContentItem> contentItems)
        {
            var wrapPanel = new WrapPanel();

            foreach (var contentItem in contentItems)
            {
                var grid = BuildContentItemGrid(contentItem);

                wrapPanel.Children.Add(grid);
            }

            var blockUiContainer = new BlockUIContainer(wrapPanel)
            {
                BreakPageBefore = true
            };

            return blockUiContainer;
        }

        private static Block BuildEncounterBlock(Encounter encounter)
        {
            var paragraph = new Paragraph();

            var run = new Run(encounter.Name);

            paragraph.Inlines.Add(run);

            paragraph.Inlines.Add(new LineBreak());

            run = new Run(encounter.Description);

            paragraph.Inlines.Add(run);

            return paragraph;
        }

        private static Block BuildSessionBlock(Session session)
        {
            var paragraph = new Paragraph();

            var run = new Run(session.Name);

            paragraph.Inlines.Add(run);

            return paragraph;
        }
    }
}