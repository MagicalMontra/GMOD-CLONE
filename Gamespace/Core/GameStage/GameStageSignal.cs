namespace Gamespace.Core.GameStage
{
    public class GameStageSignal
    {
        public Stage gameStage => _gameStage;
        private Stage _gameStage;

        public GameStageSignal(Stage gameStage)
        {
            _gameStage = gameStage;
        }
    }

    public interface IGameStageEnableSignal
    {
        string id { get; }
    }

    public interface IGameStageDisableSignal
    {
        string id { get; }
    }

    public class GameStageEnableSignal : IGameStageEnableSignal
    {
        public string id => _id;
        private string _id;

        public GameStageEnableSignal(string id)
        {
            _id = id;
        }
    }
    public class GameStageDisableSignal : IGameStageDisableSignal
    {
        public string id => _id;
        private string _id;

        public GameStageDisableSignal(string id)
        {
            _id = id;
        }
    }
}