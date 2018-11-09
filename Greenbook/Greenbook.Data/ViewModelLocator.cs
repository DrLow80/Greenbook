using Greenbook.Domain;

namespace Greenbook.Data
{
    public class ViewModelLocator
    {
        public static DataViewModel DataViewModel =>
            SpringContext.GetObject<DataViewModel>(nameof(DataViewModel));
    }
}