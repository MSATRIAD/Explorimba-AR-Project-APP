// Script 1: ARModelInteractor.cs
// Attach ini ke GameObject model 3D yang ingin diinteraksi
using UnityEngine;

public class ARModelInteractor : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationSpeed = 100f;
    public bool enableXRotation = true;
    public bool enableYRotation = true;
    public bool enableZRotation = false;
    
    [Header("Scale Settings")]
    public bool enableScaling = true;
    public float scaleSpeed = 1f;
    public float minScale = 0.3f;
    public float maxScale = 3f;
    
    [Header("Auto Rotation")]
    public bool autoRotate = false;
    public Vector3 autoRotationSpeed = new Vector3(0, 30f, 0);
    
    [Header("Animation")]
    public bool smoothRotation = true;
    public float rotationSmoothness = 5f;
    
    // Private variables
    private Vector2 lastTouchPosition;
    private bool isInteracting = false;
    private Vector3 initialScale;
    private Quaternion targetRotation;
    private bool isEnabled = false;

    void Start()
    {
        initialScale = transform.localScale;
        targetRotation = transform.rotation;
    }

    void Update()
    {
        if (!isEnabled) return;
        
        HandleInput();
        
        // Auto rotation when not interacting
        if (autoRotate && !isInteracting)
        {
            if (smoothRotation)
            {
                targetRotation *= Quaternion.Euler(autoRotationSpeed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(autoRotationSpeed * Time.deltaTime);
            }
        }
        
        // Smooth rotation
        if (smoothRotation)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothness * Time.deltaTime);
        }
    }

    void HandleInput()
    {
        // Mobile touch input
        if (Input.touchCount == 1)
        {
            HandleSingleTouch();
        }
        else if (Input.touchCount == 2 && enableScaling)
        {
            HandlePinchToZoom();
        }
        else if (Input.touchCount == 0)
        {
            isInteracting = false;
        }
        
        // Desktop mouse input (for testing in editor)
        #if UNITY_EDITOR
        HandleMouseInput();
        #endif
    }

    void HandleSingleTouch()
    {
        Touch touch = Input.GetTouch(0);
        
        if (touch.phase == TouchPhase.Began)
        {
            lastTouchPosition = touch.position;
            isInteracting = true;
        }
        else if (touch.phase == TouchPhase.Moved && isInteracting)
        {
            Vector2 deltaPosition = touch.position - lastTouchPosition;
            ApplyRotation(deltaPosition);
            lastTouchPosition = touch.position;
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            isInteracting = false;
        }
    }

    void HandlePinchToZoom()
    {
        Touch touch1 = Input.GetTouch(0);
        Touch touch2 = Input.GetTouch(1);
        
        float currentDistance = Vector2.Distance(touch1.position, touch2.position);
        Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
        Vector2 touch2PrevPos = touch2.position - touch2.deltaPosition;
        float prevDistance = Vector2.Distance(touch1PrevPos, touch2PrevPos);
        
        float deltaDistance = currentDistance - prevDistance;
        ApplyScaling(deltaDistance * scaleSpeed * Time.deltaTime * 0.01f);
        
        isInteracting = true;
    }

    #if UNITY_EDITOR
    void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastTouchPosition = Input.mousePosition;
            isInteracting = true;
        }
        else if (Input.GetMouseButton(0) && isInteracting)
        {
            Vector2 deltaPosition = (Vector2)Input.mousePosition - lastTouchPosition;
            ApplyRotation(deltaPosition);
            lastTouchPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isInteracting = false;
        }
        
        // Mouse scroll for scaling
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0 && enableScaling)
        {
            ApplyScaling(scroll * scaleSpeed);
        }
    }
    #endif

    void ApplyRotation(Vector2 deltaPosition)
    {
        float rotationY = deltaPosition.x * rotationSpeed * Time.deltaTime;
        float rotationX = -deltaPosition.y * rotationSpeed * Time.deltaTime;
        
        Vector3 rotation = Vector3.zero;
        if (enableYRotation) rotation.y = rotationY;
        if (enableXRotation) rotation.x = rotationX;
        if (enableZRotation) rotation.z = 0; // Modify as needed

        if (smoothRotation)
        {
            targetRotation *= Quaternion.Euler(rotation);
        }
        else
        {
            transform.Rotate(rotation, Space.World);
        }
    }

    void ApplyScaling(float scaleDelta)
    {
        float scaleFactor = 1 + scaleDelta;
        Vector3 newScale = transform.localScale * scaleFactor;
        
        float scaleValue = newScale.magnitude / initialScale.magnitude;
        if (scaleValue >= minScale && scaleValue <= maxScale)
        {
            transform.localScale = newScale;
        }
    }

    // Public methods
    public void EnableInteraction(bool enable)
    {
        isEnabled = enable;
    }

    public void RotateBy(Vector3 eulerAngles)
    {
        if (smoothRotation)
        {
            targetRotation *= Quaternion.Euler(eulerAngles);
        }
        else
        {
            transform.Rotate(eulerAngles);
        }
    }

    public void ResetTransform()
    {
        if (smoothRotation)
        {
            targetRotation = Quaternion.identity;
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
        transform.localScale = initialScale;
    }

    public void SetAutoRotation(bool enable)
    {
        autoRotate = enable;
    }
}