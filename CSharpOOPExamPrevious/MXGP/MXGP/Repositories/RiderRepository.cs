namespace MXGP.Repositories
{
    using MXGP.Models.Riders.Contracts;
    using MXGP.Repositories.Contracts;
    using System.Linq;

    public class RiderRepository : Repository<IRider>, IRepository<IRider>
    {
        public override IRider GetByName(string name)
        {
            return this.models.FirstOrDefault(r => r.Name == name);
        }
    }
}
