namespace Exerussus.Servecies.Interfaces
{
    public interface IModuleUpdate
    {
        public float UpdateDelay { get; }
        public void Update(float deltaTime);
    }
}