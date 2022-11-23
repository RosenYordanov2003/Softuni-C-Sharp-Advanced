namespace BookingApp.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    using BookingApp.Models.Rooms.Contracts;
    using Contracts;
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> rooms;

        public RoomRepository()
        {
            rooms = new List<IRoom>();
        }
        public void AddNew(IRoom model)
        {
          this.rooms.Add(model);
        }

        public IRoom Select(string criteria)
        {
            return this.rooms.FirstOrDefault(r => r.GetType().Name == criteria);
        }

        public IReadOnlyCollection<IRoom> All()=>this.rooms;
      
    }
}
