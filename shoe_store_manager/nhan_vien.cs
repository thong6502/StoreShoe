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
    public partial class nhan_vien : Form
    {
        public nhan_vien()
        {
            InitializeComponent();
        }

        private void nhan_vien_Load(object sender, EventArgs e)
        {


            data.Rows.Add(13);
            data.Rows[0].Cells[1].Value = "NV1";
            data.Rows[0].Cells[2].Value = "Lê Văn Thông";
            data.Rows[0].Cells[3].Value = "Vĩnh hưng - hoàng mai - hà nội";
            data.Rows[0].Cells[4].Value = "O123456789";
            data.Rows[0].Cells[5].Value = "12.000.000";
            data.Rows[0].Cells[6].Value = "Anh thợ sửa ống nước may mắn";

            data.Rows[1].Cells[1].Value = "NV2";
            data.Rows[1].Cells[2].Value = "Nguyễn Văn B";
            data.Rows[1].Cells[3].Value = "Quận 1 - TP.Hồ Chí Minh";
            data.Rows[1].Cells[4].Value = "O987654321";
            data.Rows[1].Cells[5].Value = "8.500.000";
            data.Rows[1].Cells[6].Value = "Nhân viên kinh doanh";

            data.Rows[2].Cells[1].Value = "NV3";
            data.Rows[2].Cells[2].Value = "Trần Thị C";
            data.Rows[2].Cells[3].Value = "Cầu Giấy - Hà Nội";
            data.Rows[2].Cells[4].Value = "O567890123";
            data.Rows[2].Cells[5].Value = "4.500.000";
            data.Rows[2].Cells[6].Value = "Nhân viên hỗ trợ";

            data.Rows[3].Cells[1].Value = "NV4";
            data.Rows[3].Cells[2].Value = "Phạm Văn D";
            data.Rows[3].Cells[3].Value = "Quận 2 - TP.Hồ Chí Minh";
            data.Rows[3].Cells[4].Value = "O456789012";
            data.Rows[3].Cells[5].Value = "9.500.000";
            data.Rows[3].Cells[6].Value = "Nhân viên kỹ thuật";

            data.Rows[4].Cells[1].Value = "NV5";
            data.Rows[4].Cells[2].Value = "Lê Thị E";
            data.Rows[4].Cells[3].Value = "Đống Đa - Hà Nội";
            data.Rows[4].Cells[4].Value = "O345678901";
            data.Rows[4].Cells[5].Value = "9.100.000";
            data.Rows[4].Cells[6].Value = "Nhân viên tư vấn";

            data.Rows[5].Cells[1].Value = "NV6";
            data.Rows[5].Cells[2].Value = "Ngô Văn F";
            data.Rows[5].Cells[3].Value = "Quận 3 - TP.Hồ Chí Minh";
            data.Rows[5].Cells[4].Value = "O234567890";
            data.Rows[5].Cells[5].Value = "2.100.000";
            data.Rows[5].Cells[6].Value = "Nhân viên bán hàng";

            data.Rows[6].Cells[1].Value = "NV7";
            data.Rows[6].Cells[2].Value = "Đặng Thị G";
            data.Rows[6].Cells[3].Value = "Hai Bà Trưng - Hà Nội";
            data.Rows[6].Cells[4].Value = "O123456789";
            data.Rows[6].Cells[5].Value = "8.100.000";
            data.Rows[6].Cells[6].Value = "Nhân viên chăm sóc khách hàng";

            data.Rows[7].Cells[1].Value = "NV8";
            data.Rows[7].Cells[2].Value = "Trần Văn H";
            data.Rows[7].Cells[3].Value = "Quận 4 - TP.Hồ Chí Minh";
            data.Rows[7].Cells[4].Value = "O012345678";
            data.Rows[7].Cells[5].Value = "8.210.000";
            data.Rows[7].Cells[6].Value = "Nhân viên giao hàng";

            data.Rows[8].Cells[1].Value = "NV9";
            data.Rows[8].Cells[2].Value = "Nguyễn Thị I";
            data.Rows[8].Cells[3].Value = "Thanh Xuân - Hà Nội";
            data.Rows[8].Cells[4].Value = "O901234567";
            data.Rows[8].Cells[5].Value = "3.210.000";
            data.Rows[8].Cells[6].Value = "Nhân viên quản lý";

            data.Rows[9].Cells[1].Value = "NV10";
            data.Rows[9].Cells[2].Value = "Lê Văn J";
            data.Rows[9].Cells[3].Value = "Quận 5 - TP.Hồ Chí Minh";
            data.Rows[9].Cells[4].Value = "O890123456";
            data.Rows[9].Cells[5].Value = "4.210.000";
            data.Rows[9].Cells[6].Value = "Nhân viên phục vụ";

            data.Rows[10].Cells[1].Value = "NV11";
            data.Rows[10].Cells[2].Value = "Phạm Thị K";
            data.Rows[10].Cells[3].Value = "Hoàn Kiếm - Hà Nội";
            data.Rows[10].Cells[4].Value = "O789012345";
            data.Rows[10].Cells[5].Value = "6.210.000";
            data.Rows[10].Cells[6].Value = "Nhân viên tiếp thị";

            data.Rows[11].Cells[1].Value = "NV12";
            data.Rows[11].Cells[2].Value = "Ngô Văn L";
            data.Rows[11].Cells[3].Value = "Quận 6 - TP.Hồ Chí Minh";
            data.Rows[11].Cells[4].Value = "O678901234";
            data.Rows[11].Cells[5].Value = "6.610.000";
            data.Rows[11].Cells[6].Value = "Nhân viên lập trình";

            data.Rows[12].Cells[1].Value = "NV13";
            data.Rows[12].Cells[2].Value = "Đặng Văn M";
            data.Rows[12].Cells[3].Value = "Tây Hồ - Hà Nội";
            data.Rows[12].Cells[4].Value = "O567890123";
            data.Rows[12].Cells[5].Value = "21.610.000";
            data.Rows[12].Cells[6].Value = "Nhân viên thiết kế";




        }

        private void disabeled()
        {
            data.Enabled = false;
            delete.Enabled = false;
            add.Enabled = false;
            edit.Enabled = false;
            search.Enabled = false;
            btn_filter.Enabled = false;
            arrow2.Enabled = false;
            arrow5.Enabled = false;
        }

        private void enabeled()
        {
            data.Enabled = true;
            delete.Enabled = true;
            add.Enabled = true;
            edit.Enabled = true;
            search.Enabled = true;
            btn_filter.Enabled = true;
            arrow2.Enabled = true;
            arrow5.Enabled = true;
        }

        private void undisplay_warning()
        {
            warning1.Visible = false;
            warning2.Visible = false;
            warning3.Visible = false;
            warning4.Visible = false;
        }

        private void clear_content_tb()
        {
            tb_name.Text = "";
            tb_address.Text = "";
            tb_phone.Text = "";
            tb_chucVu.Text = "";
        }

        private void unVisible_boxFilter()
        {
            box_filter.Visible = false;
        }

        private void visible_boxFilter()
        {
            box_filter.Visible = true;
        }


        private void add_Click(object sender, EventArgs e)
        {
            edit_box.Visible = true;
            unVisible_boxFilter();
            disabeled();
        }
        private void huy_Click(object sender, EventArgs e)
        {
            edit_box.Visible = false;
            clear_content_tb();
            undisplay_warning();
            enabeled();
        }

        private void xac_nhan_Click(object sender, EventArgs e)
        {
            if (tb_name.Text == "") warning1.Visible = true;
            if (tb_address.Text == "") warning2.Visible = true;
            if (tb_phone.Text == "") warning3.Visible = true;
            if (tb_chucVu.Text == "") warning4.Visible = true;
        }

        private void tb_phone_TextChanged(object sender, EventArgs e)
        {
            if (tb_phone.Text != "") warning3.Visible = false;
            else warning3.Visible = true;
        }

        private void tb_name_TextChanged(object sender, EventArgs e)
        {
            if (tb_name.Text != "") warning1.Visible = false;
            else warning1.Visible = true;
        }

        private void tb_address_TextChanged(object sender, EventArgs e)
        {
            if (tb_address.Text != "") warning2.Visible = false;
            else warning2.Visible = true;
        }

        private void tb_chucVu_TextChanged(object sender, EventArgs e)
        {
            if (tb_chucVu.Text != "") warning4.Visible = false;
            else warning4.Visible = true;
        }

        private void btn_filter_Click(object sender, EventArgs e)
        {
            visible_boxFilter();
        }

        private void btn_HFilter_Click(object sender, EventArgs e)
        {
            unVisible_boxFilter();
        }

        private void btn_XNFilter_Click(object sender, EventArgs e)
        {
            unVisible_boxFilter();
            search.PlaceholderText = cbx_filter.Text;
        }
    }
}
