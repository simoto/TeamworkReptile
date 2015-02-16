namespace TeamWorkGame.Interfaces
{
    using TeamWorkGame.Data;
    
    public interface IRenderable
    {
        MatrixCoords GetTopLeft();

        char[,] GetImage();
    }
}