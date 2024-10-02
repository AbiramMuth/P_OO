using SpaceInvaders.Helpers;
using System.Diagnostics.Metrics;

namespace SpaceInvaders
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Création du vaisseau du joueur
            List<Player> fleet = new List<Player>();
            Player vaisseau = new Player();
            vaisseau.x = TextHelpers.SCREEN_WIDTH / 2;
            vaisseau.y = TextHelpers.SCREEN_HEIGHT - 50;
            vaisseau.name = "BOB";
            fleet.Add(vaisseau);

            // Création des ennemis
            List<Ennemi> ennemis = new List<Ennemi>();

            for (int i = 1; i < TextHelpers.alea.Next(5, 60); i++)
            {
                Ennemi ennemi = new Ennemi();
                ennemi.x = TextHelpers.alea.Next(5, TextHelpers.SCREEN_WIDTH - 5);
                ennemi.y = 0;
                ennemis.Add(ennemi);
            }

            List<Obstacle> protection = new List<Obstacle>();

            Obstacle obstacle = new Obstacle();
            obstacle.x = 45;
            obstacle.y = TextHelpers.SCREEN_HEIGHT - 100;
            protection.Add(obstacle);

            // Démarrage
            Application.Run(new PlayForm(fleet, ennemis, protection));
        }
    }
}