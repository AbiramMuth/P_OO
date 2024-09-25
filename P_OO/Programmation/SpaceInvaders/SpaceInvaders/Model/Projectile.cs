namespace SpaceInvaders
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Projectile
    {
        public int x;                                // Position en X depuis la gauche de l'espace aérien
        public int y;                                // Position en Y depuis le haut de l'espace aérien
        private int _speed = 20;                     // écart des espaces entre les tirs   

        // Mouvement de l'utilisateur horizontalement, sans sortir du cadre du jeu
        public void Update()
        {

            y -= _speed;
        }
    }
}
