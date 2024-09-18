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

            // Création de la flotte de drones
            List<Player> fleet= new List<Player>();
            Player drone = new Player();
            drone.x = PlayForm.WIDTH / 2;
            drone.y = PlayForm.HEIGHT - 50;
            drone.name = "BOB";
            fleet.Add(drone);



            // Démarrage
            Application.Run(new PlayForm(fleet));
        }
    }
}