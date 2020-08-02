namespace SampleCqrs.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        bool Commit();

        void Dispose();
    }
}