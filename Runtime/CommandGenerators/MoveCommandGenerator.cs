using UnityEngine;

public enum MovementMode {
  Local,
  Camera
}

namespace Dropecho {
  public class MoveCommandGenerator : MonoBehaviour, ICommandGenerator {
    public string forwardAxis = "Vertical";
    public string sideAxis = "Horizontal";
    // public KeyCode walkButton = KeyCode.LeftShift;
    public MovementMode mode = MovementMode.Local;

    public ICommand GetGeneratedCommand(CommandReceiver entity) {
      // var walk = Input.GetKey(walkButton) ? 0.5f : 1;
      var forward = Input.GetAxis(forwardAxis);
      var sideways = Input.GetAxis(sideAxis);

      Vector3 movement = Vector3.zero;
      switch (mode) {
        case MovementMode.Local: movement = LocalMovement(forward, sideways); break;
        case MovementMode.Camera: movement = CameraMovement(forward, sideways); break;
      }

      // return Math.abs(forward) < 0.1 && Math.abs(sideways) < 0.1 ? null : new MoveCommand(entity, movement * walk);
      return Mathf.Abs(forward) < 0.1 && Mathf.Abs(sideways) < 0.1 ? null : new MoveCommand(entity, movement);
    }

    Vector3 LocalMovement(float forward, float sideways) {
      return transform.TransformDirection(new Vector3(sideways, 0, forward));
    }

    Vector3 CameraMovement(float forward, float sideways) {
      var movement = Vector3.zero;
      movement += sideways * Camera.main.transform.right;
      movement += forward * Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized;
      return movement;
    }
  }
}