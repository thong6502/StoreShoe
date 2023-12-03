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
    public partial class san_pham : Form
    {
        public san_pham()
        {
            InitializeComponent();
        }

        private void san_pham_Load(object sender, EventArgs e)
        {
            
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
            arrow3.Enabled = false;
            arrow4.Enabled = false;
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
            arrow3.Enabled = true;
            arrow4.Enabled = true;
            arrow5.Enabled = true;
        }

        private void undisplay_warning()
        {
            warning1.Visible = false;
            warning2.Visible = false;
            warning3.Visible = false;
            warning4.Visible = false;
            warning5.Visible = false;
            warning6.Visible = false;
            warning7.Visible = false;
            warning8.Visible = false;
            warning9.Visible = false;
        }

        private void clear_content_tb()
        {
            tb_name.Text = "";
            tb_s38.Text = "0";
            tb_s39.Text = "0";
            tb_s40.Text = "0";
            tb_s41.Text = "0";
            tb_s42.Text = "0";
            tb_s43.Text = "0";
            tb_giaMua.Text = "0";
            tb_giaBan.Text = "0";
        }

        private void unVisible_boxFilter()
        {
            box_filter.Visible = false;
        }

        private void visible_boxFilter()
        {
            box_filter.Visible = true;
        }

        private void xac_nhan_Click(object sender, EventArgs e)
        {
            if (tb_name.Text == "") warning1.Visible = true;
            if (tb_giaMua.Text == "") warning2.Visible = true;
            if (tb_giaBan.Text == "") warning3.Visible = true;

        }

        private void add_Click(object sender, EventArgs e)
        {
            edit_box.Visible = true;
            undisplay_warning();
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

        private void btn_filter_Click(object sender, EventArgs e)
        {
            visible_boxFilter();
        }

        private void btn_XNFilter_Click(object sender, EventArgs e)
        {
            unVisible_boxFilter();
            search.PlaceholderText = cbx_filter.Text;
        }

        private void btn_HFilter_Click(object sender, EventArgs e)
        {
            unVisible_boxFilter();
        }

        private void tb_name_TextChanged(object sender, EventArgs e)
        {
            if (tb_name.Text != "") warning1.Visible = false;
            else warning1.Visible = true;
        }

        private void tb_giaMua_TextChanged(object sender, EventArgs e)
        {
            if (tb_giaMua.Text != "") warning8.Visible = false;
            else warning8.Visible = true;
        }

        private void tb_giaBan_TextChanged(object sender, EventArgs e)
        {
            if (tb_giaBan.Text != "") warning9.Visible = false;
            else warning9.Visible = true;
        }

        private void tb_s38_TextChanged(object sender, EventArgs e)
        {
            if (tb_s38.Text != "") warning2.Visible = false;
            else warning2.Visible = true;
        }

        private void tb_s39_TextChanged(object sender, EventArgs e)
        {
            if (tb_s39.Text != "") warning3.Visible = false;
            else warning3.Visible = true;
        }

        private void tb_s40_TextChanged(object sender, EventArgs e)
        {
            if (tb_s40.Text != "") warning4.Visible = false;
            else warning4.Visible = true;
        }

        private void tb_s41_TextChanged(object sender, EventArgs e)
        {
            if (tb_s41.Text != "") warning5.Visible = false;
            else warning5.Visible = true;
        }

        private void tb_s42_TextChanged(object sender, EventArgs e)
        {
            if (tb_s42.Text != "") warning6.Visible = false;
            else warning6.Visible = true;
        }

        private void tb_s43_TextChanged(object sender, EventArgs e)
        {
            if (tb_s43.Text != "") warning7.Visible = false;
            else warning7.Visible = true;
        }

        private void arrow2_Click(object sender, EventArgs e)
        {

        }
    }
}
