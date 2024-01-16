using PinFun.Core.DataBase.Attributes;
using PinFun.Core.DataBase.Entity;

namespace WxRobot;

public class MessageInfo : BaseEntity
{
    [PrimaryKey]
    public Guid IdMsg { get; set; }

        
    [Length(20)]
    public string To { get; set; }

    [Length(100)]
    public string Msg { get; set; }

    public bool IsSend { get; set; }

    [Length(200)]
    public string Result { get; set; }
}