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
    public partial class Main_window : Form
    { 

        public Main_window()
        {
            InitializeComponent();
            ConnectAsync(IPAddress.Parse(Start_window.server), Start_window.port);
            
        }
        private TcpClient _tcpClient = new TcpClient();
        Task task;

        //polaczenie
        private async void ConnectAsync(IPAddress ipadress, int port)
        {
            await _tcpClient.ConnectAsync(ipadress, port);
            MessageBox.Show("Polaczono");
            task = new Task(Receive);
            task.Start();
        }

        //Wysylanie wiadomosci
        private void button1_Click(object sender, EventArgs e)
        {
            ChatBox.Text += Environment.NewLine; ChatBox.AppendText(Start_window.username + ": " + MsgBox.Text);
            _tcpClient.Client.Send(Encoding.ASCII.GetBytes(Start_window.username + ": " + MsgBox.Text));
            MsgBox.Text = "";
        }
        private void MsgBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChatBox.Text += Environment.NewLine; ChatBox.AppendText(Start_window.username + ": " + MsgBox.Text);
                _tcpClient.Client.Send(Encoding.ASCII.GetBytes(Start_window.username + ": " + MsgBox.Text));
                MsgBox.Text = "";
            }
        }

        // Odbieranie wiadomosci
        private void Receive() 
        {
            while (true)
            {
                try
                {
                    byte[] rec = new byte[_tcpClient.ReceiveBufferSize];
                    _tcpClient.Client.Receive(rec);
                    string temp = Encoding.ASCII.GetString(rec);
                    if (temp.Contains("PNG"))
                    {

                        File.WriteAllBytes( @"C:\APP\img.png", rec);
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.ImageLocation = @"C:\APP\img.png";
                    } 
                    else
                    {
                        temp = Encoding.ASCII.GetString(rec);
                        this.Invoke((MethodInvoker)delegate { ChatBox.Text += Environment.NewLine; ChatBox.AppendText(temp); });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }

        //zamykanie aplikacji
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            _tcpClient.Close();
            Application.Exit();
        }




        //Otwieranie i wysyłanie plików
        private void button2_Click(object sender, EventArgs e) 
        {
            OpenFileDialog open_file = new OpenFileDialog();
            open_file.Filter = "PNG Files(*.png)|*.png";
            open_file.RestoreDirectory = true;
            if (open_file.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(open_file.FileName);
                if (fi.Length < 100000)
                {
                    _tcpClient.Client.SendFile(open_file.FileName);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Image = new Bitmap(open_file.FileName);

                }
                else
                {
                    MessageBox.Show("Plik jest za duzy! (do 100Kb)");
                }


            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
