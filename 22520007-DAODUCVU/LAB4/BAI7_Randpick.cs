using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB4
{
    public partial class BAI7_Randpick : Form
    {
        public BAI7_Randpick(BAI7_Pick pick)
        {
            InitializeComponent();
            flowLayoutPanel1.Controls.Add(pick);
            this.Text = $"Ăn {pick.DishName} Đê !!!";
        }
    }
}
