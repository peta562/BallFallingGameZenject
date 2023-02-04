namespace Core.Services.ProgressController {
    public interface IProgressController {
        bool CanStartNextLevel();
        void StartNextLevel();
    }
}