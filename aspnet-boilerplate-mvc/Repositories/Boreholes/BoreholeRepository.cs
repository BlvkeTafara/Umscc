using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.Boreholes
{
    public class BoreholeRepository : GenericRepository<Borehole>, IBoreholeRepository
    {

        public BoreholeRepository(AppDbContext context) : base(context)
        {
        }
        public bool Exists(int id)
        {
            return _context.boreholes.Any(q => q.Id == id);
        }
        public void Remove(int id)
        {
            var borehole = _context.boreholes.Find(id);
            if (borehole != null)
            {
                _context.boreholes.Remove(borehole);
            }
        }
    }
}
