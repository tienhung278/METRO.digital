using METRO.digital.Dtos;

namespace METRO.digital.Contracts;

public interface IArtIcleServices
{
    long CreateArtIcle(long basketId, ArticleWriteDto articleWriteDto);
}