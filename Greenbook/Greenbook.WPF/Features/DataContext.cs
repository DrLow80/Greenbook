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

namespace Greenbook.WPF.Features
{
    public class DataContext : IContentItemsRepository, ISessionRepository, IRandomToolsRepository, IDataRepository
    {
        private IList<ContentItem> _contentItems = new List<ContentItem>();
        private IList<string> _contentTypes = new List<string>();
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

            _contentTypes = dataPayload.ContentItemTypes.ToList();

            return Result.Ok();
        }

        public IEnumerable<ContentItem> LoadContentItems()
        {
            return _contentItems;
        }

        public IEnumerable<string> LoadContentItemTypes()
        {
            return _contentTypes;
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
    }
}