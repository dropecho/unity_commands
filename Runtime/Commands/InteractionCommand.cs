namespace Dropecho
{
  public class InteractionCommand : ICommand {
    Interactor _interactor;
    private readonly Interactable _interactable;

    public bool isFinished => true;

    public InteractionCommand(Interactor interactor, Interactable interactable) {
      _interactor = interactor;
      _interactable = interactable;
    }
    public void Execute() => _interactable.Interact(_interactor);
  }
}
