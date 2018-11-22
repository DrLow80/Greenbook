using Greenbook.Entities;
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
        public static FlowDocument Print(PrintSessionRequest printSessionRequest)
        {
            FlowDocument flowDocument = new FlowDocument
            {
                //PageHeight = (double)new LengthConverter().ConvertFrom("11in"),
                //PageWidth = (double)new LengthConverter().ConvertFrom("8.5in"),
                //PagePadding = new Thickness(0),
                //ColumnGap =  0,
            };

            IEnumerable<Block> blocks = BuildBlocks(printSessionRequest);

            flowDocument.Blocks.AddRange(blocks);

            return flowDocument;
        }

        private static IEnumerable<Block> BuildBlocks(PrintSessionRequest printSessionRequest)
        {
            yield return BuildSessionBlock(printSessionRequest.Session);

            foreach (var encounter in printSessionRequest.Encounters)
            {
                yield return BuildEncounterBlock(encounter);
            }

            //foreach (var contentItem in printSessionRequest.ContentItems)
            //{
            //    yield return BuildContentItemBlock(contentItem);
            //}

            yield return BuildContentItemsBlock(printSessionRequest.ContentItems);
        }

        private static Block BuildContentItemsBlock(IEnumerable<ContentItem> contentItems)
        {
            WrapPanel wrapPanel = new WrapPanel();

            foreach (var contentItem in contentItems)
            {
                var grid = BuildContentItemGrid(contentItem);

                wrapPanel.Children.Add(grid);
            }

            BlockUIContainer blockUiContainer = new BlockUIContainer(wrapPanel)
            {
                BreakPageBefore = true
            };

            return blockUiContainer;
        }

        private static UIElement BuildContentItemGrid(ContentItem contentItem)
        {
            Uri uri = new Uri("C:\\Users\\947665\\Pictures\\IMG_0876.JPG");

            BitmapImage bitmapImage = new BitmapImage(uri);

            Image image = new Image { Source = bitmapImage };

            Viewbox viewbox = new Viewbox { Child = image };

            TextBlock textBlock = new TextBlock
            {
                Text = contentItem.Name,
                Margin = new Thickness(5),
                TextWrapping = TextWrapping.Wrap
            };

            Border border = new Border
            {
                Child = textBlock,
                Background = Brushes.White,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            var height = (double)new LengthConverter().ConvertFrom("5in");

            var width = (double)new LengthConverter().ConvertFrom("3.5in");

            Grid grid = new Grid
            {
                Height = height,
                Width = width,
                Margin = new Thickness(2)
            };

            grid.Children.Add(viewbox);

            grid.Children.Add(border);

            border = new Border
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                Child = grid
            };

            return border;
        }

        private static Block BuildContentItemBlock(ContentItem contentItem)
        {
            Uri uri = new Uri("C:\\Users\\947665\\Pictures\\IMG_0876.JPG");

            BitmapImage bitmapImage = new BitmapImage(uri);

            Image image = new Image { Source = bitmapImage };

            Viewbox viewbox = new Viewbox { Child = image };

            TextBlock textBlock = new TextBlock
            {
                Text = contentItem.Name,
                Margin = new Thickness(5),
                TextWrapping = TextWrapping.Wrap
            };

            Border border = new Border
            {
                Child = textBlock,
                Background = Brushes.White,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            var height = (double)new LengthConverter().ConvertFrom("5in");

            var width = (double)new LengthConverter().ConvertFrom("4in");

            Grid grid = new Grid
            {
                Height = height,
                Width = width,
                Background = Brushes.Red
            };

            grid.Children.Add(viewbox);

            grid.Children.Add(border);

            BlockUIContainer blockUiContainer = new BlockUIContainer(grid);

            return blockUiContainer;
        }

        private static Block BuildEncounterBlock(Encounter encounter)
        {
            Paragraph paragraph = new Paragraph();

            Run run = new Run(encounter.Name);

            paragraph.Inlines.Add(run);

            paragraph.Inlines.Add(new LineBreak());

            run = new Run(encounter.Description);

            paragraph.Inlines.Add(run);

            return paragraph;
        }

        private static Block BuildSessionBlock(Session session)
        {
            Paragraph paragraph = new Paragraph();

            Run run = new Run(session.Name);

            paragraph.Inlines.Add(run);

            return paragraph;
        }
    }
}