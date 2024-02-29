using Trade.Domain.Dtos;
using Trade.Domain.Entities;


namespace Trade.Domain.RepositoryContracts
{
    public interface IUserRepository
    {
        public void CreateUser(User userdto);
        public UserDto GetUserById(string userId);
    }
}
