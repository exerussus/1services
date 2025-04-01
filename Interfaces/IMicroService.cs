using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exerussus.Servecies.Interfaces
{
    public interface IMicroService
    {
        public Task<MicroServiceProcessState> RunProcess(MicroServiceProcessContext context);
    }

    public class MicroServiceProcessContext
    {
        public MicroServiceProcessState CurrentState { get; private set; }
        public Dictionary<string, object> Data { get; private set; } = new();

        public static void ChangeProcessState(MicroServiceProcessContext context, MicroServiceProcessState state)
        {
            context.CurrentState = state;
        }
    }

    public enum MicroServiceProcessState
    {
        Waiting,
        Processing,
        Finished,
        NotFoundService,
        FailedInProcess,
        Stopped,
        Timeout,
    }
}