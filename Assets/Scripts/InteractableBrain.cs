using UnityEngine;
using UnityEngine.Events;

namespace NewtonVR
{
    public class InteractableBrain : NVRInteractableItem
    {

        public override void BeginInteraction(NVRHand hand)
        {
            if (GetComponent<PlayerBrain>().enabled)
            {
                GetComponent<PlayerBrain>().enabled = false;
            }

            base.BeginInteraction(hand);

            StartingDrag = Rigidbody.drag;
            StartingAngularDrag = Rigidbody.angularDrag;
            Rigidbody.drag = 0;
            Rigidbody.angularDrag = 0.05f;

            PickupTransform = new GameObject(string.Format("[{0}] NVRPickupTransform", this.gameObject.name)).transform;
            PickupTransform.parent = hand.transform;
            PickupTransform.position = this.transform.position;
            PickupTransform.rotation = this.transform.rotation;

            ResetVelocityHistory();

            if (OnBeginInteraction != null)
            {
                OnBeginInteraction.Invoke();
            }
        }

      
    }
}