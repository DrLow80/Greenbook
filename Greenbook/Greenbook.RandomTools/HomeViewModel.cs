using Greenbook.Domain;

namespace Greenbook.RandomTools
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IRandomToolsRepository _randomToolsRepository;

        public HomeViewModel(IRandomToolsRepository randomToolsRepository)
        {
            _randomToolsRepository = randomToolsRepository;
        }

        public string TestMessage { get; set; }

        public void Load()
        {
            TestMessage = _randomToolsRepository.GetMessage();
        }
    }
}