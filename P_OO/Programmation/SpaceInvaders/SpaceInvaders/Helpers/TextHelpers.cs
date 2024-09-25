namespace SpaceInvaders.Helpers
{
    // Outils pour écrire du texte dans un environnement graphique
    internal static class TextHelpers
    {

        public static Random alea = new Random();

        public static Font drawFont = new Font("Arial", 10);
        public static SolidBrush writingBrush = new SolidBrush(Color.Black);

        public const int SCREEN_HEIGHT = 600;
        public const int SCREEN_WIDTH = 1200;
    }
}
