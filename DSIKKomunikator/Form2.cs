using System;
using System.IO;
using System.Threading;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Drawing;
using System.Drawing.Imaging;

namespace DSIKKomunikator
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
            ConnectAsync(IPAddress.Parse(Form1.server), Form1.port);


        }
        private TcpClient _tcpClient = new TcpClient();
        Task task;
        private void Form2_Load(object sender, EventArgs e)
        {
        
        }
        private async void ConnectAsync(IPAddress ipadress, int port)
        {
            await _tcpClient.ConnectAsync(ipadress, port);
            MessageBox.Show("Polaczono");
            task = new Task(Receive);
            task.Start();
        }
        private void ChatBox_TextChanged(object sender, EventArgs e)
        {

        }
        /*    public void ConvertByteArrayToBitmap(byte[] receivedBytes)
            {
               // MemoryStream ms = new MemoryStream(receivedBytes);
               // return new Bitmap(ms, System.Drawing.Imaging.ImageFormat.Png); // I recomend you to use png format   
                Bitmap bitmap = BitmapFactory.decodeFile("/path/images/image.jpg");
                ByteArrayOutputStream blob = new ByteArrayOutputStream();
                bitmap.compress(CompressFormat.PNG, 0  Ignored for PNGs , blob);
                byte[] bitmapdata = blob.toByteArray();

            }
        */


        private void button1_Click(object sender, EventArgs e)
        {
            _tcpClient.Client.Send(Encoding.ASCII.GetBytes(Form1.username + ": " + MsgBox.Text));
            MsgBox.Text = "";
        }
        private void Receive()
        {
            byte[] rec = new byte[_tcpClient.ReceiveBufferSize];
            _tcpClient.Client.Receive(rec);
            string temp = Encoding.ASCII.GetString(rec);
            this.Invoke((MethodInvoker)delegate { ChatBox.Text += Environment.NewLine;ChatBox.AppendText(temp) ; });
           

              //  var ms = new MemoryStream(rec);
              //  System.Drawing.Image image = Image.FromStream(ms);


            // Loop through the images pixels to reset color.

            /* 
             int x, y; 
             for (x = 0; x < image.Width; x++)
             {
                 for (y = 0; y < image.Height; y++)
                 {
                     Color pixelColor = image.GetPixel(x, y);
                     Color newColor = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                     image.SetPixel(x, y, newColor);
                 }
             }
             pictureBox1.Image = image;
             */
            // MemoryStream ms = new MemoryStream(new Byte[] { 0x00, 0x01, 0x02 });
            // System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms, false, true);


                // image.Save(@"c:\image.jpg");

            
            Thread.Sleep(100);
            Receive();
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }



        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            _tcpClient.Close();
        }

        private void MsgBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                _tcpClient.Client.Send(Encoding.ASCII.GetBytes(Form1.username + ": " + MsgBox.Text));
                MsgBox.Text = "";
            }
        }
        string fileName;
        private void button2_Click(object sender, EventArgs e)
        {
            fileName = null;

            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog1.FileName;
                    Bitmap image1;
                    try
                    {
                        // Retrieve the image.
                        //  image1 = new Bitmap(@"C:\Documents and Settings\All Users\" + @"Documents\My Music\music.bmp", true);
                        image1 = new Bitmap(fileName, true);

                        int x, y;

                        // Loop through the images pixels to reset color.
                        for (x = 0; x < image1.Width; x++)
                        {
                            for (y = 0; y < image1.Height; y++)
                            {
                                Color pixelColor = image1.GetPixel(x, y);
                                Color newColor = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                                image1.SetPixel(x, y, newColor);
                            }
                        }
                        pictureBox1.Image = image1;
                        // Set the PictureBox to display the image.
                        // pictureBox1.Image = image1;

                        // Display the pixel format in Label1.
                        // label1.Text = "Pixel format: " + image1.PixelFormat.ToString();
                        /*
                            NetworkStream nNetStream = _tcpClient.GetStream();
                            Image returnImage = Image.FromStream(nNetStream);
                            pictureBox1.Image = returnImage;
                        */
                        //ToByteArray();
                        //ImageExt.ToByteArray(image1, ImageFormat.Bmp);



                        string test1 = System.Text.Encoding.ASCII.GetString(ImageExt.ToByteArray(image1, ImageFormat.Bmp));
                        _tcpClient.Client.Send(Encoding.ASCII.GetBytes(test1));
                       
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show("There was an error." +
                            "Check the path to the image file.");
                    }
                }
            

            }

            if (fileName != null)
            {
                //Do something with the file, for example read text from it
                string text = File.ReadAllText(fileName);
            }

            
            /*  // Displays an OpenFileDialog so the user can select a Cursor.  
              OpenFileDialog openFileDialog1 = new OpenFileDialog();
              openFileDialog1.Filter = "Cursor Files|*.cur";
              openFileDialog1.Title = "Select a Cursor File";

              // Show the Dialog.  
              // If the user clicked OK in the dialog and  
              // a .CUR file was selected, open it.  
              if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
              {
                  // Assign the cursor in the Stream to the Form's Cursor property.  
                  this.Cursor = new Cursor(openFileDialog1.OpenFile());
              }

              */
        }



        private void MsgBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap image1;
            try
            {
                // Retrieve the image.
                //  image1 = new Bitmap(@"C:\Documents and Settings\All Users\" + @"Documents\My Music\music.bmp", true);
                image1 = new Bitmap(fileName, true);

                int x, y;

                // Loop through the images pixels to reset color.
                for (x = 0; x < image1.Width; x++)
                {
                    for (y = 0; y < image1.Height; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                        image1.SetPixel(x, y, newColor);
                    }
                }
                pictureBox1.Image = image1;
                // Set the PictureBox to display the image.


                // Display the pixel format in Label1.
                // label1.Text = "Pixel format: " + image1.PixelFormat.ToString();

            }
            catch (ArgumentException)
            {
                MessageBox.Show("There was an error." +
                    "Check the path to the image file.");
            }
        }


    }
}
