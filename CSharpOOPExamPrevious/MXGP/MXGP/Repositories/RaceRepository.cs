namespace MXGP.Repositories
{
    using MXGP.Models.Races.Contracts;
    using MXGP.Repositories.Contracts;
    using System.Linq;

    public class RaceRepository : Repository<IRace>, IRepository<IRace>
    {
        public override IRace GetByName(string name)
        {
            return this.models.FirstOrDefault(r => r.Name == name);
        }
    }
}
