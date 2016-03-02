using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TankRan.Properties;
namespace TankRan
{
  class Bullet:GameObject
    {
      Image Img = Resources.enemymissile;
      public Bullet(int speed):base(speed)
      {
         Width =Img.Width;
         X = r.Next(0,1300);
         Y = 0;
         Heigth=Img.Height;
      }
      static Random r = new Random();
        public override void Draw(Graphics e)
        {
            e.DrawImage(Img,X,Y);
            Move();

        }
        public override void Move()
        {       
            this.Y+=this.Speed;
            if(this.Y>=700)
            {
                new SingleObject().Remove(this);
            }
        }
        public override void Fire()
        {
           
        }
    }
}
