using UnityEngine;

namespace Dropecho {

  public class CommandReceiver : MonoBehaviour {
    CommandProcessor _commandProcessor;

    void Awake() {
      _commandProcessor = GetComponent<CommandProcessor>();
    }

    void Update() {
      var generators = GetComponentsInChildren<ICommandGenerator>();

      foreach (var gen in generators) {
        var command = gen.GetGeneratedCommand(this);
        if (command != null) {
          _commandProcessor.AddCommand(command);
        }
      }
    }
  }
}