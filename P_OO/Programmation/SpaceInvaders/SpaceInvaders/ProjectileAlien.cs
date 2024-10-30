using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class ProjectileAlien
    {
        public int x;                                // Position en X depuis la gauche de l'espace aérien
        public int y;                                // Position en Y depuis le haut de l'espace aérien
        private int _speed = 30;                     // écart des espaces entre les tirs
        public int width = 10;                           // Largeur du tirs
        public int height = 10;                          // Hauteur du tirs

        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }

        public Rectangle BoundingBox
        {
            get { return new Rectangle(x, y, Width, Height); }
        }

        public ProjectileAlien(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public void Update()
        {
            y += _speed;

            // vérification des collisions entre le tir de l'ennemi et le vaisseau
            bool CheckCollision(ProjectileAlien tirs, Player vaisseau)
            {
                return tirs.BoundingBox.IntersectsWith(vaisseau.BoundingBox);
            }
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Properties.Resources.circle_PNG28, x, y, Width, Height);
        }


    }
}
