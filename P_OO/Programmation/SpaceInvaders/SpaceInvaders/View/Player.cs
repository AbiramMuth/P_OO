using SpaceInvaders.Helpers;

namespace SpaceInvaders
{
    // Cette partie de la classe Drone définit comment on peut voir un drone

    public partial class Player
    {

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            
            // Dessin et position de l'image du vaisseau, Ajouter partout propreties.resousrces
            drawingSpace.Graphics.DrawImage(Properties.Resources.space, x - 13, y - 5, 40, 40); 
            // position du texte BOB
            drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, x + 10, y - 10);
        }
     
        // De manière textuelle
        public override string ToString()
        {
            return $"{name} ({((int)((double)charge / 1000 * 100)).ToString()}%)";
        }
    }
}