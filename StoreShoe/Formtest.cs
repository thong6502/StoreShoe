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
    public partial class Formtest : Form
    {
        public Formtest()
        {
            InitializeComponent();
        }

        private void Formtest_Load(object sender, EventArgs e)
        {
            foreach (Control c in this.guna2ShadowPanel1.Controls)
            {
                if (c is Button)
                {
                    ((Button)c).ForeColor = Color.Red;
                }
            }

        }
    }
}
