using UnityEngine;

namespace Dropecho {

  public class WalkCommandGenerator : MonoBehaviour, ICommandGenerator {
    public KeyCode walkButton = KeyCode.LeftShift;

    public ICommand GetGeneratedCommand(CommandReceiver entity) {
      if (Input.GetKeyDown(walkButton)) {
        return new WalkCommand(entity, true);
      }

      if (Input.GetKeyUp(walkButton)) {
        return new WalkCommand(entity, false);
      }

      return null;
    }
  }
}