using CSharpFunctionalExtensions;
using Greenbook.Entities;

namespace Greenbook.Services
{
    public class PayloadService : IPayloadService
    {
        public Result<DataPayload> Load()
        {
            var dataPlayload = new DataPayload();

            return Result.Ok(dataPlayload);
        }
    }
}