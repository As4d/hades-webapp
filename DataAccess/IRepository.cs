namespace DataAccess
{
    public interface IRepository
    {
        public int GetTotalNumberOfUsers();

        public int GetTotalNumberOfScans();
    }
}