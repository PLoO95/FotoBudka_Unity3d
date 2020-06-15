using UnityEngine;

public class CameraMotionManager : MonoBehaviour
{
    private Vector2 mouseMotionStartPoint;
    private Vector2 mouseRotationStartPoint;

    public GameObject camera;

    private float cameraMotionSpeed = 10f;
    private float cameraRotationSpeed = 10f;
    private float cameraZoomSpeed = 1500f;



    void Start()
    {
        if (camera == null)
            camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private Vector2 checkPosition(Vector2 start) {
        Vector2 v;
        v.x = start.x - Input.mousePosition.x;
        v.y = start.y - Input.mousePosition.y;
        return v;
    }

    private void mouseMotion() {
        if (mouseMotionStartPoint.x - 5 > Input.mousePosition.x || mouseMotionStartPoint.x + 5 < Input.mousePosition.x)
        {
            camera.transform.Translate(Vector3.right * checkPosition(mouseMotionStartPoint).x * Time.deltaTime * cameraMotionSpeed);
            mouseMotionStartPoint.x = Input.mousePosition.x;
        }
        if (mouseMotionStartPoint.y - 5 > Input.mousePosition.y || mouseMotionStartPoint.y + 5 < Input.mousePosition.y)
        {
            camera.transform.Translate(Vector3.up * checkPosition(mouseMotionStartPoint).y * Time.deltaTime * cameraMotionSpeed);
            mouseMotionStartPoint.y = Input.mousePosition.y;
        }
    }

    private void mouseRotation()
    {
        if (mouseRotationStartPoint.x - 5 > Input.mousePosition.x || mouseRotationStartPoint.x + 5 < Input.mousePosition.x)
        {
            //camera.transform.Rotate(0,(-checkPosition(mouseRotationStartPoint).x + camera.transform.rotation.x) * Time.deltaTime * cameraRotationSpeed, 0);
            mouseRotationStartPoint.x = Input.mousePosition.x;
        }
        if (mouseRotationStartPoint.y - 5 > Input.mousePosition.y || mouseRotationStartPoint.y + 5 < Input.mousePosition.y)
        {
            camera.transform.Rotate((checkPosition(mouseRotationStartPoint).y + camera.transform.rotation.y) * Time.deltaTime * cameraRotationSpeed, 0, 0);
            mouseRotationStartPoint.y = Input.mousePosition.y;
        }
    }
    void Update()
    {

        camera.transform.Translate(Vector3.forward*Time.deltaTime * Input.GetAxis("Mouse ScrollWheel") * cameraZoomSpeed);
        

        if (Input.GetKeyDown(KeyCode.Mouse2))
            mouseMotionStartPoint = Input.mousePosition;

        if(Input.GetKey(KeyCode.Mouse2))
            mouseMotion();

        if (Input.GetKeyDown(KeyCode.Mouse1))
            mouseRotationStartPoint = Input.mousePosition;

        if (Input.GetKey(KeyCode.Mouse1))
            mouseRotation();


    }
}
