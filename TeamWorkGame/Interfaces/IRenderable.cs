namespace TeamWorkGame.Interfaces
{
    using TeamWorkGame.Data;
    
    public interface IRenderable
    {
        Position GetTopLeft();

        char[,] GetImage();
    }
}