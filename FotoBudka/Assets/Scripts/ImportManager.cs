using UnityEngine;
using UnityEngine.UI;

public class ImportManager : MonoBehaviour
{
    private GameObject[] models;
    private Object[] objectToConvert;
    private GameObject actModelObject;

    private int actNumberOfModels = 0;
    private int actModelNumber = 0;

    public Text actModelTitleText;

    public int getActNumrOfModels()
    {
        return actNumberOfModels;
    }

    public void refreshModelList()
    {
        int numbOfModels = 0;

        objectToConvert = Resources.LoadAll("Input/", typeof(GameObject));
        models = new GameObject[objectToConvert.Length];

        foreach (GameObject obj in objectToConvert) 
        {
            models[numbOfModels] = obj;
            Debug.Log(obj.name.ToString());
            numbOfModels++;
        }
        actNumberOfModels = numbOfModels;

        actualizeModel();
    }


    public bool actualizeModel()
    {
        if (actModelObject != null)
            Destroy(actModelObject);
        actModelObject = Instantiate(Resources.Load("Input/" + models[actModelNumber].name.ToString(), typeof(GameObject))) as GameObject;
        actModelTitleText.text = models[actModelNumber].name.ToString();
        actModelObject.tag = "Model";
        return true;
    }

    public bool nextModel()
    {
        if (actNumberOfModels - 1 > actModelNumber)
            actModelNumber++;
        else
            actModelNumber = 0;

        if (actualizeModel())
            return true;

        return false;
    }
    public bool previousModel()
    {
        if (0 <= actModelNumber - 1)
            actModelNumber--;
        else
            actModelNumber = actNumberOfModels - 1;

        if (actualizeModel())
            return true;

        return false;
    }
    bool chooseModel(int number)
    {
        if (actModelNumber < actNumberOfModels - 1 && actModelNumber >= 0)
        {
            actModelNumber = number;
            if (actualizeModel())
                return true;
            else
                return false;
        }

        return false;
    }

    private void Start()
    {
        if (actModelTitleText == null)
            actModelTitleText = GameObject.FindGameObjectWithTag("Title").GetComponent<Text>();
        refreshModelList();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            nextModel();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            previousModel();

    }
}
