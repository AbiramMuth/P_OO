using SpaceInvaders.Helpers;

namespace SpaceInvaders
{
    // Cette partie de la classe Drone définit comment on peut voir un drone

    public partial class Projectile
    {
        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, x, y);
        }
     
        // De manière textuelle
        public override string ToString()
        {
            return $"|";
        }
    }
}