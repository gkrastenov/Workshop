namespace TheGeneral
{
    using System;

    public class OperationSuccessCalculator : IOperationSuccessCalculator
    {
        private const int width = 200;
        private const int hight = 300;
        public OperationSuccessCalculator()
        {

        }
        public bool IsAttackSuccesful(int x, int y)
        {
            ValidationInput(x, y);

            int calc = x + y - 5;
            if (calc % 2 == 0)
            {
                return true;
            }
            return false;
        }

        public bool IsDefenceSuccesful(int x, int y)
        {
           // ValidationInput(x, y); -> to fail the test

            int calc = x * y - 5;
            if (calc % 2 == 0)
            {
                return true;
            }
            return false;
        }
        private void ValidationInput(int x, int y)
        {
            if (x>200 || x<0 
                || y>300 || y<0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
