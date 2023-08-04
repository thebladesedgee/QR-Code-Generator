using System;
using System.Drawing;
using System.Windows.Forms;
using QRCoder;

namespace qrCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GenerateQRCode_Click(object sender, EventArgs e)
        {

            string url = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(url))
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);

                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "PNG Files (*.png)|*.png";
                    saveDialog.FilterIndex = 1;
                    saveDialog.FileName = "QRCode.png";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        Bitmap qrCodeImage = qrCode.GetGraphic(10); 
                        qrCodeImage.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        MessageBox.Show("QR kod kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir URL girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        

       
        }
    }
}
