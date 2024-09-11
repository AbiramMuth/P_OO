namespace SpaceInvaders
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Player
    {
        Random alea = new Random();

        public int charge = 1000;                     // La charge actuelle de la batterie
        public string name;                           // Un nom
        public int x ;                                // Position en X depuis la gauche de l'espace aérien
        public int y;                                 // Position en Y depuis le haut de l'espace aérien
 

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(bool Left, bool Right)
        {
            if (Left)
            {
                if (!(x - 5 <= 0))
                {
                    x -= 5;
                }
            }
            if (Right)
            {
                if (!(x + 5 >= PlayForm.WIDTH))
                {
                    x += 5;
                }
            }
        }
    
    }
}
