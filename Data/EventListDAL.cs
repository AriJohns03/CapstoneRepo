using Capstone1.Interfaces;
using Capstone1.Models;

namespace Capstone1.Data
{
    public class EventListDAL : IDataAccessLayer
    {

        private AppDBContext db;

        public EventListDAL(AppDBContext indb)
        {
            db = indb;
        }

        public bool AddEvent(Event eventt)
        {
            try
            {
                db.Add(eventt);
                db.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Event? GetEvent(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetEvents()
        {
            throw new NotImplementedException();
        }

        public bool RemoveEvent(int? id)
        {
            throw new NotImplementedException();
        }

        public void ReturnEvent(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEvent(Event eventt)
        {
            throw new NotImplementedException();
        }
    }
}
