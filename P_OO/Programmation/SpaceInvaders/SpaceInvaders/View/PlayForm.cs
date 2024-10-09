namespace SpaceInvaders
{
    // La classe AirSpace représente le territoire au dessus duquel les drones peuvent voler
    // Il s'agit d'un formulaire (une fenêtre) qui montre une vue 2D depuis en dessus
    // Il n'y a donc pas de notion d'altitude qui intervient

    public partial class PlayForm : Form
    {
        private List<Player> fleet;
        private List<Projectile> shoot = new List<Projectile>();
        private List<Projectile> shoot2 = new List<Projectile>();
        private List<Ennemi> ennemi;
        private List<Obstacle> protection;

        BufferedGraphicsContext currentContext;
        BufferedGraphics airspace;
        
        // Booléen pour les déplacements
        private bool Left = false;
        private bool Right = false;

        private bool obstacleshoot = false;
        // booléen pour les tirs
        private bool space = false;

        // Initialisation de l'espace aérien avec un certain nombre de drones
        public PlayForm(List<Player> fleet, List<Ennemi> ennemi, List<Obstacle> protection)
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
            this.shoot = shoot;
            this.ennemi = ennemi;
            this.protection = protection;
        }


        // Appuis sur les touches du clavier
        private void Pressed(object sender, KeyEventArgs key)
        {
            // Touches pour se déplacer
            if (key.KeyCode == Keys.A || key.KeyCode == Keys.Left)
            {
                Left = true;
            }         
            if (key.KeyCode == Keys.D || key.KeyCode == Keys.Right)
            {
                Right = true;
            }
            // Touches pour tirer
            if (key.KeyCode == Keys.Space)
            {
                space = true;
            }
        }


        // Touche relacher
        private void Unpressed(object sender, KeyEventArgs key)
        {
            // Touches pour se déplacer
            if (key.KeyCode == Keys.A || key.KeyCode == Keys.Left)
            {
                Left = false;
            }
            if (key.KeyCode == Keys.D || key.KeyCode == Keys.Right)
            {
                Right = false;
            }
            // Touches pour tirer
            if (key.KeyCode == Keys.Space)
            {
                space = false;
            }
        }
        



        // Affichage de la situation actuelle
        private void Render()
        {
            airspace.Graphics.Clear(Color.Violet);

            // dessin du vaisseau
            foreach (Player vaisseau in fleet)
            {
                vaisseau.Render(airspace);
            }
            // dessin des tirs
            foreach (Projectile projectile in shoot)
            {
                projectile.Render(airspace);
            }
            // dessin des ennemi
            foreach (Ennemi alien in ennemi)
            {
                alien.Render(airspace);
            }
            foreach(Obstacle protect in protection)
            {
                Projectile tirs = new Projectile();
                if (space)
                {
                    protect.Render(airspace);
                    obstacleshoot = false;
                }
                else
                {
                    protect.Render2(airspace);
                   obstacleshoot = true;
                }

            }
            airspace.Render();
        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        // update sert juste pour la position
        private void Update(int interval)
        {
            foreach (Player vaisseau in fleet)
            {
                vaisseau.Update(Left, Right);

                if (space)
                {
                    Projectile projectile2 = new Projectile();
                    projectile2.x = vaisseau.x + 2;
                    projectile2.y = vaisseau.y;
                    shoot.Add(projectile2);
                }
            }
            foreach (Projectile projectile in shoot)
            {
                projectile.Update();
            }
            foreach (Ennemi alien in ennemi)
            {
                alien.Update();
            }
            foreach (Obstacle protect in protection)
            {
                protect.Update(shoot);

                if (obstacleshoot)
                {
                    Projectile projectile = new Projectile();
                    projectile.x = protect.x - 25;
                    projectile.y = protect.y - 50;
                    shoot.Add(projectile);
                }
                
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