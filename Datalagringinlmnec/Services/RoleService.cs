using Datalagringinlmnec.Entities;
using Datalagringinlmnec.Repositories;

namespace Datalagringinlmnec.Services
{
    internal class RoleService
    {
        private readonly RoleRepository _roleRepository;

        public RoleService(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public RoleEntity CreateRole(string roleName)
        {
            try
            {
                var roleEntity = _roleRepository.Get(x => x.RoleName == roleName);
                if (roleEntity == null)
                {
                    roleEntity = _roleRepository.Create(new RoleEntity { RoleName = roleName });
                }
                return roleEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;
            }
        }

        public RoleEntity GetRoleByCategoryName(string roleName)
        {
            try
            {
                var roleEntity = _roleRepository.Get(x => x.RoleName == roleName);
                return roleEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;
            }
        }

        public RoleEntity GetRoleById(int Id)
        {
            try
            {
                var roleEntity = _roleRepository.Get(x => x.Id == Id);
                return roleEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;
            }
        }

        public IEnumerable<RoleEntity> GetAllCategories()
        {
            try
            {
                var roles = _roleRepository.GetAll();
                return roles;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;
            }
        }

        public RoleEntity UpdateRole(RoleEntity roleEntity)
        {
            var updatedEntity = _roleRepository.Update(x => x.Id == roleEntity.Id, roleEntity);
            return updatedEntity;
        }

        public bool DeletRole(int id)
        {
            try
            {
                _roleRepository.Delete(x => x.Id == id);
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
        }
    }
}
