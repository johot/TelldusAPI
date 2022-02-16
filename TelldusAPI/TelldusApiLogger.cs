using SlackWebHookWrapper;

namespace TelldusAPI
{
    public interface ITelldusApiLogger
    {
        void Log(string message);
    }

    public class TelldusApiLogger : ITelldusApiLogger
    {
        private readonly ISlackHook hook;
        public TelldusApiLogger(ISlackHook hook)
        {
            this.hook = hook;
        }

        public void Log(string message)
        {
            hook.Header = "Telldus API";
            hook.Subtext = message;
            hook.Send();
        }
    }
}