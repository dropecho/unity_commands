namespace Dropecho
{
  public class CrouchCommand : ICommand {
    CommandReceiver _entity;
    bool ICommand.isFinished => true;
    public CrouchCommand(CommandReceiver entity) => _entity = entity;
    public void Execute() => _entity.GetComponent<ICharacterController>().Crouch();
  }
}
