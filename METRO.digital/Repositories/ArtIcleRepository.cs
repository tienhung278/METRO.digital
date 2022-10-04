using System.Xml.Linq;
using METRO.digital.Contracts;
using METRO.digital.Models;

namespace METRO.digital.Repositories;

public class ArtIcleRepository : RepositoryBase<ArtIcle>, IArtIcleRepository
{
    private readonly RepositoryContext _context;

    public ArtIcleRepository(RepositoryContext context) : base(context)
    {
        _context = context;
    }

    public void CreateArtIcle(ArtIcle article)
    {
        Add(article);
        Save();
    }
    
    private void Save()
    {
        _context.SaveChanges();
    }
}