namespace Dropecho
{
  public class WalkCommand : ICommand {
    CommandReceiver _entity;
    private readonly bool _walk;
    public bool isFinished => true;

    public WalkCommand(CommandReceiver entity, bool walk) {
      _entity = entity;
      _walk = walk;
    }
    public void Execute() => _entity.GetComponent<ICharacterController>().ClampMovement(_walk ? 0.5f : 2);
  }
}
