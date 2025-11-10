using Chess.Main.GameFactory.Games;

namespace Chess.Main.GameFactory.Factories;

public class NoRenderFactory : IGameFactory
{
    public IGame CreateGame()
    {
        return new NoRenderer();
    }
}
