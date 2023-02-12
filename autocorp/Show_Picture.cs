using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autocorp
{
    public partial class Show_Picture : Form
    {
        public Show_Picture()
        {
            InitializeComponent();
        }

        public void PictureSelected(string path)
        {
            Bitmap img = new Bitmap(path);
            picturebox_1.Image = img;

        }
    }
}
