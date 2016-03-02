using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankRan.Properties;

namespace TankRan
{
    class PlayerBullet:GameObject
    {
        Image img = Resources.tankmissile;
        public PlayerBullet(int x,int y,int speed):base(x,y,speed)
        {
            Width = img.Width;
            Heigth = img.Height;
        }
        public override void Move()
        {
            this.Y -= Speed;
            if(Y<=0)
            {
                new SingleObject().Remove(this);
            }
        }
        static Random r = new Random();
        public override void Draw(System.Drawing.Graphics e)
        {
            e.DrawImage(img, X, Y);
            Move();
        }

        public override void Fire()
        {
            throw new NotImplementedException();
        }
    }
}
