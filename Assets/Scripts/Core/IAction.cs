namespace RPG.Core
{
    //Instead of class, we write interface
    //Everything within interface is public. It's a contract, There's no implmementation within "interface"
    //Can't have any bodies, variables, etc. Only be methods or properties. Things that can be implemented in other classes
    //Any scripts using the IAction requires it to have the method Cancel()
    public interface IAction
    {
        void Cancel();
    }
}