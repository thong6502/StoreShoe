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
        public tai_khoan()
        {
            InitializeComponent();
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



        string fileName = "";
        void LoadImage(ref string filename)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
            }
        }
        private void btn_chonAnh_Click(object sender, EventArgs e)
        {
            LoadImage(ref fileName);

            if (File.Exists(fileName))
            {
                try
                {
                    // Kiểm tra xem tệp có thể được tải như một hình ảnh hay không
                    using (Image img = Image.FromFile(fileName))
                    {
                        pic_avatar.Image = new Bitmap(img);
                    }
                }
                catch (OutOfMemoryException)
                {
                    // Nếu tệp không phải là hình ảnh hợp lệ, Image.FromFile sẽ ném ra một ngoại lệ OutOfMemoryException
                    MessageBox.Show("Tệp không phải là hình ảnh hợp lệ: " + fileName);
                }
            }
            else
            {
                MessageBox.Show("Tệp tin không tồn tại: " + fileName);
            }
        }
    }
}
