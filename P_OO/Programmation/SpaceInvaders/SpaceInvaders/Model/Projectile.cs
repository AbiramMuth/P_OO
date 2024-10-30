namespace SpaceInvaders
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Projectile
    {
        public int x;                                // Position en X depuis la gauche de l'espace aérien
        public int y;                                // Position en Y depuis le haut de l'espace aérien
        private int _speed = 30;                     // écart des espaces entre les tirs


        // Mouvement de l'utilisateur horizontalement, sans sortir du cadre du jeu
        public void Update()
        {
            // vérification des collisions entre le tir du joueur et l'ennemis
            bool CheckCollision(Ennemi enemy, Projectile projectile)
            {
                return enemy.BoundingBox.IntersectsWith(projectile.BoundingBox);
            }
            y -= _speed;   
        }
    }
}
