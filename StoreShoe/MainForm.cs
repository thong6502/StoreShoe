using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shoe_store_manager
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            container(new all_don_hang());
        }

        private void container(object _form)
        {
            if (gunaPanel_container.Controls.Count > 0) gunaPanel_container.Controls.Clear();

            Form fm = _form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            gunaPanel_container.Controls.Add(fm);
            gunaPanel_container.Tag = fm;
            fm.Show();
        }

        private void default_color()
        {
            btn_donhang.FillColor = Color.Transparent;
            btn_sanpham.FillColor = Color.Transparent;
            btn_nhanvien.FillColor = Color.Transparent;
            btn_nhacc.FillColor = Color.Transparent;
            btn_baocao.FillColor = Color.Transparent;
            btn_taikhoan.FillColor = Color.Transparent;

            btn_allDonHang.ForeColor = Color.DarkGray;
            btn_nhapHang.ForeColor = Color.DarkGray;
            btn_banHang.ForeColor = Color.DarkGray;

        }



        private void btn_donhang_Click(object sender, EventArgs e)
        {
            if (menuContainer.Height >= 140)
            {
                menuTransition.Start();
            }
            else
            {
                label_val.Text = "Đơn hàng / Tất cả đơn hàng";
                img_top.Image = Properties.Resources.order;
                default_color();
                btn_donhang.FillColor = Color.FromArgb(128, 128, 255);
                btn_allDonHang.ForeColor = Color.White;
                menuTransition.Start();
                container(new all_don_hang());
            }
            
        }

        private void btn_nhacc_Click(object sender, EventArgs e)
        {
            label_val.Text = "Nhà cung cấp";
            img_top.Image = Properties.Resources.truck;
            default_color();
            btn_nhacc.FillColor = Color.FromArgb(128, 128, 255);
            container(new nha_cung_cap());
        }

        private void btn_sanpham_Click(object sender, EventArgs e)
        {
            label_val.Text = "Sản phẩm";
            img_top.Image = Properties.Resources.product;
            default_color();
            btn_sanpham.FillColor = Color.FromArgb(128, 128, 255);
            container(new san_pham());
        }

        private void btn_nhanvien_Click(object sender, EventArgs e)
        {
            label_val.Text = "Nhân viên";
            img_top.Image = Properties.Resources.employ;
            default_color();
            btn_nhanvien.FillColor = Color.FromArgb(128, 128, 255);
            container(new nhan_vien());
        }

        private void btn_baocao_Click(object sender, EventArgs e)
        {
            label_val.Text = "Báo cáo";
            img_top.Image = Properties.Resources.report;
            default_color();
            btn_baocao.FillColor = Color.FromArgb(128, 128, 255);
        }

        private void btn_taikhoan_Click(object sender, EventArgs e)
        {
            label_val.Text = "Tài khoản";
            img_top.Image = Properties.Resources.setting;
            default_color();
            btn_taikhoan.FillColor = Color.FromArgb(128, 128, 255);
            container(new tai_khoan());
        }

        bool menuExpand = true;
        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if(menuExpand)
            {
                menuContainer.Height += 10;
                if(menuContainer.Height >= 140)
                {
                    menuTransition.Stop();
                    menuExpand = false;
                }
            }
            else
            {
                menuContainer.Height -= 10;
                if (menuContainer.Height <= 35)
                {
                    menuTransition.Stop();
                    menuExpand = true;
                }
            }
        }

        private void btn_allDonHang_Click(object sender, EventArgs e)
        {
            label_val.Text = "Đơn hàng / Tất cả đơn hàng";
            img_top.Image = Properties.Resources.order;
            default_color();
            btn_donhang.FillColor = Color.FromArgb(128, 128, 255);
            btn_allDonHang.ForeColor = Color.White;
            container(new all_don_hang());
        }

        private void btn_nhapHang_Click(object sender, EventArgs e)
        {
            label_val.Text = "Đơn hàng / Nhập hàng";
            img_top.Image = Properties.Resources.order;
            default_color();
            btn_donhang.FillColor = Color.FromArgb(128, 128, 255);
            btn_nhapHang.ForeColor = Color.White;
            container(new nhap_hang());
        }

        private void btn_banHang_Click(object sender, EventArgs e)
        {
            label_val.Text = "Đơn hàng / Bán hàng";
            img_top.Image = Properties.Resources.order;
            default_color();
            btn_donhang.FillColor = Color.FromArgb(128, 128, 255);
            btn_banHang.ForeColor = Color.White;
            container(new ban_hang());
        }
        private void btn_closeMain_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
