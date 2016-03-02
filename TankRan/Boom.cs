using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankRan.Properties;

namespace TankRan
{
    class Boom:GameObject
    {
        Image img = Resources.blast5;
        public Boom(int x,int y):base(x,y)
        {
            Width = img.Width;
            Heigth = img.Height;
        }
        public override void Draw(System.Drawing.Graphics e)
        {
            e.DrawImage(img, X, Y);
        }

        public override void Fire()
        {
            throw new NotImplementedException();
        }
    }
}
