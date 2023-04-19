using ProjetPFE.Entities;

namespace ProjetPFE.Contracts
{
    public interface IEmployeRepository
    {
        Task<ICollection<employe>> Getemployes();
        Task<employe> GetEmployeByIdAsync(int id);
        Task<int> AddEmploye(employe employe);
        Task<int> UpdateEmployeAsync(employe employe);
        Task<int> DeleteEmployeAsync(int id);
        Task<employe?> Login(string email, string password);
    }
}
