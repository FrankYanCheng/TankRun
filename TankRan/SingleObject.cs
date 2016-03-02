using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using TankRan.Properties;
namespace TankRan
{
    class SingleObject
    {
        public static Tank tank;
        public static List<Bullet> liBullet=new List<Bullet>();
        public static List<PlayerBullet> liPB = new List<PlayerBullet>();
        public static List<Boom> liBm = new List<Boom>();
        public void Add(GameObject thing)
        {
            if(thing is Tank)
            {
                tank = thing as Tank;
            }
            if(thing is Bullet)
            {
                liBullet.Add(thing as Bullet);
            }
            if(thing is PlayerBullet)
            {
                liPB.Add(thing as PlayerBullet);
            }
            if(thing is Boom)
            {
                liBm.Add(thing as Boom);
            }
        }
        static Random r = new Random();
        public void  Draw(Graphics e)
        {
            Ranks.Counting += 20;
            tank.Draw(e);
            for(int i=0;i<liBullet.Count;i++)
            {
                liBullet[i].Draw(e);
            }
            if (liBullet.Count <= 20 + Ranks.rank)
            {
                Add(new Bullet(r.Next(10 + Ranks.rank, 26 + Ranks.rank)));
            }
            if (Ranks.Counting >=Ranks.rank*10000)
            {
            
                Ranks.rank += 1;
            }
            for(int i=0;i<liPB.Count;i++)
            {
                liPB[i].Draw(e);
            }
            for(int i=0;i<liBm.Count;i++)
            {
                liBm[i].Draw(e);
            }
        }
        public void Remove(GameObject thing)
        {
            if (thing is Tank)
            {
                //tank = null;
                MessageBox.Show("You Lose!");
            }
            if (thing is Bullet)
            {
                liBullet.Remove(thing as Bullet);
            }
            if(thing is PlayerBullet)
            {
                liPB.Remove(thing as PlayerBullet);
            }
            if(thing is Boom)
            {
                liBm.Remove(thing as Boom);
            }
        }
        public void impact(Timer timer)
        {
            for(int i=0;i<liBullet.Count;i++)
            {
               if(liBullet[i].GetRectange().IntersectsWith(tank.GetRectange()))
               {
                   timer.Enabled = false;
                   SoundPlayer sp = new SoundPlayer(Resources.blast);
                   sp.Play();
                   new SingleObject().Add(new Boom(tank.X-15, tank.Y-15));
                   tank.Img = Resources.Black;
                   MessageBox.Show("最终得分"+Ranks.Counting.ToString());
                   Ranks.Counting = 0;
                   Ranks.rank = 1;
                   
                   break;
               }
            }
            for(int i=0;i<liPB.Count;i++)
            {
                for(int j=0;j<liBullet.Count;j++)
                {
                    if(liPB[i].GetRectange().IntersectsWith(liBullet[j].GetRectange()))
                    {
                        SoundPlayer sp = new SoundPlayer(Resources.blast);
                        sp.Play();
                        Ranks.Counting += 100;
                        new SingleObject().Remove(liPB[i]);
                        new SingleObject().Remove(liBullet[j]);
                        break;
                    }
                }
            }
        }
    }
}
