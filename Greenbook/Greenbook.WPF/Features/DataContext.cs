using CSharpFunctionalExtensions;
using Greenbook.ContentItems;
using Greenbook.Data;
using Greenbook.Entities;
using Greenbook.RandomTools;
using Greenbook.Sessions;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using Greenbook.ContentItemTypes;

namespace Greenbook.WPF.Features
{
    public class DataContext : IContentItemsRepository, ISessionRepository, IRandomToolsRepository, IDataRepository, IContentItemTypesRepository

    {
        private IList<ContentItem> _contentItems = new List<ContentItem>();
        private IList<Session> _sessions = new List<Session>();

        public string GetMessage()
        {
            return "Test Data Repo!";
        }

        public Result Insert(Session session)
        {
            _sessions.Add(session);

            return Result.Ok();
        }

        public IEnumerable<ContentItemType> LoadContentItemTypes()
        {
            return _contentItemTypes;

        }

        public Result Insert(ContentItem contentItem)
        {
            _contentItems.Add(contentItem);

            return Result.Ok();
        }

        public Result Load()
        {
            DataPayload dataPayload = new DataPayload();

            _contentItems = dataPayload.ContentItems.ToList();

            _sessions = dataPayload.Sessions.ToList();

            _contentItemTypes = dataPayload.ContentItemTypes.ToList();

            return Result.Ok();
        }

        public IEnumerable<ContentItem> LoadContentItems()
        {
            return _contentItems;
        }

        

        public IEnumerable<Session> LoadSessions()
        {
            return _sessions;
        }

        public Result Remove(Session session)
        {
            _sessions.Remove(session);

            return Result.Ok();
        }

        public Result Remove(ContentItem contentItem)
        {
            _contentItems.Remove(contentItem);

            return Result.Ok();
        }

        public Result Save()
        {
            return Result.Ok();
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

        IList<ContentItemType> _contentItemTypes=new List<ContentItemType>();

     
    }
}