using UnityEngine;

namespace Dropecho {

  public class CrouchCommandGenerator : MonoBehaviour, ICommandGenerator {
    public KeyCode crouchButton = KeyCode.C;

    public ICommand GetGeneratedCommand(CommandReceiver entity) =>
       Input.GetKeyDown(crouchButton) ? new CrouchCommand(entity) : null;
  }
}