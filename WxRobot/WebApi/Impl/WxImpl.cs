using PinFun.Core.Api;

namespace WxRobot.WebApi.Impl;

class WxImpl : IWx
{
    public Guid SendMessage(string to, string message)
    {
        return MainWin.Instance?.SendMessage(to, message) ?? Guid.Empty;
    }

    public MessageInfo CheckResult(Guid idMsg)
    {
        return MainWin.Instance?.CheckResult(idMsg);
    }

    public Task<WxStatus> Status()
    {
        return MainWin.Instance?.Status();
    }

    public int PendingQueue()
    {
        return MainWin.Instance?.PendingQueue() ?? 0;
    }

    public Task<FileResult> Login()
    {
        return MainWin.Instance?.Login();
    }
}