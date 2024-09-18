using SpaceInvaders.Helpers;
using System.Windows.Forms;

namespace SpaceInvaders
{
    // Cette partie de la classe Drone définit comment on peut voir un drone

    public partial class Projectile
    {
        // Affichage
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, x, y);
        }
     
        // De manière textuelle, tirs
        public override string ToString()
        {
            return $"|";
        }
    }
}