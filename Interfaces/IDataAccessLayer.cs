using Capstone1.Models;

namespace Capstone1.Interfaces
{
    public interface IDataAccessLayer
    {
        IEnumerable<Event> GetEvents();
        bool AddEvent(Event eventt);
        bool RemoveEvent(int? id);
        bool UpdateEvent(Event eventt);
        Event? GetEvent(int? id);
        void ReturnEvent(int id);
    }
}