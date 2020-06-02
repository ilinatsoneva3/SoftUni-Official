namespace BorderControl
{
    public abstract class Identifiable
    {
        public Identifiable(string Id)
        {
            this.Id = Id;
        }
        public string Id { get; private set; }

        public bool CheckForFakeID(string fakeID)
        {
            if (Id.EndsWith(fakeID))
            {
                return true;
            }

            return false;
        }
    }
}
