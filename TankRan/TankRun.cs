using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TankRan.Properties;

namespace TankRan
{
    public partial class TankRun : Form
    {
        public TankRun()
        {
            InitializeComponent();
        }

        private void TankRun_Load(object sender, EventArgs e)
        {
            lblRanks.Text = Ranks.rank.ToString();
            lblCount.Text = Ranks.Counting.ToString();
            SoundPlayer sp = new SoundPlayer(Resources.start);
            sp.Play();
           this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            new SingleObject().Add(new Tank(100, 580, 20, Direction.Left));
        }

        private void TankRun_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void TankRun_KeyDown(object sender, KeyEventArgs e)
        {
            SingleObject.tank.KeyDown(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            picMain.Invalidate();
            new SingleObject().impact(timer1);
            Ranks.Counting += 50;
            lblCount.Text = Ranks.Counting.ToString();
            lblRanks.Text = Ranks.rank.ToString();
        }

        private void picMain_Paint(object sender, PaintEventArgs e)
        {
            new SingleObject().Draw(e.Graphics);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            timer1.Start();
            Ranks.rank = 1;
            Ranks.Counting = 0;
            SingleObject.liBullet = new List<Bullet>();
            SingleObject.liPB = new List<PlayerBullet>();
            SingleObject.liBm = new List<Boom>();
            SingleObject.tank.Img = Resources.p1tankU;
            SoundPlayer sp = new SoundPlayer(Resources.start);
            sp.Play();

        }
    }
}
