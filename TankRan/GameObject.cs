using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankRan
{
 public   enum Direction
    {
       Left,Right,Up,Down
    }
   abstract class GameObject
    {
        int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        int width;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        int heigth;

        public int Heigth
        {
            get { return heigth; }
            set { heigth = value; }
        }

        public Direction Direct { set; get; }


        public GameObject(int x, int y,Direction direct,int speed)
        {
            X = x;
            Y = y;
            Direct = direct;
            Speed = speed;
       }
       /// <summary>
       /// 玩家子弹的重载
       /// </summary>
       /// <param name="x"></param>
       /// <param name="y"></param>
       /// <param name="speed"></param>
       public GameObject(int x, int y,int speed)
        {
            X = x;
            Y = y;
           Speed = speed;
        }
       public  GameObject()
       {

       }
       public GameObject(int x,int y)
       {
           X = x;
           Y = y;
       }
        public GameObject(int speed)
        {
            Speed = speed;
        }
       public Rectangle GetRectange()
       {
           return new Rectangle(X, Y, Width, Heigth);
       }
      public abstract void Draw(Graphics e);
        public virtual void Move()
        {
            switch(this.Direct)
            {
                case Direction.Left:
                    this.X -= this.Speed;
                    break;
                case Direction.Right:
                    this.X+= this.Speed;
                    break;
                 
          }
            if(X>=1380)
            {
                X = 1380;
            }
            if(X<=0)
            {
                X = 0;
            }
       }
        public abstract void Fire();
    }
}
