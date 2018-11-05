using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Greenbook.ContentItems;
using Greenbook.Entities;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using Microsoft.Win32;

namespace Greenbook.WPF.Features.ContentItems
{
    public class ContentItemsRepository : IContentItemsRepository
    {
        public IEnumerable<ContentItem> LoadContentItems()
        {
            return RandomUtilities.RandomList(5, 10, RandomUtilities.RandomContentItem);
        }

        public Result<string> SelectImage()
        {
            return Result.Ok(ShowDialog(new OpenFileDialog()));
        }

        private static string ShowDialog(FileDialog fileDialog)
        {
            Guard.ArgumentNotNull(fileDialog, nameof(fileDialog));

            var result = fileDialog.ShowDialog();

            return result == true
                ? fileDialog.FileName
                : string.Empty;
        }
    }
}