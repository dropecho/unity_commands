using System.Collections.Generic;
using UnityEngine;

namespace Dropecho {
  public class CommandProcessor : MonoBehaviour {
    Queue<ICommand> _commands = new Queue<ICommand>();
    ICommand _current = null;

    public void AddCommand(ICommand command) => _commands.Enqueue(command);

    public void Update() {
      if (_current == null || _current.isFinished) {
        while (_commands.Count > 0 && (_current == null || _current.isFinished)) {
          _current = _commands.Dequeue();
          _current?.Execute();
        }
      }
    }
  }
}