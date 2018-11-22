using CSharpFunctionalExtensions;
using Greenbook.Domain;
using Greenbook.Entities;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace Greenbook.Sessions
{
    public class PrintViewModel : BaseViewModel
    {
        private readonly ISessionRepository _sessionRepository;

        public PrintViewModel(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public ICommand PrintCommand => new RelayCommand<Session>(OnPrint);

        public FlowDocument FlowDocument { get; private set; } = new FlowDocument();

        private void OnPrint(Session obj)
        {
            if (FlowDocument.Parent is FlowDocumentReader flowDocumentReader)
            {
                flowDocumentReader.Document = null;
            }

            var result = _sessionRepository.BuildPrintDocument(obj);

            FlowDocument = result.IsSuccess ? result.Value : new FlowDocument();
        }
    }
}