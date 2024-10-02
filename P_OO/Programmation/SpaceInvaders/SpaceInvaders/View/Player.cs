using SpaceInvaders.Helpers;

namespace SpaceInvaders
{
    // Cette partie de la classe Drone définit comment on peut voir un drone

    public partial class Player
    {
        // Image du vaisseau
        private Image spaceImage = Image.FromFile("Images/space.png");

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            // Dessin et position de l'image du vaisseau
            drawingSpace.Graphics.DrawImage(spaceImage, x - 13, y - 5, 40, 40); 
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