namespace MXGP.Repositories
{
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Repositories.Contracts;
    using System.Linq;

    public class MotorcycleRepository: Repository<IMotorcycle>, IRepository<IMotorcycle>
    {
        
        public MotorcycleRepository()
        {
        }

        public override IMotorcycle GetByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Model == name);
        }
    }
}
