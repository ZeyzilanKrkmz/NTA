using NTA.Core.UnitOfWorks;

namespace NTA.Core.Repositories.UnitOfWorks;

public class UnitOfWorks(AppDbContext context):IUnitOfWorks
{
    private readonly AppDbContext _context = context;


    public void Commit()
    {
        _context.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}