using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimatedRainLoading
{
    public partial class Loading : Form
    {
        #region Arredondando as bordas da form
        [DllImportAttribute("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int left,
            int top,
            int right,
            int bottom,
            int width,
            int height
            );
        #endregion

        int[] rainSpeeds = {4, 6, 8, 3, 5, 6, 7, 4, 2, 5 }; // velocidade de cada gota de chuva
        int loadingSpeed = 2;
        float initialPercentage = 0;
        public Loading()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 7, 7)); // Arredondando as bordas
        }

        #region Timer 1 (para cair as gotas de água)
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                switch (i)
                {
                    case 0: // Animação gota de chuva 0
                        picRain1.Location = new Point(picRain1.Location.X, picRain1.Location.Y + rainSpeeds[i]); // Caindo a gota de chuva
                        if (picRain1.Location.Y > panelGotaChuva.Size.Height + picRain1.Size.Height) // Repetindo a queda da gota de chuva
                        {
                            picRain1.Location = new Point(picRain1.Location.X, 0 - picRain1.Size.Height);
                        }
                        break;

                    case 1: 
                        picRain2.Location = new Point(picRain2.Location.X, picRain2.Location.Y + rainSpeeds[i]);
                        if (picRain2.Location.Y > panelGotaChuva.Size.Height + picRain2.Size.Height)
                        {
                            picRain2.Location = new Point(picRain2.Location.X, 0 - picRain2.Size.Height);
                        }
                        break;

                    case 2: 
                        picRain3.Location = new Point(picRain3.Location.X, picRain3.Location.Y + rainSpeeds[i]);
                        if (picRain3.Location.Y > panelGotaChuva.Size.Height + picRain3.Size.Height)
                        {
                            picRain3.Location = new Point(picRain3.Location.X, 0 - picRain3.Size.Height);
                        }
                        break;

                    case 3: 
                        picRain4.Location = new Point(picRain4.Location.X, picRain4.Location.Y + rainSpeeds[i]);
                        if (picRain4.Location.Y > panelGotaChuva.Size.Height + picRain4.Size.Height)
                        {
                            picRain4.Location = new Point(picRain4.Location.X, 0 - picRain4.Size.Height);
                        }
                        break;

                    case 4: 
                        picRain5.Location = new Point(picRain5.Location.X, picRain5.Location.Y + rainSpeeds[i]);
                        if (picRain5.Location.Y > panelGotaChuva.Size.Height + picRain5.Size.Height)
                        {
                            picRain5.Location = new Point(picRain5.Location.X, 0 - picRain5.Size.Height);
                        }
                        break;

                    case 5: 
                        picRain6.Location = new Point(picRain6.Location.X, picRain6.Location.Y + rainSpeeds[i]);
                        if (picRain6.Location.Y > panelGotaChuva.Size.Height + picRain6.Size.Height)
                        {
                            picRain6.Location = new Point(picRain6.Location.X, 0 - picRain6.Size.Height);
                        }
                        break;

                    case 6: 
                        picRain7.Location = new Point(picRain7.Location.X, picRain7.Location.Y + rainSpeeds[i]);
                        if (picRain7.Location.Y > panelGotaChuva.Size.Height + picRain7.Size.Height)
                        {
                            picRain7.Location = new Point(picRain7.Location.X, 0 - picRain7.Size.Height);
                        }
                        break;

                    case 7: 
                        picRain8.Location = new Point(picRain8.Location.X, picRain8.Location.Y + rainSpeeds[i]);
                        if (picRain8.Location.Y > panelGotaChuva.Size.Height + picRain8.Size.Height)
                        {
                            picRain8.Location = new Point(picRain8.Location.X, 0 - picRain8.Size.Height);
                        }
                        break;

                    case 8: 
                        picRain9.Location = new Point(picRain9.Location.X, picRain9.Location.Y + rainSpeeds[i]);
                        if (picRain9.Location.Y > panelGotaChuva.Size.Height + picRain9.Size.Height)
                        {
                            picRain9.Location = new Point(picRain9.Location.X, 0 - picRain9.Size.Height);
                        }
                        break;

                    case 9: 
                        picRain10.Location = new Point(picRain10.Location.X, picRain10.Location.Y + rainSpeeds[i]);
                        if (picRain10.Location.Y > panelGotaChuva.Size.Height + picRain10.Size.Height)
                        {
                            picRain10.Location = new Point(picRain10.Location.X, 0 - picRain10.Size.Height);
                        }
                        break;
                }
            }
        }
        #endregion

        #region Evento Loading da form
        private void Loading_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timerPocaDaAgua.Start();
        }
        #endregion

        #region Timer da poça da água
        private void timerPocaDaAgua_Tick(object sender, EventArgs e)
        {
            initialPercentage += loadingSpeed;
            float percentage = initialPercentage / pictureBoxPoçaDaAgua.Height * 100;

            lblPorcentagem.Text = (int)percentage + " %";

            panelPoçaDaAgua.Location = new Point(panelPoçaDaAgua.Location.X, panelPoçaDaAgua.Location.Y + loadingSpeed);
            if (panelPoçaDaAgua.Location.Y > pictureBoxPoçaDaAgua.Location.Y + pictureBoxPoçaDaAgua.Height)
            {
                lblPorcentagem.Text = "100 %";
                this.timerPocaDaAgua.Stop();
            }
        }
        #endregion
    }
}
