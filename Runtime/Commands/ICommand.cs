namespace Dropecho {
  public interface ICommand {
    void Execute();
    bool isFinished { get; }
  }
}