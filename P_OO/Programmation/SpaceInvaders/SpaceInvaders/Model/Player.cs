using SpaceInvaders.Helpers;

namespace SpaceInvaders
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Player
    {
        Random alea = new Random();

        public int charge = 1000;                     // La charge actuelle de la batterie
        public string name;                           // Un nom
        public int x;                                // Position en X depuis la gauche de l'espace aérien
        public int y;                                 // Position en Y depuis le haut de l'espace aérien
        public int width;                       // Largeur du tirs
        public int height;                      // Hauteur du tirs
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public Rectangle BoundingBox
        {
            get { return new Rectangle(x, y, Width, Height); }
        }

        // Mouvement de l'utilisateur horizontalement, sans sortir du cadre du jeu
        public void Update(bool Left, bool Right)
        {
            if (Left)
            {
                if (!(x - 25 <= 0))
                {
                    x -= 15;
                }
            }
            if (Right)
            {
                if (!(x + 40 >= TextHelpers.SCREEN_WIDTH))
                {
                    x += 15;
                }
            }
        }
    }
}
