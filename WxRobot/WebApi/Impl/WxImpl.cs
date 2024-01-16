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
}