
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

        public int x;                   // position
        public int y;
        private int _speed = 10;         // Vitesse
        private int countx = 0;          
        bool move = false;              

        private Image obstacleImage = Image.FromFile("Images/bouclier.png");


        // faire en sorte que s'il se fait toucher 3 fois il est détruit(disparait)
        public void Update(List<Projectile> shoot)
        {
            // Si proche du bord de l'écran de gauche, pars à droite 
            if (x <= 45)
            {
                move = true;
            }
            if (move == true)
            {
                x += _speed;
                countx++;
            }
            // Si proche du bord de l'écran de droite, pars à gauche 
            if (x >= TextHelpers.SCREEN_WIDTH)
            {
                move = false;
            }
            if (move == false)
            {
                x -= _speed;
                countx--;
            }
        }


        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(obstacleImage, x - obstacleImage.Width / 2, y - obstacleImage.Height / 2, 55, 55);
        }
    }
}
