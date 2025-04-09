using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using static System.Net.WebRequestMethods;

namespace TaskTopic8ForSDO
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Form mainForm = new InteractiveForm("Example", Color.AliceBlue);
            Application.Run(mainForm);
        }
        public class InteractiveForm : Form
        {
            private bool _mouseOnForm = false;
            private PictureBox pictureBox;
            public InteractiveForm(string title, Color backColor)
            {
                Text = title;
                Height = 600;
                Width = 800;
                BackColor = backColor;
                StartPosition = FormStartPosition.CenterScreen;
                Button exitButton = CreateButton(new Size(60, 30), new Point(700, 500), Color.Firebrick,"Выход");
                exitButton.Click += (sender, e) => Application.Exit();
                Label label3 = CreateLabel(new Size(200, 200), new Point(500, 500),Color.Transparent, "");
                Label label2= CreateLabel(new Size(100, 50), new Point(350, 100), Color.Aquamarine, "КЛИКНИ ДВА РАЗА ПО ПОЛЮ ПРИЛОЖЕНИЯ");
                Label label = CreateLabel(new Size(100, 40), new Point(10, 10), Color.Cyan, "Пасхалка - НАЖМИ");
                label.Visible = false;
                label3.Visible = false;
                DoubleClick += (sender, e) => ShowLabel(label); 
                DoubleClick += (sender, e) => ShowLabel(label3);
                MouseEnter += (sender, e) => _mouseOnForm = true;
                MouseLeave += (sender, e) => _mouseOnForm = false;
                Button rickButton = CreateButton(new Size(60, 30), new Point(100, 500), Color.ForestGreen, "НАЖМИ МЕНЯ");
                rickButton.Click += LinkButton_Click;
                Button rickMegaButton = CreateButton(new Size(100, 60), new Point(350, 400), Color.LightGoldenrodYellow, "НЕ НАЖИМАЙ МЕНЯ");
                rickMegaButton.Click += LinkMegaButton_Click;
                label.Click += LoadImageLabel_Click;
            }

            private void ShowLabel(Label label)
            {
                if (_mouseOnForm) label.Visible = true;
                //if (_mouseOnForm) label3.Visible = true;
            }

            private void SetCommonParametrs(Control element, Size size, Point position, Color color, string title)
            {
                element.Size = size;
                element.Location = position;
                element.Text = title;
                element.BackColor = color;
                Controls.Add(element);
            }
            private Button CreateButton(Size size, Point position, Color color, string title)
            {
                Button button = new Button();
                SetCommonParametrs(button, size, position, color, title);
                return button;
            }
            private Label CreateLabel(Size size, Point position, Color color, string title)
            {
                Label label = new Label();
                SetCommonParametrs(label, size, position, color,title);
                return label;
            }
            private void LinkButton_Click(object sender, EventArgs e)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://youtu.be/dQw4w9WgXcQ?si=IiP6LyzXKYnji_N3",
                    UseShellExecute = true 
                });
            }
            private void LinkMegaButton_Click(object sender, EventArgs e)
            {
                for (int i = 1; i < 10; i++)
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "https://youtu.be/dQw4w9WgXcQ?si=IiP6LyzXKYnji_N3",
                        UseShellExecute = true
                    });
                }
            }
            private void LoadButton_Click(object sender, EventArgs e)
            {
                string url = "https://tenor.com/ru/view/пон-кот-жует-котпон-gif-27209646";

                try
                {
                    using (WebClient client = new WebClient())
                    {
                        byte[] data = client.DownloadData(url);
                        using (var stream = new System.IO.MemoryStream(data))
                        {
                            pictureBox.Image = Image.FromStream(stream);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}");
                }
            }
            private void LoadImageLabel_Click(object sender, EventArgs e)
            {
                string url = $"https://main-cdn.sbermegamarket.ru/big1/hlr-system/448/556/396/813/202/6/600004299563b0.jpeg";

                try
                {
                    using (WebClient client = new WebClient())
                    {
                        byte[] data = client.DownloadData(url);
                        using (var stream = new System.IO.MemoryStream(data))
                        {
                            if (pictureBox == null)
                            {
                                pictureBox = new PictureBox
                                {
                                    Size = new Size(600, 400),
                                    Location = new Point(100, 50),
                                    SizeMode = PictureBoxSizeMode.Zoom
                                };
                                Controls.Add(pictureBox);
                            }

                            pictureBox.Image = Image.FromStream(stream);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message);
                }
            }
        }
    }
    }

