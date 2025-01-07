namespace Wpf_DB.Repositories
{
    public interface IAccountRepository
    {
        //CRUD
        long Insert(Model.Account account);
        long Update(Model.Account account);
        void Delete(int id);
        Model.Account[] GetAll();
    }
}