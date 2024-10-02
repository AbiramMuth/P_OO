
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Helpers;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class Obstacle
    {

        public int x;
        public int y;
        private int _speed = 10;
        public int countx = 0;

        private Image obstacleImage = Image.FromFile("Images/bouclier.png");


        // faire en sorte que s'il se fait toucher 3 fois il est détruit(disparait)
        public void Update(List<Projectile> shoot)
        {
            x += _speed;
            countx++;
        }


        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(obstacleImage, x - obstacleImage.Width / 2, y - obstacleImage.Height / 2, 55, 55);
        }
    }
}
