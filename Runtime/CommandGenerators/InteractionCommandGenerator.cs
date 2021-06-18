using UnityEngine;

namespace Dropecho {

  public class InteractionCommandGenerator : MonoBehaviour, ICommandGenerator {
    [SerializeField] KeyCode _button = KeyCode.F;
    [SerializeField] float _interactionDistance;
    [SerializeField] Vector3 _rayOrigin = new Vector3(0, 0.5f, 0);
    [SerializeField] LayerMask _interactionMask;

    private RaycastHit _hit;
    private Interactor _interactor;

    public ICommand GetGeneratedCommand(CommandReceiver entity) {

      if (_interactor == null) {
        _interactor = entity.GetComponent<Interactor>();
      }

      // _hit.GetComponent<Interactable>()?.DeFocus();

      if (Physics.Raycast(GetInteractionRay(), out _hit, _interactionDistance, _interactionMask)) {
        var interactable = _hit.GetComponent<Interactable>();
        // interactable.Focus(_interactor);

        if (Input.GetKeyDown(_button) && interactable?.CheckInteraction(_interactor) == true) {
          return new InteractionCommand(_interactor, interactable);
        }
      }

      return null;
    }

    Ray GetInteractionRay() => new Ray(transform.position + _rayOrigin, transform.forward);

    void OnDrawGizmosSelected() {
      var ray = GetInteractionRay();
      Gizmos.DrawRay(ray.origin, ray.direction * _interactionDistance);
    }
  }
}