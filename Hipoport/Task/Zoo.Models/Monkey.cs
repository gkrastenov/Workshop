namespace Zoo
{
    public class Monkey : Animal
    {
        public Monkey(int healthValue) 
            : base()
        {
            base.TypeAnimal = "Monkey";
            base.HealthValue = healthValue;
            base.DeathConditional = 30;
        }
    }
}
