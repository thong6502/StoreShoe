using Guna.UI.WinForms;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shoe_store_manager
{
    public partial class tai_khoan : Form
    {
        DataTable result_NV;
        DataTable result_TK;
        public tai_khoan()
        {
            InitializeComponent();
        }

        private void tai_khoan_Load(object sender, EventArgs e)
        {
            addInfomation();
        }
        void addInfomation()
        {
            string query_NV = "SELECT * FROM NhanVien WHERE MaNV = @MaNV";
            object[] parameter_NV = new object[] { GlobalVariables.MaNV };
            result_NV = DataProvider.Instance.ExcuteQuery(query_NV, parameter_NV);

            string query_TK = "SELECT * FROM TaiKhoan WHERE MaTK = @MaTK";
            object[] parameter_TK = new object[] { GlobalVariables.MaTK };
            result_TK = DataProvider.Instance.ExcuteQuery(query_TK, parameter_TK);

            lb_TK.Text = result_TK.Rows[0]["TenTK"].ToString();
            lb_Name.Text = result_NV.Rows[0]["TenNV"].ToString();
            lb_Email.Text = result_NV.Rows[0]["Email"].ToString();
            lb_phone.Text = result_NV.Rows[0]["SDT"].ToString();
        }

        private void TogglePasswordVisibility(Guna2TextBox tbx, ref bool check_eye)
        {
            if (!check_eye)
            {
                tbx.IconRight = Properties.Resources.eye;
                tbx.UseSystemPasswordChar = false;
                tbx.PasswordChar = (char)0;
                check_eye = true;
            }
            else
            {
                tbx.IconRight = Properties.Resources.eye_slash;
                tbx.UseSystemPasswordChar = true;
                check_eye = false;
            }
        }

        bool check_eye1 = false;
        private void tbx_matKhau_IconRightClick(object sender, EventArgs e)
        {
            TogglePasswordVisibility(tbx_matKhau, ref check_eye1);
        }

        bool check_eye2 = false;
        private void tbx_matKhuaMoi_IconRightClick(object sender, EventArgs e)
        {
            TogglePasswordVisibility(tbx_matKhuaMoi, ref check_eye2);
        }

        bool check_eye3 = false;
        private void tbx_NLMatKhauMoi_IconRightClick(object sender, EventArgs e)
        {
            TogglePasswordVisibility(tbx_NLMatKhauMoi, ref check_eye3);
        }



        
    }

}
