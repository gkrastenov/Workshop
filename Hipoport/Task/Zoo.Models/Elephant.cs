namespace Zoo
{
    public class Elephant : Animal
    {
        public Elephant(int healthValue) 
            : base()
        {
            base.TypeAnimal = "Elephant";
            base.HealthValue = healthValue;
            base.DeathConditional = 70;
        }

       
    }
}
