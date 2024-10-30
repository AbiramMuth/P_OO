using SpaceInvaders.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class Ennemi
    {
        Random alea = new Random();

        public int x;                                // Position X, de l'ennemi
        public int y;                                // Position en Y de l'ennemi
        public int width;                            // Largeur de l'ennemi
        public int height;                           // Hauteur de l'ennemi
        private int _speed = 8;                      // Vitesse des ennemis (plus c'est haut, plus c'est rapide)
        public int _timershoot = 0;                 // Délai de chaque tire


        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }


        public Ennemi()
        {
            width = 40;  
            height = 40;
        }

        public Rectangle BoundingBox
        {
            get { return new Rectangle(x, y, Width, Height); }
        }

        public void Update(List<ProjectileAlien> alientirs) 
        {
            y += _speed;
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Properties.Resources.Alien, x - Width / 2, y - Height / 2, Width, Height);
        }
        //public void Render2(BufferedGraphics drawingSpace)
        //{
        //    drawingSpace.Graphics.DrawImage(ennemiTirs, x - ennemiTirs.Width / 2, y - ennemiTirs.Height / 2, Width, Height);
        //}
    }
}
