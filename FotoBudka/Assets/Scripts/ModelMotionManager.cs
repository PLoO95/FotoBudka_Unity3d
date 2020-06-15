using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMotionManager : MonoBehaviour
{
    private Vector2 mouseStartPoint;

    private Vector3 modelStartParameter;

    private bool isInRotationMode = false;

    private GameObject model;

    private Vector2  checkPosition() {
        Vector2 v;
        v.x = mouseStartPoint.x - Input.mousePosition.x;
        v.y = mouseStartPoint.y - Input.mousePosition.y;
        return v;
    }
    private void rotateModel() {
        if (mouseStartPoint.x - 5 > Input.mousePosition.x || mouseStartPoint.x + 5 < Input.mousePosition.x)
        {
            model.transform.Rotate(0, checkPosition().x + model.transform.rotation.x, 0);
            mouseStartPoint.x = Input.mousePosition.x;
        }
    }

    private void Update()
    {
        if (model == null)
            model = GameObject.FindGameObjectWithTag("Model");

        if (Input.GetKeyDown(KeyCode.Mouse0))
            mouseStartPoint = Input.mousePosition;

        if (Input.GetKeyDown(KeyCode.Mouse0))
            isInRotationMode = true;
        if (Input.GetKeyUp(KeyCode.Mouse0))
            isInRotationMode = false;

        if (isInRotationMode)
            rotateModel();
    }

}
