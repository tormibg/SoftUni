using System;
using EnvironmentSystem.Interfaces;
using EnvironmentSystem.Models.Objects;

namespace EnvironmentSystem.Core
{
    public class NewEngine : Engine
    {
        private readonly IController controller;
        private bool isPaused;

        public NewEngine(int worldWidth, int worldHeight, IObjectGenerator<EnvironmentObject> objectGenerator, ICollisionHandler collisionHandler, IRenderer renderer, IController controller)
            : base(worldWidth, worldHeight, objectGenerator, collisionHandler, renderer)
        {
            if (controller == null) throw new ArgumentNullException("controller");
            this.controller = controller;
            this.AttachControllerEvents();
        }

        private void AttachControllerEvents()
        {
            this.controller.Pause += controller_Pause;
        }

        private void controller_Pause(object sender, EventArgs e)
        {
            this.isPaused = !isPaused;
        }

        protected override void Insert(EnvironmentObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Object cannot be null");
            }
            base.Insert(obj);


        }

        protected override void ExecuteEnvironmentLoop()
        {
            this.controller.ProcessInput();

            if (!this.isPaused)
            {
                base.ExecuteEnvironmentLoop();   
            }
            
        }
    }
}