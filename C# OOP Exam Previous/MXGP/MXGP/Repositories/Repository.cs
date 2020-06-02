namespace MXGP.Repositories
{
    using MXGP.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Repository<T> : IRepository<T>
    {
        protected IList<T> models;

        public Repository()
        {
            this.models = new List<T>();
        }

        public void Add(T model)
        {
            this.models.Add(model);
        }

        public System.Collections.Generic.IReadOnlyCollection<T> GetAll()
        {
            return this.models.ToList().AsReadOnly();
        }

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            return this.models.Remove(model);
        }
    }
}
