using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimatedRainLoading.Class
{
    class RainDrop
    {
        public int Speed { get; set; } = 0;
        public PictureBox View { get; set; }
        public void Move()
        {
            View.Top += Speed;
            if (View.Top > View.Parent.Height)
            {
                View.Top = -View.Top;
            }
        }
    }
}
