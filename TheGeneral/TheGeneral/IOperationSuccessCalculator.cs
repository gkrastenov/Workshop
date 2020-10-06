namespace TheGeneral
{
    public interface IOperationSuccessCalculator
    {
        bool IsAttackSuccesful(int x, int y);
        bool IsDefenceSuccesful(int x, int y);
    }
}
