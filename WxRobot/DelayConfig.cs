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
        /// 键盘操作间隔
        /// </summary>
        public int KeyboardAction { get; set; } = 100;

        /// <summary>
        /// 按回车键前
        /// </summary>
        public int BeforeEnter { get; set; } = 500;

        /// <summary>
        /// 两条消息之间的延时
        /// </summary>
        public int Message { get; set; } = 1000;
    }
}
