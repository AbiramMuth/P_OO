namespace SpaceInvaders
{
    // La classe AirSpace représente le territoire au dessus duquel les drones peuvent voler
    // Il s'agit d'un formulaire (une fenêtre) qui montre une vue 2D depuis en dessus
    // Il n'y a donc pas de notion d'altitude qui intervient

    public partial class PlayForm : Form
    {
        public static readonly int WIDTH = 1200;        // Dimensions of the airspace
        public static readonly int HEIGHT = 600;

        // La flotte est l'ensemble des drones qui évoluent dans notre espace aérien
        private List<Player> fleet;
        private List<Projectile> shoot = new List<Projectile>();

        BufferedGraphicsContext currentContext;
        BufferedGraphics airspace;

        private bool Left = false;
        private bool Right = false;

        // Initialisation de l'espace aérien avec un certain nombre de drones
        public PlayForm(List<Player> fleet)
        {
            InitializeComponent();
            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;
            // Creates a BufferedGraphics instance associated with this form, and with
            // dimensions the same size as the drawing surface of the form.
            airspace = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);

            // Gestion des touches du clavier
            this.KeyDown += new KeyEventHandler(Pressed);
            this.KeyUp += new KeyEventHandler(Unpressed);
            
            this.fleet = fleet;
        }

        // Appuis sur les touches du clavier
        private void Pressed(object sender, KeyEventArgs key)
        {
            if (key.KeyCode == Keys.A || key.KeyCode == Keys.Left)
            {
                Left = true;
            }         
            if (key.KeyCode == Keys.D || key.KeyCode == Keys.Right)
            {
                Right = true;
            }
        }

        // Touche relacher
        private void Unpressed(object sender, KeyEventArgs key)
        {
            if (key.KeyCode == Keys.A || key.KeyCode == Keys.Left)
            {
                Left = false;
            }
            if (key.KeyCode == Keys.D || key.KeyCode == Keys.Right)
            {
                Right = false;
            }
        }

        // Affichage de la situation actuelle
        private void Render()
        {
            airspace.Graphics.Clear(Color.Violet);

            // draw drones
            foreach (Player drone in fleet)
            {
                drone.Render(airspace);
            }
            foreach (Projectile projectile in shoot)
            {
                projectile.Render(airspace);
            }
            airspace.Render();
        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        // update sert juste pour la position
        private void Update(int interval)
        {
            foreach (Player drone in fleet)
            {
                drone.Update(Left, Right);

                Projectile projectile = new Projectile();
                projectile.x = drone.x;
                projectile.y = drone.y;
                shoot.Add(projectile);

            }
            foreach (Projectile projectile in shoot)
            {
                projectile.Update();
            }
        }

        // Méthode appelée à chaque frame
        private void NewFrame(object sender, EventArgs e)
        {
            this.Update(ticker.Interval);
            this.Render();
        }
    }
}