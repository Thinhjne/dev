using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS_Nhom11
{
    public partial class DatPhongForm : Form
    {
        public DatPhongForm()
        {
            InitializeComponent();
        }

        private void buttonBookandPrint_Click(object sender, EventArgs e)
        {
            string sql = $"Insert into ThongTinKH values ('{textBoxIDRoom.Text}','{textBoxTenKh.Text}','{textBox2SDT.Text}','{textBox3CCCD.Text}','{textBox4SONGUOI.Text}','{dateTimePicker1_NgayDat.Value:yyyy-MM-dd}','{dateTimePicker2_NgayTra.Value:yyyy-MM-dd}')";
            KetNoi.AddEditDelete(sql);
          //  dataGridView1.DataSource = KetNoi.GetTable("select*from ThongTinKH ");
            MessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Bạn có chắc chắn muốn thoát không?",
        "Xác nhận thoát",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void DatPhongForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình không?", "Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            //{ e.Cancel = true; }
        }
    }
}
