
// ReSharper disable LocalizableElement

namespace WxRobot
{
    public partial class PushLog : Form
    {
        public PushLog()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var friend = tbFriend.Text;
            var begin = dtpBegin.Value;
            var end = dtpEnd.Value;

            try
            {
                btnSearch.Enabled = false;
                tsslStatus.Text = "查询中";
                var sql = "select * from MessageInfo where CreateAt>=@begin and CreateAt<=@end";
                if (!string.IsNullOrWhiteSpace(friend))
                {
                    sql += " and [To]=@friend";
                }

                sql += " order by CreateAt desc";

                using var db = MainWin.Instance.CreateDb();
                var data = await db.QueryAsync<MessageInfo>(sql, new { friend, begin, end });
                dgvData.DataSource = data;
                tsslStatus.Text = $"合计{data.Count()}条数据";
            }
            catch (Exception ex)
            {
                tsslStatus.Text = $"查询出错：{ex.Message}";
            }
            finally
            {
                btnSearch.Enabled = true;
            }
        }
    }
}
