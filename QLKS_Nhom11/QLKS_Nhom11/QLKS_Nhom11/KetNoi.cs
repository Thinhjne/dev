using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS_Nhom11
{
    static class KetNoi
    {

        private static string DuongDan = @"Data Source=BuiThanhAnh;Initial Catalog=QLKS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        private static SqlConnection TaoKetNoi()

        { return new SqlConnection(DuongDan); }
        public static DataTable GetTable(string sql)
        {
            SqlConnection DuongOng = TaoKetNoi();
            DuongOng.Open();
            SqlDataAdapter MayHut = new SqlDataAdapter(sql, DuongOng);
            DataTable ThungChua = new DataTable();
            MayHut.Fill(ThungChua);
            DuongOng.Close();
            MayHut.Dispose();
            return ThungChua;
        }
        // THEM SUA XOA
        public static void AddEditDelete(string sql)
        {
            SqlConnection DuongOng = new SqlConnection(DuongDan);
            DuongOng.Open();
            SqlCommand cmd = new SqlCommand(sql, DuongOng);
            cmd.ExecuteNonQuery();
            DuongOng.Close();
            cmd.Dispose();


        }


    }
}
