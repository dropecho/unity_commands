using UnityEngine;

namespace Dropecho {
  public class ClickMoveToCommandGenerator : MonoBehaviour, ICommandGenerator {
    public ICommand GetGeneratedCommand(CommandReceiver entity) {
      if (Input.GetMouseButtonDown(0)) {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)) {
          return new MoveToCommand(entity, hit.point);
        }
      }
      return null;
    }
  }
}