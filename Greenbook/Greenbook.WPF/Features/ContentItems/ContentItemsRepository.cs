using CSharpFunctionalExtensions;
using Greenbook.ContentItems;
using Greenbook.Entities;
using Greenbook.Sessions;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using Microsoft.Win32;
using System.Collections.Generic;
using Greenbook.RandomTools;
using Spring.Context.Attributes;

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

        public IEnumerable<string> LoadContentItemTypes()
        {
            return RandomUtilities.RandomList(5, 10, RandomUtilities.RandomLipsum);
        }

        public Result Insert(ContentItem contentItem)
        {
            return Result.Ok();
        }

        public Result Remove(ContentItem contentItem)
        {
            return Result.Ok();
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

    [Configuration]
    public class DataDefinition
    {
        [Definition]
        public virtual TestDataRepo TestDataRepo()
        {
            return new TestDataRepo();
        }
    }

    public class TestDataRepo : IContentItemsRepository, ISessionRepository, IRandomToolsRepository
    {
        public IEnumerable<Session> LoadSessions()
        {
            return RandomUtilities.RandomList(5, 10, RandomUtilities.RandomSession);
        }

        public IEnumerable<ContentItem> LoadContentItems()
        {
            return RandomUtilities.RandomList(5, 10, RandomUtilities.RandomContentItem);
        }

        public Result Insert(Session session)
        {
            return Result.Ok();
        }

        public Result Remove(Session session)
        {
            return Result.Ok();
        }

        public Result<string> SelectImage()
        {
            return Result.Ok(ShowDialog(new OpenFileDialog()));
        }

        public IEnumerable<string> LoadContentItemTypes()
        {
            return RandomUtilities.RandomList(5, 10, RandomUtilities.RandomLipsum);
        }

        public Result Insert(ContentItem contentItem)
        {
            return Result.Ok();
        }

        public Result Remove(ContentItem contentItem)
        {
            return Result.Ok();
        }

        private static string ShowDialog(FileDialog fileDialog)
        {
            Guard.ArgumentNotNull(fileDialog, nameof(fileDialog));

            var result = fileDialog.ShowDialog();

            return result == true
                ? fileDialog.FileName
                : string.Empty;
        }

        public string GetMessage()
        {
            return "Test Data Repo!";
        }
    }
}