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

namespace Hazi_ImageBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int imageSize = 100;
      
        private void onClickEvent(object sender, EventArgs e)
        {
            var pic = (PictureBox)sender;
            var images = Directory.GetFiles("imgs");
            images = images.Where(i => i != pic.ImageLocation).ToArray();
            var rand = new Random();
            var randomImage = images[rand.Next(0, images.Length)];
            pic.ImageLocation = randomImage;
            pic.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void button_generate_Click(object sender, EventArgs e)
        {
            int numberOfPics = (int)numericUpDown.Value;
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < numberOfPics; i++)
            {
                var pictureBox = new PictureBox();
                flowLayoutPanel1.Controls.Add(pictureBox);
                pictureBox.Size = new Size(imageSize, imageSize);
                pictureBox.BorderStyle = BorderStyle.FixedSingle;
                pictureBox.Click += onClickEvent;
            }
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
