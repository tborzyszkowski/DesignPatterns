using System;
using System.Collections.Generic;
using System.Windows.Forms;

using SolarSystem.Models;
using SolarSystem.Utils;
using SolarSystem.Utils.Abstraction;

namespace SolarSystem
{
    public partial class MainWindow : Form, IObserverSubject
    {
        private const int INTERVAL = 15;

        private Timer timer;
        private readonly List<PlanetDrawer> drawers = new List<PlanetDrawer>();

        public MainWindow()
        {
            this.InitializeComponent();
            this.InitializeTimer();
            this.AddEventListeners();
        }

        public void NotifyAxisChanged()
        {
            this.drawers.ForEach(d =>
                d.AxisChanged(this.mainPanel.Height, this.mainPanel.Width, this.trackBar.Value));
        }

        public void NotifyStateChanged(Type newState)
        {
            this.drawers.ForEach(d => d.StateChanged(newState));
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            SolarSystemObjects solarSystemObjects = AstronomicalObjectConstructor.Instance.CreateSolarSystemObjects();
            foreach (IPlanet aObject in solarSystemObjects)
            {
                this.drawers.Add(new PlanetDrawer(aObject, this.mainPanel.Height, this.mainPanel.Width, this.trackBar.Value));
                this.mainPanel.Controls.Add(aObject.Picture);
            }
        }

        private void InitializeTimer()
        {
            this.timer = new Timer { Interval = INTERVAL };
            this.timer.Tick += (sender, eventArgs) => this.drawers.ForEach(d => d.Move());
            this.timer.Start();
        }

        private void AddEventListeners()
        {
            void OnAxisChanged(object sender, EventArgs e) => this.NotifyAxisChanged();
            this.Resize += OnAxisChanged;
            this.trackBar.Scroll += OnAxisChanged;

            void OnStateChanged(object sender, EventArgs e)
            {
                var button = (Button)sender;
                Type newState = null;

                switch (button.Name)
                {
                    case "play":
                        newState = typeof(RunningState);
                        this.play.Enabled = false;
                        this.pause.Enabled = true;
                        this.stop.Enabled = true;
                        break;
                    case "pause":
                        newState = typeof(PausedState);
                        this.play.Enabled = true;
                        this.pause.Enabled = false;
                        this.stop.Enabled = true;
                        break;
                    case "stop":
                        newState = typeof(StopedState);
                        this.play.Enabled = true;
                        this.pause.Enabled = false;
                        this.stop.Enabled = false;
                        break;
                }
                this.NotifyStateChanged(newState);
            };

            this.stop.Click += OnStateChanged;
            this.pause.Click += OnStateChanged;
            this.play.Click += OnStateChanged;
        }
    }
}
