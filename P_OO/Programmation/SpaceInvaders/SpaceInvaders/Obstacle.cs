
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
        bool move = false;
  

        private Image obstacleImage = Image.FromFile("Images/bouclier.png");
        private Image obstacleTirs = Image.FromFile("Images/bouclierTirs.png");


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
            }
            // Si il est au milieur de l'écran, pars à gauche 
            if (x >= TextHelpers.SCREEN_WIDTH / 2)
            {
                move = false;
            }
            if (move == false)
            {
                x -= _speed;
            }
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(obstacleImage, x - obstacleImage.Width / 2, y - obstacleImage.Height / 2, 55, 55);   
        }
        public void Render2(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(obstacleTirs, x - obstacleImage.Width / 2, y - obstacleImage.Height / 2, 55, 55);
        }
    }
}





























































































// si tu trouves ce message, t'es le goat que tu crois l'être