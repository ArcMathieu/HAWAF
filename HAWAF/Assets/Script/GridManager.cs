using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GridManager : MonoBehaviour
{
    public int gridSize;
    public Button[] buttonList;
    public GameObject buttonPrefab;
    public GameObject Line;
    public bool solved = false;
    public int buttonNumber = 0;
    int i;

    private List<List<int>> gridSolution;
    public int buttonSize;
    private List<List<int>> gridEdges;
    private List<List<int>> proposition;
    private LineRenderer line;
    private List<Vector3> points = new List<Vector3>();

    List<int> edgePropostion;

    void Start()
    {
        buttonSize = Mathf.Min(Screen.width / gridSize, Screen.height / gridSize);
        proposition = new List<List<int>>();
        line = GetComponent<LineRenderer>();
        buttonList = new Button[gridSize * gridSize];
        gridEdges = new List<List<int>>();
        edgePropostion = new List<int>();
        CreateGrid();
        DrawButtons();
        i = gridSize * gridSize;
    }

    void Update()
    {
        //GetProposition(0);
        //DrawLine();
        solved = CheckProposition(gridSolution);
        if (solved)
        {
            Start();
        }
    }

    void CreateGrid()
    {
        //Grid_Shape
        //1  2
        //3  4
        for (int i = 0; i < gridSize * gridSize; i++)
        {
            buttonList[i] = buttonPrefab.GetComponent<Button>();
            //Instantiate(buttonList[i]);
            buttonList[i].GetComponent<RectTransform>().sizeDelta = new Vector2(buttonSize, buttonSize);
        }

        for (int i = 0; i < gridSize * gridSize - 1; i++)
        {
            for (int j = i + 1; j < gridSize * gridSize; j++)
            {
                //gridEdges[i * gridSize + (j - i - 1)] = new List<int> { i, j };
                gridEdges.Add(new List<int> { i, j });
            }
        }
    }

    /*void GetProposition()
    {
        for (int i = 0; i < gridSize * gridSize; i++)
        {
            buttonList[i].onClick.AddListener(() =>
               {
                   Debug.Log("Je suis dedans con " + i);
                   if (edgePropostion.Count >= 2)
                   {
                       Debug.Log("Sa fait 2");
                       edgePropostion = new List<int> { i };
                   }
                   else if (edgePropostion.Count == 1)
                   {
                       Debug.Log("Sa fait 1");
                       edgePropostion.Add(i);
                   }
                   else if (edgePropostion.Count == 0)
                   {
                       Debug.Log("Sa fait 0");  
                       edgePropostion.Add(i);
                   }
               });
        }
    }*/

    public void GetProposition(int elNumber)
    {
        if (edgePropostion.Count >= 2)
        {
            edgePropostion = new List<int> { elNumber };
        }
        else if (edgePropostion.Count == 1)
        {
            edgePropostion.Add(elNumber);
        }
        else if (edgePropostion.Count == 0)
        {
            edgePropostion.Add(elNumber);
        }
    }

    public void DrawLine(int elButton)
    {
        if (edgePropostion.Count == 2)
        {
            int xPosA = edgePropostion[0] % gridSize - (gridSize - 1) / 2;
            int yPosA = -edgePropostion[0] / gridSize + (gridSize - 1) / 2;
            int xPosB = edgePropostion[1] % gridSize - (gridSize - 1) / 2;
            int yPosB = -edgePropostion[1] / gridSize + (gridSize - 1) / 2;

            Vector3 pointA = new Vector3(xPosA, yPosA, 0);
            Vector3 pointB = new Vector3(xPosB, yPosB, 0);

            Debug.Log("Point A : " + pointA + " Point B : " + pointB);

            Instantiate(Line, transform);

            transform.GetChild(i).GetComponent<DrawLines>().ImageShape(pointA, pointB);
            i++;

        }

    }

    void DrawButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            int xPos = i % gridSize;
            int yPos = i / gridSize;

            Vector3 position = new Vector3(buttonSize * (xPos - (gridSize - 1) / 2), -(buttonSize * (yPos - (gridSize - 1) / 2)), 0);
            transform.parent.position = new Vector3(0, 0, 0);
            Instantiate(buttonList[i], position, Quaternion.identity, transform);
            //buttonList[i].GetComponent<RectTransform>().position = position;
        }
    }

    bool CheckProposition(List<List<int>> solution)
    {
        if (edgePropostion.Count == 2)
        {
            proposition.Add(edgePropostion);
        }
        if (proposition.Equals(solution))
        {
            return true;
        } else
        {
            return false;
        }
    }
}
