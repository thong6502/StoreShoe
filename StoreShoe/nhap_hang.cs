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


        private void tb_giaMua_TextChanged(object sender, EventArgs e)
        {
            main.UpdateTextBox(tb_giaMua, tb_giaMua.Text);
        }


        private void tb_giaBan_TextChanged(object sender, EventArgs e)
        {
            main.UpdateTextBox(tb_giaBan, tb_giaBan.Text);
        }


    }
}
