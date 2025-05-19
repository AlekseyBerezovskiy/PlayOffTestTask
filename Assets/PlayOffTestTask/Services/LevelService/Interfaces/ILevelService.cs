using PlayOffTestTask.Models;

namespace PlayOffTestTask.Services.LevelService
{
    public interface ILevelService
    {
        LevelModel GenerateNextLevel();
    }
}