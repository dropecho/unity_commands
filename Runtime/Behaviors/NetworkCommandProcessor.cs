using System.Collections.Generic;
using MLAPI;
using UnityEngine;

namespace Dropecho {
  public class NetworkCommandProcessor : NetworkBehaviour {
    Queue<ICommand> _commands = new Queue<ICommand>();
    ICommand _current = null;

    public void AddCommand(ICommand command) => _commands.Enqueue(command);

    public void Update() {
      if (!IsLocalPlayer) {
        return;
      }

      if (_current == null || _current.isFinished) {
        while (_commands.Count > 0 && (_current == null || _current.isFinished)) {
          _current = _commands.Dequeue();
          _current?.Execute();
        }
      }
    }
  }
}