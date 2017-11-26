namespace Chaser.Game
{
    public interface IGameStateBuilder
    { 
        void AddChaser();
        void InitScore();
        void AddPlayer();
        void AddGameMap();
        void SetStartGameState();
        GameState GetGameState();
    }
}