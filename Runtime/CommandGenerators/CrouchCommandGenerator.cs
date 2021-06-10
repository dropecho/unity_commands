using UnityEngine;

namespace Dropecho {
  public class CrouchCommand : ICommand {
    CommandReceiver _entity;
    bool ICommand.isFinished => true;
    public CrouchCommand(CommandReceiver entity) => _entity = entity;
    public void Execute() => _entity.GetComponent<ICharacterController>().Crouch();
  }

  public class CrouchCommandGenerator : MonoBehaviour, ICommandGenerator {
    public KeyCode crouchButton = KeyCode.C;

    public ICommand GetGeneratedCommand(CommandReceiver entity) =>
       Input.GetKeyDown(crouchButton) ? new CrouchCommand(entity) : null;
  }
}