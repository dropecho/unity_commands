using UnityEngine;
using UnityEngine.AI;

namespace Dropecho {
  public class MoveCommand : ICommand {
    CommandReceiver _entity;
    Vector3 _direction;
    bool ICommand.isFinished => true;

    public MoveCommand(CommandReceiver entity, Vector3 direction) {
      _entity = entity;
      _direction = direction;
    }

    public void Execute() {
      _entity.GetComponent<ICharacterController>().Move(_direction);
      if (_entity.gameObject.HasComponent<NavMeshAgent>()) {
        _entity.GetComponent<NavMeshAgent>().nextPosition = _entity.transform.position;
        _entity.GetComponent<NavMeshAgent>().destination = _entity.transform.position;
      }
    }
  }
}