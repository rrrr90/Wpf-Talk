namespace Wpf_Talk.Repositories
{
    public interface IAccountRepository
    {
        //CRUD
        long Insert(Models.Account account);
        long Update(Models.Account account);
        void Delete(int id);
        Models.Account[] GetAll();
        int GetUid(Models.Account account);
        Models.Account? GetAccount(int uid);
    }
}