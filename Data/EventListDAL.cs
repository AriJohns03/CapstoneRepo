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
            catch (Exception ex)
            {
                return false;
            }
        }

        public Event? GetEvent(int? id)
        {
            Event? e = db.Events.Where(x => x.Id == id).FirstOrDefault();
            return e;
        }

        public IEnumerable<Event> GetEvents()
        {
            return db.Events;
        }

        public bool RemoveEvent(int? id)
        {
            Event? e = GetEvent(id);
            try
            {
                db.Events.Remove(e);
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void ReturnEvent(int id)
        { 
            Event? g = GetEvent(id);
        }

        public bool UpdateEvent(Event eventt)
        {
            try
            {
                db.Events.Update(eventt);
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Event> SearchEvents(string key)
        {
            return (GetEvents().Where(x => x.Name.ToUpper().Contains(key.ToUpper())));
        }
    }
}
