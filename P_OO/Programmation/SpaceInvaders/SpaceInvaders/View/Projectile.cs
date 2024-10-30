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
            width = 10;
            height = 20;
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
        public override string ToString()
        {
            return $"|";
        }
    }
}