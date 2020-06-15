using UnityEngine;
using System.IO;
using UnityEditor;
using System.Collections;

public class ScreenShoot : MonoBehaviour
{

    private static string pathToSavePhoto = Application.streamingAssetsPath + "/Output/";

    private int numberOfPhotos = 0;

    public Canvas uiCanvas;

    private string pathChecker() {
        string[] dirs = Directory.GetFiles(pathToSavePhoto, "*.png");
        Debug.Log("The number of files starting with .prefab is " + dirs.Length);
        foreach (string dir in dirs)
        {
            numberOfPhotos++;
        }
        return pathToSavePhoto + (numberOfPhotos+1).ToString() + ".png";
    }

    IEnumerator waitUI(float t)
    {
        uiCanvas.enabled = false;
        yield return new WaitForSeconds(t);
        uiCanvas.enabled = true;
    }

    public bool takePhoto() {
        string path = pathChecker();

        StartCoroutine(waitUI(0.25f));

        ScreenCapture.CaptureScreenshot(path);

        if (Directory.Exists(path))
                return true;

        return false;
    }


    private void Start()
    {
        if(uiCanvas == null)
            uiCanvas = GameObject.FindGameObjectWithTag("UI").GetComponent<Canvas>();

        if (!Directory.Exists(pathToSavePhoto))
        {
            DirectoryInfo dirInput = Directory.CreateDirectory(pathToSavePhoto);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            takePhoto();
        }
    }

}
