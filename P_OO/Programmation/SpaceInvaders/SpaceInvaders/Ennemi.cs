﻿using SpaceInvaders.Helpers;
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
        public int y;                                 // Position en Y de l'ennemi
        private int _speed = 10;

        private Image ennemiImage = Image.FromFile("Images/Alien.png");

        public void Update() 
        {

            y += _speed;
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(ennemiImage, x - ennemiImage.Width / 2, y - ennemiImage.Height / 2, 32, 32);
        }
    }
}