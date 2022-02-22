using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float zoomScale;
    [SerializeField][Range(1, 5)] private float zoomLimitMin, zoomLinitMax;
    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        MoveCamera();
        //Scroll();
    }

    private void MoveCamera()
    {
        //ClampCamera();
    }

    private Vector3 ClampCamera(Vector3 target)
    {
        return new Vector3();
    }
    private void Scroll()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            cam.orthographicSize = Mathf.Clamp
                (cam.orthographicSize + (zoomScale * -Input.mouseScrollDelta.y), zoomLimitMin, zoomLinitMax);
        }

        //cam.transform.position = ClampCamera(cam.transform.position);
    }
}
