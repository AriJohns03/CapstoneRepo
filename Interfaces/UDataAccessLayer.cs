using Capstone1.Models;

namespace Capstone1.Interfaces
{
    public interface UDataAccessLayer
    {
        bool AddUser(UserModel u);
        void RemoveUser(UserModel u);
        void UpdateUser(UserModel u);
        void DeleteUser(int? id);
    }
}
