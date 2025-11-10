using Chess.Main.GameFactory;

namespace Chess.WebClient.Application;

public class BlazorGameFactory : IGameFactory
{
    private readonly Action _onRender;

    public BlazorGameFactory(Action onRender)
    {
        _onRender = onRender;
    }

    public IGame CreateGame()
    {
        var renderer = new BlazorRenderer(_onRender);
        return new BlazorGame(renderer);
    }
}
