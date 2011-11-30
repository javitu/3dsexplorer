﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace _3DSExplorer
{
    public partial class ImageBox : Form
    {
        private ImageBox()
        {
            InitializeComponent();
        }

        private void SetImage(Image image)
        {
            pictureBox.Image = image;
            pictureBox.Size = new Size(image.Width + 2,image.Height + 2);
        }

        public static DialogResult ShowDialog(Image image)
        {
            var imBox = new ImageBox();
            imBox.SetImage(image);
            return imBox.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog()) {
                sfd.Filter = @"PNG Image (*.png)|*.png|All Files (*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                    pictureBox.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(pictureBox.Image);
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            btnZoomIn.Checked = !btnZoomIn.Checked;
            pictureBox.Width = pictureBox.Image.Width * (btnZoomIn.Checked ? 2 : 1);
            pictureBox.Height = pictureBox.Image.Height * (btnZoomIn.Checked ? 2 : 1);
        }
    }
}