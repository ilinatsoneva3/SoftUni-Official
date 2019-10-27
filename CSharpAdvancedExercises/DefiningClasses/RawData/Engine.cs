namespace RawData
{
    public class Engine
    {
        public Engine()
        {
            this.EnginePower = 0;
            this.EngineSpeed = 0;
        }
        public Engine(int engineSpeed, int enginePower)
        {
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
        }
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
    }
}
