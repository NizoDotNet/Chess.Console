using Chess.Helpers;
using Chess.Main.GameFactory.Games;

namespace Chess.Main.GameFactory.Factories;

public class StandartGameFactory : IGameFactory
{
    private readonly IRenderer renderer;

    public StandartGameFactory(IRenderer renderer)
    {
        this.renderer = renderer;
    }
    public IGame CreateGame() => new StandartChess(renderer);
}
