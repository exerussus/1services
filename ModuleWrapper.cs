using Exerussus.Servecies.Interfaces;

namespace Exerussus.Servecies
{
    public class ModuleWrapper
    {
        public ModuleWrapper(IModuleUpdate moduleUpdate)
        {
            ModuleUpdate = moduleUpdate;
        }
        
        public float NextTimeUpdate;
        public float LastUpdateTime;
        public IModuleUpdate ModuleUpdate { get; }
    }
}