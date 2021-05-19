namespace FestivalManager.App.Factory
{
    public interface IFactory<out T>
    { 
        T Create();
    }
}
