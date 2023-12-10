using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI.WinForms;
using Guna.UI2.WinForms;

namespace shoe_store_manager
{
    public partial class nhap_hang : Form
    {

        public nhap_hang()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            container_edit_box.Visible = true;
        }

        // Biến cờ để kiểm soát việc kích hoạt sự kiện
        private bool isUpdating1 = false;

        private void tb_giaMua_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem sự kiện có được kích hoạt bởi mã của chúng ta không
            if (isUpdating1) return;

            // Bắt đầu cập nhật
            isUpdating1 = true;

            // Xóa ký tự không phải số và chữ "đ"
            string digitsOnly = new String(tb_giaMua.Text.Where(c => Char.IsDigit(c)).ToArray());

            // Kiểm tra xem người dùng có nhập số không
            if (Decimal.TryParse(digitsOnly, out decimal value))
            {
                // Định dạng giá trị thành chuỗi với dấu phẩy phân cách và ký hiệu đồng
                string formattedValue = String.Format("{0:N0} đ", value);

                // Cập nhật giá trị hiển thị trên guna2TextBox1
                tb_giaMua.Text = formattedValue;

                // Di chuyển con trỏ về cuối TextBox, trừ đi số ký tự của chuỗi " đ"
                tb_giaMua.SelectionStart = tb_giaMua.Text.Length - " đ".Length;
            }
            else
            {
                // Nếu không phải số, chỉ hiển thị chữ "đ"
                tb_giaMua.Text = "0 đ";

                // Di chuyển con trỏ về cuối TextBox
                tb_giaMua.SelectionStart = tb_giaMua.Text.Length - " đ".Length;
            }

            // Kết thúc cập nhật
            isUpdating1 = false;
        }




        private bool isUpdating2 = false;

        private void tb_giaBan_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem sự kiện có được kích hoạt bởi mã của chúng ta không
            if (isUpdating2) return;

            // Bắt đầu cập nhật
            isUpdating2 = true;

            // Xóa ký tự không phải số và chữ "đ"
            string digitsOnly = new String(tb_giaBan.Text.Where(c => Char.IsDigit(c)).ToArray());

            // Kiểm tra xem người dùng có nhập số không
            if (Decimal.TryParse(digitsOnly, out decimal value))
            {
                // Định dạng giá trị thành chuỗi với dấu phẩy phân cách và ký hiệu đồng
                string formattedValue = String.Format("{0:N0} đ", value);

                // Cập nhật giá trị hiển thị trên guna2TextBox1
                tb_giaBan.Text = formattedValue;

                // Di chuyển con trỏ về cuối TextBox, trừ đi số ký tự của chuỗi " đ"
                tb_giaBan.SelectionStart = tb_giaBan.Text.Length - " đ".Length;
            }
            else
            {
                // Nếu không phải số, chỉ hiển thị chữ "đ"
                tb_giaBan.Text = "0 đ";

                // Di chuyển con trỏ về cuối TextBox
                tb_giaBan.SelectionStart = tb_giaBan.Text.Length - " đ".Length;
            }

            // Kết thúc cập nhật
            isUpdating2 = false;
        }


    }
}
