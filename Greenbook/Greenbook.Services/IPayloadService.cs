using CSharpFunctionalExtensions;
using Greenbook.Entities;

namespace Greenbook.Services
{
    public interface IPayloadService
    {
        Result<DataPayload> Load();
    }
}