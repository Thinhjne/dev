using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS_Nhom11
{
    public partial class Form_QuanLy : Form
    {
        int labelDirection = 1;
        public Form_QuanLy()
        {
            InitializeComponent();
            timer1.Interval = 110; // Đặt khoảng thời gian cho Timer
            timer1.Tick += timer1_Tick; // Gán sự kiện Tick cho Timer
            timer1.Start(); // Bắt đầu Timer
        }

        int labelSpeed = 7;

        

        private void timer1_Tick(object sender, EventArgs e)
        {

            // Di chuyển label về bên phải
            label1.Left += labelSpeed;

            // Nếu label chạy hết bên phải (ra ngoài màn hình)
            if (label1.Left >= this.ClientSize.Width)
            {
                // Đưa label ra ngoài bên trái
                label1.Left = -label1.Width;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            string sql = "SELECT RoomID, RoomType, Status FROM Rooms";
            DataTable roomsTable = KetNoi.GetTable(sql);



        }

        private void LoadRooms()
        {
            // Xóa các Panel cũ (nếu có) trước khi thêm mới
            flowLayoutPanel1.Controls.Clear();

            // Lấy dữ liệu từ SQL
            string sql = "SELECT RoomID, Trangthai FROM Phong";
            DataTable roomsTable = KetNoi.GetTable(sql);

            // Tạo Panel động cho từng phòng
            foreach (DataRow row in roomsTable.Rows)
            {
                // Lấy thông tin phòng
                string roomID = row["RoomID"].ToString();
             
                string status = row["Trangthai"].ToString();

                // Tạo Panel
                Panel panel = new Panel
                {
                    Width = 150, // Chiều rộng của panel
                    Height = 100, // Chiều cao của panel
                    BorderStyle = BorderStyle.FixedSingle, // Viền cho panel
                    BackColor = status == "Phòng trống" ? Color.LightGreen : Color.Gray // Đổi màu theo trạng thái
                };

                // Tạo Label hiển thị thông tin phòng
                Label lblRoomID = new Label
                {
                    Text = roomID, // Ví dụ: P101
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(10, 10) // Vị trí trong Panel
                };

               

                Label lblStatus = new Label
                {
                    Text = status, // Ví dụ: Phòng trống
                    Font = new Font("Arial", 10),
                    AutoSize = true,
                    Location = new Point(10, 70)
                };
             
                
                //PictureBox pictureBox = new PictureBox
                //{
                //    Width = 50,
                //    Height = 50,
                //    Location = new Point(80, 10), // Vị trí trong Panel
                //    SizeMode = PictureBoxSizeMode.StretchImage // Co giãn hình ảnh vừa với khung
                //};



                //// Thay đổi hình ảnh dựa trên trạng thái phòng
                //if (status == "Phòng trống")
                //{
                //    pictureBox.Image = Image.FromFile("images/cancel_50px.png");
                //}
                //else if (status == "Phòng đã đặt")
                //{
                //    pictureBox.Image = Image.FromFile("images/customer Details.png");
                //}



                // Thêm Label vào Panel
                panel.Controls.Add(lblRoomID);
               
                panel.Controls.Add(lblStatus);
               // panel.Controls.Add(pictureBox);
                // Thêm Panel vào FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(panel);
            }
        }

        private void Form_QuanLy_Load(object sender, EventArgs e)
        {
            LoadRooms();
            this.Size = new Size(1100, 600);
        }

        
    }
}
