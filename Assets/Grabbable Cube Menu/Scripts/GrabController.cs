using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class GrabController : MonoBehaviour
{
    [SerializeField] private bool allowActivateWithoutGrab = false;
    [SerializeField] private XRGrabInteractable _xrGrabInteractable;
    public XRGrabInteractable xrGrabInteractable
    {
        get
        {
            // If null, we look for it in the gameObject and its parent hierarchy
            if (_xrGrabInteractable == null)
                _xrGrabInteractable = GetComponentInParent<XRGrabInteractable>();

            // If still null, we create it and setup its Rigidbody
            if (_xrGrabInteractable == null)
            {
                gameObject.AddComponent<XRGrabInteractable>();
                var rb = gameObject.GetComponent<Rigidbody>();
                if (rb == null)
                {
                    rb = gameObject.AddComponent<Rigidbody>();
                }
                rb.isKinematic = true;
                rb.useGravity = false;
            }

            return _xrGrabInteractable;
        }
    }

    private IXRSelectInteractor grabInteractor;
    private Renderer objRenderer;
    private Color originalColor;

    private void Start()
    {
        objRenderer = GetComponent<Renderer>();
        originalColor = objRenderer.material.color;
    }

    public void OnActivate(ActivateEventArgs args)
    {
        if (args.interactorObject == grabInteractor)
            return;

        if (grabInteractor == null && !allowActivateWithoutGrab)
            return;

        if (args.interactorObject is NearFarInteractor nearFarInteractor)
        {
            List<Collider> colliderTargets = new();
            List<RaycastHit> raycastHits = new();
            if (nearFarInteractor.farInteractionCaster.TryGetColliderTargets(xrGrabInteractable.interactionManager, colliderTargets, raycastHits))
            {
                if (colliderTargets.Count > 0)
                {
                    var cubeFaceController = colliderTargets[0].GetComponent<CubeFaceController>();
                    if (cubeFaceController != null)
                        cubeFaceController.Activate();
                }
            }
        }
        if (args.interactorObject is XRGazeInteractor xRGazeInteractor)
        {
            List<Collider> colliderTargets = new();
            List<RaycastHit> raycastHits = new();
            if (xRGazeInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
            {
                var cubeFaceController = hit.collider.GetComponent<CubeFaceController>();
                if (cubeFaceController != null)
                    cubeFaceController.Activate();
            }
        }
    }

    public void OnHoverEnter(HoverEnterEventArgs args)
    {
        objRenderer.material.color = Color.yellow; // Highlight-färg

        if (args.interactorObject is XRGazeInteractor xRGazeInteractor)
        {
            List<Collider> colliderTargets = new();
            List<RaycastHit> raycastHits = new();
            if (xRGazeInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
            {
                hit.collider.gameObject.GetComponent<Renderer>().enabled = false;
                var cubeFaceController = hit.collider.GetComponent<CubeFaceController>();
                if (cubeFaceController != null)
                    cubeFaceController.Activate();
            }
        }
    }

    public void OnHoverExit(HoverExitEventArgs args)
    {
        objRenderer.material.color = originalColor; // Återställ till originalfärgen
        if (args.interactorObject is XRGazeInteractor xRGazeInteractor)
        {
            List<Collider> colliderTargets = new();
            List<RaycastHit> raycastHits = new();
            if (xRGazeInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
            {
                hit.collider.gameObject.GetComponent<Renderer>().enabled = true;
                var cubeFaceController = hit.collider.GetComponent<CubeFaceController>();
                if (cubeFaceController != null)
                    cubeFaceController.Activate();
            }
        }
    }

    public void OnGrab(SelectEnterEventArgs args)
    {
        grabInteractor = args.interactorObject;
    }

    public void OnRelease(SelectExitEventArgs args)
    {
        if (grabInteractor != args.interactorObject)
            return;

        grabInteractor = null;
    }

    private void OnEnable()
    {
        xrGrabInteractable.activated.AddListener(OnActivate);
        xrGrabInteractable.selectEntered.AddListener(OnGrab);
        xrGrabInteractable.selectExited.AddListener(OnRelease);
        xrGrabInteractable.firstHoverEntered.AddListener(OnHoverEnter);
        xrGrabInteractable.lastHoverExited.AddListener(OnHoverExit);
    }

    private void OnDisable()
    {
        xrGrabInteractable.activated.RemoveListener(OnActivate);
        xrGrabInteractable.selectEntered.RemoveListener(OnGrab);
        xrGrabInteractable.selectExited.RemoveListener(OnRelease);
        xrGrabInteractable.firstHoverEntered.RemoveListener(OnHoverEnter);
        xrGrabInteractable.lastHoverExited.RemoveListener(OnHoverExit);
    }
}


/*using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class GrabController : MonoBehaviour
{
    [SerializeField] private bool allowActivateWithoutGrab = false;
    [SerializeField] private XRGrabInteractable _xrGrabInteractable;
    public XRGrabInteractable xrGrabInteractable
    {
        get
        {
            // If null, we look for it in the gameObject and its parent hierarchy
            if (_xrGrabInteractable == null)
                _xrGrabInteractable = GetComponentInParent<XRGrabInteractable>();

            // If still null, we create it and setup its Rigidbody
            if (_xrGrabInteractable == null)
            {
                gameObject.AddComponent<XRGrabInteractable>();
                var rb = gameObject.GetComponent<Rigidbody>();
                if (rb == null)
                {
                    rb = gameObject.AddComponent<Rigidbody>();
                }
                rb.isKinematic = true;
                rb.useGravity = false;
            }

            return _xrGrabInteractable;
        }
    }

    private IXRSelectInteractor grabInteractor;

    public void OnActivate(ActivateEventArgs args)
    {
        if (args.interactorObject == grabInteractor)
            return;
        
        if (grabInteractor == null && !allowActivateWithoutGrab)
            return;

        if (args.interactorObject is NearFarInteractor nearFarInteractor)
        {
            List<Collider> colliderTargets = new();
            List<RaycastHit> raycastHits = new();
            if (nearFarInteractor.farInteractionCaster.TryGetColliderTargets(xrGrabInteractable.interactionManager, colliderTargets, raycastHits))
            {
                if (colliderTargets.Count > 0)
                {
                    var cubeFaceController = colliderTargets[0].GetComponent<CubeFaceController>();
                    if (cubeFaceController != null)
                        cubeFaceController.Activate();
                }
            }
        }
    }

    public void OnGrab(SelectEnterEventArgs args)
    {
        grabInteractor = args.interactorObject;
    }

    public void OnRelease(SelectExitEventArgs args)
    {
        if (grabInteractor != args.interactorObject)
            return;
        
        grabInteractor = null;
    }

    private void OnEnable()
    {
        xrGrabInteractable.activated.AddListener(OnActivate);
        xrGrabInteractable.selectEntered.AddListener(OnGrab);
        xrGrabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnDisable()
    {
        xrGrabInteractable.activated.RemoveListener(OnActivate);
        xrGrabInteractable.selectEntered.RemoveListener(OnGrab);
        xrGrabInteractable.selectExited.RemoveListener(OnRelease);
    }
}
*/