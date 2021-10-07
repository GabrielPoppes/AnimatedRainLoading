using AnimatedRainLoading.Class;
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

        int loadingSpeed = 2;
        float initialPercentage = 0;

        List<RainDrop> rainDrops = new List<RainDrop>();

        public Loading()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 7, 7)); // Arredondando as bordas
        }

        #region Timer 1 (para cair as gotas de água)
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach(RainDrop rainDrop in rainDrops)
            {
                rainDrop.Move();
            }
        }
        #endregion

        #region Evento Loading da form
        private void Loading_Load(object sender, EventArgs e)
        {
            rainDrops.Add(new RainDrop { Speed = 4, View = picRain1 });
            rainDrops.Add(new RainDrop { Speed = 6, View = picRain2 });
            rainDrops.Add(new RainDrop { Speed = 8, View = picRain3 });
            rainDrops.Add(new RainDrop { Speed = 3, View = picRain4 });
            rainDrops.Add(new RainDrop { Speed = 5, View = picRain5 });
            rainDrops.Add(new RainDrop { Speed = 6, View = picRain6 });
            rainDrops.Add(new RainDrop { Speed = 7, View = picRain7 });
            rainDrops.Add(new RainDrop { Speed = 4, View = picRain8 });
            rainDrops.Add(new RainDrop { Speed = 2, View = picRain9 });
            rainDrops.Add(new RainDrop { Speed = 4, View = picRain10 });
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
