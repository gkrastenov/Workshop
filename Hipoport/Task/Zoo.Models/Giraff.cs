using System;
namespace Zoo
{
    public class Giraff : Animal
    {
        public Giraff(int healthValue) 
            : base()
        {
            base.TypeAnimal = "Giraff";
            base.HealthValue = healthValue;
            base.DeathConditional = 50;
        }

    }
}
