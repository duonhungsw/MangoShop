using Book.Core.Interfaces;
using Mango.Service.AccountAPI.Models;
using Mango.Service.AccountAPI.Repository;

namespace Mango.Service.AccountAPI.Service;

public interface IRoleService
{
    Task<Role?> GetByIdAsync(Guid id);
    Task<IEnumerable<Role>> GetAllAsync();
    void Delete(Role entity);
    void Update(Role entity);
    void Create(Role entity);
    bool Exist(Guid id);
    Role? GetByNameAsync(string name);

}
public class RoleService(IUnitOfWork unitOfWork, IRoleRepository roleRepository,
                            IAccountRepository appRoleRepository) : IRoleService
{
    public void Create(Role entity)
    {

        unitOfWork.Repository<Role>().Create(entity);
    }
    public void Delete(Role entity) => unitOfWork.Repository<Role>().Delete(entity);
    public bool Exist(Guid id) => unitOfWork.Repository<Role>().Exist(id);
    public Task<IEnumerable<Role>> GetAllAsync() => unitOfWork.Repository<Role>().GetAllAsync();
    public async Task<Role?> GetByIdAsync(Guid id) => await unitOfWork.Repository<Role>().GetByIdAsync(id);

    public Role? GetByNameAsync(string name) =>  roleRepository.GetRoleByNameAsync(name);

    public void Update(Role entity) => unitOfWork.Repository<Role>().Update(entity);

}
