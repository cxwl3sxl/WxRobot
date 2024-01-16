namespace WxRobot
{
    internal class DelayConfig
    {
        /// <summary>
        /// 将微信窗口前置后延时
        /// </summary>
        public int AfterBringWxToForeground { get; set; } = 1000;

        /// <summary>
        /// 微信窗体获取到焦点后
        /// </summary>
        public int AfterWxFocused { get; set; } = 100;

        /// <summary>
        /// 键盘操作间隔,ctrl+v等键盘操作
        /// </summary>
        public int KeyboardAction { get; set; } = 100;

        /// <summary>
        /// 回车发送消息前
        /// </summary>
        public int BeforeSendMessage { get; set; } = 500;

        /// <summary>
        /// 两条消息之间的延时
        /// </summary>
        public int Message { get; set; } = 1000;

        /// <summary>
        /// 搜索朋友后延时
        /// </summary>
        public int AfterSearchFriend { get; set; } = 500;

        /// <summary>
        /// 输入完毕好友名称，延时后回车发起搜索
        /// </summary>
        public int BeforeSearchFriend { get; set; } = 500;
    }
}
