using PinFun.Core.Api.Attributes;

namespace WxRobot.WebApi
{
    [Api]
    public interface IWx
    {
        Guid SendMessage(string to, string message);

        MessageInfo CheckResult(Guid idMsg);

        WxStatus Status();

        int PendingQueue();
    }
}
