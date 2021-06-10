using UnityEngine;
using UnityEngine.AI;

namespace Dropecho {
  public class MoveToCommand : ICommand {
    private CommandReceiver _entity;
    private NavMeshAgent _agent;
    Vector3 _position;

    bool ICommand.isFinished => _agent.remainingDistance <= _agent.stoppingDistance;

    public MoveToCommand(CommandReceiver entity, Vector3 position) {
      _entity = entity;
      _agent = entity.GetComponent<NavMeshAgent>();
      _position = position;
    }

    public void Execute() {
      if (_agent != null) {
        _agent.destination = _position;
      }
    }
  }
}
