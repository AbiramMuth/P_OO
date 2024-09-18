using SpaceInvaders.Helpers;

namespace SpaceInvaders
{
    // Cette partie de la classe Drone définit comment on peut voir un drone

    public partial class Player
    {
        private Pen droneBrush = new Pen(new SolidBrush(Color.Purple), 3); // brush permet de dessiner, couleur, l'epaisseur

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawEllipse(droneBrush, new Rectangle(x - 4, y - 2, 8, 8)); // a la postion du drone, 8,8 (taille de l'ellipse rond)
            drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, x + 5, y - 5);
        }
     
        // De manière textuelle
        public override string ToString()
        {
            return $"{name} ({((int)((double)charge / 1000 * 100)).ToString()}%)";
        }
    }
}