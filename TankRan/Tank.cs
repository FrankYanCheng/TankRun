using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TankRan.Properties;

namespace TankRan
{
   class Tank:GameObject
    {
      public Image Img=Resources.p1tankU;
       public Tank()
       {

       }
       public Tank(int x,int y,int speed,Direction direct):base(x,y,direct,speed)
       {
           Width = Img.Width;
           Heigth = Img.Height;
       }
      
       public override void Draw(Graphics e)
       {
           e.DrawImage(Img, X, Y);
         
       }
       public void KeyDown(KeyEventArgs e)
       {
           switch(e.KeyCode)
           {
               case Keys.A:
                   this.Direct = Direction.Left;
                   Move();
                   break;
               case Keys.D:
                   this.Direct = Direction.Right;
                   Move();
                   break;
               case Keys.J:
                   Fire();
                   break;
           }
       }
       public override void Fire()
       {
           SoundPlayer sp = new SoundPlayer(Resources.fire);
           sp.Play();
           new SingleObject().Add(new PlayerBullet(this.X+Width/2-2, this.Y,10));
       }
       /// <summary>
       /// 玩家坦克爆照
       /// </summary>
       public void Boom()
       {
           new SingleObject().Remove(this);
       }
    }
}
