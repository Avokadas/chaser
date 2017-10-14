namespace Chaser.Game
{
    public interface IGameStateBuilder
    { 
        void AddChaser();
        void AddPlayer();
        void AddTerrainObjects();
        GameState GetGameState();
    }
}