namespace NTA.Core.UnitOfWorks;

public interface IUnitOfWorks
{
    void Commit();

    Task CommitAsync();
}