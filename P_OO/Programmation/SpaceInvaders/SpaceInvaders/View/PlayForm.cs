using SpaceInvaders.Helpers;
using System.Security.Cryptography.X509Certificates;

namespace SpaceInvaders
{
    // La classe AirSpace représente le territoire au dessus duquel les drones peuvent voler
    // Il s'agit d'un formulaire (une fenêtre) qui montre une vue 2D depuis en dessus
    // Il n'y a donc pas de notion d'altitude qui intervient

    public partial class PlayForm : Form
    {
        Random alea = new Random();
        private List<Player> fleet;
        private List<Projectile> shoot = new List<Projectile>();
        private List<Projectile> shoot2 = new List<Projectile>();
        private List<Ennemi> ennemi;
        private List<Obstacle> protection;
        public List<ProjectileAlien> alientirs;

        BufferedGraphicsContext currentContext;
        BufferedGraphics airspace;
        
        // Booléen pour les déplacements
        private bool Left = false;
        private bool Right = false;

        public bool obstacleshoot = false;
        // booléen pour les tirs
        private bool space = false;

        private int timershoot = 0;

        // nombres aléatoire pour la séquence de tirs pour les ennemis
        private int numberalea = 1;
        private int alienshoot = 4;
        //private int numberalea = TextHelpers.alea.Next(1, 5);
        //private int alienshoot = TextHelpers.alea.Next(3, 5);

        // Initialisation de l'espace aérien avec un certain nombre de drones
        public PlayForm(List<Player> fleet, List<Ennemi> ennemi, List<Obstacle> protection, List<ProjectileAlien> alientirs)
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
            this.alientirs = alientirs;
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
            foreach (Ennemi alien in ennemi.ToList())
            {
                alien.Render(airspace);
            }
            foreach(Obstacle protect in protection)
            {
                // Si le joueur press espace, l'obstacle devient un mur de protection
                if (space)
                {
                    protect.Render(airspace);
                    obstacleshoot = false;
                }
                // Si non, l'obstacle se transforme pour pouvoir tirer su rles ennemis
                else
                {
                    protect.Render2(airspace);
                   obstacleshoot = true;
                }
            }
            foreach(ProjectileAlien tir in alientirs)
            {
                tir.Render(airspace);
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

                // Si le joueur press espace, le vaisseau va tirer
                if (space)
                {
                    if (timershoot >= 3)
                    {
                        Projectile projectile2 = new Projectile();
                        projectile2.x = vaisseau.x + 2;
                        projectile2.y = vaisseau.y;
                        shoot.Add(projectile2);
                        timershoot = 0;
                    }
                    timershoot++;
                }
            }
            foreach (Projectile projectile in shoot.ToList())
            {
                if (projectile.y > 0)
                {
                    projectile.Update();
                }
                else
                {
                    shoot.Remove(projectile);
                }
            }
            for (int i=0; i < ennemi.Count; i++)
            {
                if (ennemi[i].y < TextHelpers.SCREEN_HEIGHT)
                {
                    ennemi[i].Update(alientirs);
                }
                else
                {
                    ennemi.Remove(ennemi[i]);
                }
            }
            foreach (Obstacle protect in protection)
            {
                protect.Update(shoot);

                // Si le vaisseau ne tire pas, l'obstacle se transforme pour pouvoir tirer en continu
                if (obstacleshoot)
                {
                    // temps de tirs pour l'obstacle 
                    if (timershoot >= 6)
                    {
                        Projectile projectile = new Projectile();
                        projectile.x = protect.x + 25;
                        projectile.y = protect.y - 10;
                        shoot.Add(projectile);
                        timershoot = 0;
                    }
                    timershoot++;
                }
            }


            for (int i = shoot.Count - 1; i >= 0; i--)  // On parcourt la liste à l'envers pour éviter les problèmes d'index
            {
                Projectile bullet = shoot[i];

                for (int j = ennemi.Count - 1; j >= 0; j--)  // Parcours aussi la liste d'ennemis à l'envers
                {
                    Ennemi enemy = ennemi[j];
                    Console.WriteLine(shoot);
                    Console.WriteLine(ennemi);

                    // supprime les ennemis qui sort de l'écran
                    if(enemy.y >= TextHelpers.SCREEN_HEIGHT)
                    {
                        ennemi.RemoveAt(j);
                    }
                    // Collision entre les tirs et l'ennemis
                    if (bullet.BoundingBox.IntersectsWith(enemy.BoundingBox))
                    {
                        ennemi.RemoveAt(j);
                        shoot.RemoveAt(i);
                        break;
                    }
                    // délai aléatoires pour les tirs pour les ennemis
                    if (enemy._timershoot >= alea.Next(100, 300))
                    {
                        ProjectileAlien projectile = new ProjectileAlien(enemy.x - 5, enemy.y - 40);
                        projectile.Update();
                        alientirs.Add(projectile);
                        enemy._timershoot = 0;
                    }
                    enemy._timershoot++;
                }
            }
            for (int i=0; i < alientirs.Count; i++)
            {
                // supprime le tirs ennemis si il sort de l'écran
                if (alientirs[i].y >= TextHelpers.SCREEN_HEIGHT)
                {
                    alientirs.Remove(alientirs[i]);
                }
                else
                {
                    alientirs[i].Update();
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