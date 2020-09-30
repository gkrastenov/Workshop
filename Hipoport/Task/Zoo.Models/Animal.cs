namespace Zoo
{
    using Zoo.Models.Interfaces;

    public abstract class Animal : ILeavable
    {
        public string TypeAnimal;

        public int DeathConditional;

        public int HealthValue;

        public bool IsDeadAnimal { get; set; }

        public Animal()
        {
            this.IsDeadAnimal = false;
        }

        public void CheckIsDeadAnimal()
        {
            if (this.HealthValue < this.DeathConditional)
            {
                this.IsDeadAnimal = true;
            }
        }

    }
}
