using SpaceInvaders.Helpers;
using System.Windows.Forms;


namespace SpaceInvaders
{
    // Cette partie de la classe Drone définit comment on peut voir un drone

    public partial class Projectile
    {
        public int width;                       // Largeur du tirs
        public int height;                      // Hauteur du tirs

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }

       
       

        public Projectile()
        {
            width = 9;
            height = 15;
        }

        // box du tirs
        public Rectangle BoundingBox
        {
            get { return new Rectangle(x, y, width, height); }
        }

        // Affichage du tirs
        public void Render(BufferedGraphics drawingSpace)
        {
            // Dessin du tirs en string 
            //drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, x, y);

            // Dessin de l'image du missile
            drawingSpace.Graphics.DrawImage(Properties.Resources.tirs, x - Width / 2, y - Height / 2, width, height);  
        }
        // image tirs ennemie
        //public void Render2(BufferedGraphics drawingSpace)
        //{
        //    drawingSpace.Graphics.DrawImage(alientirs, x - alientirs.Width / 2, y - alientirs.Height / 2, Width, Height);
        //}
        // De manière textuelle, tirs
        public override string ToString()
        {
            return $"|";
        }
    }
}