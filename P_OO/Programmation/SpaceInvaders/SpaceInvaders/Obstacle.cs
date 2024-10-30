
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

        public int x;                           // position
        public int y;
        private int _speed = 30;                // Vitesse    
        bool move = false;
        public int width;                       // Largeur de l'obstacle
        public int height;                      // Hauteur de l'obstacle

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }

     


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
            if (x >= TextHelpers.SCREEN_WIDTH)
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
            drawingSpace.Graphics.DrawImage(Properties.Resources.bouclier, x - Width / 2, y - Height / 2, 55, 55);   
        }
        public void Render2(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Properties.Resources.bouclierTirs, x - Width / 2, y - Height / 2, 55, 55);
        }
    }
}
