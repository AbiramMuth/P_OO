using SpaceInvaders.Helpers;
using System;
using System.Diagnostics.Metrics;
using System.Timers;

namespace SpaceInvaders
{
    internal static class Program
    {
        private static List<Ennemi> ennemis = new List<Ennemi>();
        private static List<Player> fleet = new List<Player>();
        private static List<Obstacle> protection = new List<Obstacle>();
        private static System.Timers.Timer SpawnTimer;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            

            Player vaisseau = new Player();
            vaisseau.x = TextHelpers.SCREEN_WIDTH / 2;
            vaisseau.y = TextHelpers.SCREEN_HEIGHT - 50;
            vaisseau.name = "Player";
            fleet.Add(vaisseau);

            SpawnTimer = new System.Timers.Timer();
            // temps écoulé
            SpawnTimer.Elapsed += AlienSpawn;
            TimingAlien();

 

            Obstacle obstacle = new Obstacle();
            obstacle.x = 45;
            obstacle.y = TextHelpers.SCREEN_HEIGHT - 100;
            protection.Add(obstacle);

            // Démarrage
            Application.Run(new PlayForm(fleet, ennemis, protection));

        }
        private static void AlienSpawn(object sender, ElapsedEventArgs e)
        {
            // Création des ennemis
            Ennemi ennemi = new Ennemi();

            ennemi.x = TextHelpers.alea.Next(5, TextHelpers.SCREEN_WIDTH - 5);
            ennemi.y = 0;
            ennemis.Add(ennemi);

            // Temps d'apparition de l'ennemi
            TimingAlien();
        }
        /// <summary>
        /// Apparition de l'ennemi
        /// </summary>
        public static void TimingAlien()
        {
            // 1 à 3s
            int timing =TextHelpers.alea.Next(1000, 2000);

            SpawnTimer.Interval = timing;

            // Re-démarrer le timer avec le nouvel intervalle
            SpawnTimer.Start();
            Console.WriteLine(timing);
        }

    }
}