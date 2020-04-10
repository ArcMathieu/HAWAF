using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class GridManager : MonoBehaviour
{
    public int gridSize;
    [HideInInspector] public Button[] buttonList;
    public GameObject buttonPrefab;
    public GameObject Line;
    public bool solved = false;
    public int buttonNumber = 0;
    public string answer;
    int i;

    private List<List<int>> gridSolution;
    public int buttonSize;
    private List<List<int>> proposition;
    private LineRenderer line;
    private List<Vector3> points = new List<Vector3>();

    List<int> edgePropostion;

    void Start()
    {
        solved = false;
        buttonSize = Mathf.Min(Screen.width / (gridSize * gridSize) * 2, Screen.height / (gridSize * gridSize) * 2);
        proposition = new List<List<int>>();
        line = GetComponent<LineRenderer>();
        buttonList = new Button[gridSize * gridSize];
        edgePropostion = new List<int>();
        gridSolution = GridSolutions(answer);
        CreateGrid();
        DrawButtons();
        i = gridSize * gridSize;
        GameManager._instance.buttonNumber = 0;
    }

    void Update()
    {
        //GetProposition(0);
        //DrawLine();

        if (Input.GetKeyDown(KeyCode.R))
        {
            Delete();
            Start();
        }

        if (solved)
        {
            Delete();
            Debug.Log("Success");
            Start();
        }
    }

    void Delete()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
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
    }

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

            Instantiate(Line, transform);

            transform.GetChild(i).GetComponent<DrawLines>().ImageShape(pointA, pointB);
            i++;
            solved = CheckProposition(gridSolution);
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
        proposition.Add(edgePropostion);
        if (proposition.Count != solution.Count)
        {
            return false;
        }

        for (int i = 0; i < proposition.Count; i++)
        {
            bool validEdge = false;
            for (int j = 0; j < solution.Count; j++)
            {
                if (proposition[i][0] == solution[j][0] && proposition[i][1] == solution[j][1] ||
                    proposition[i][0] == solution[j][1] && proposition[i][1] == solution[j][0])
                {
                    validEdge = true;
                }
            }
            if (!validEdge)
            {
                return false;
            }
        }
        return true;
    }

    List<List<int>> GridSolutions(string answer)
    {
        switch (answer)
        {
            case "Triangle":
                return new List<List<int>>() {
                        new List<int>() {0, 1},
                        new List<int>() {1, 2},
                        new List<int>() {0, 4},
                        new List<int>() {4, 8},
                        new List<int>() {5, 8},
                        new List<int>() {2, 5}
                };
            case "T":
                return new List<List<int>>()
                {
                        new List<int>() {0, 1},
                        new List<int>() {1, 2},
                        new List<int>() {1, 4},
                        new List<int>() {4, 7}
                };
            case "Fleche":
                return new List<List<int>>()
                {
                        new List<int>() {1, 3},
                        new List<int>() {3, 6},
                        new List<int>() {6, 4},
                        new List<int>() {4, 8},
                        new List<int>() {8, 5},
                        new List<int>() {5, 1}
                };
            case "Usine":
                return new List<List<int>>()
                {
                        new List<int>() {1, 3},
                        new List<int>() {3, 6},
                        new List<int>() {6, 7},
                        new List<int>() {7, 8},
                        new List<int>() {8, 5},
                        new List<int>() {5, 2},
                        new List<int>() {2, 4},
                        new List<int>() {4, 1}
                };
            case "Truc":
                return new List<List<int>>()
                {
                        new List<int>() {0, 1},
                        new List<int>() {1, 4},
                        new List<int>() {4, 2},
                        new List<int>() {2, 5},
                        new List<int>() {5, 8},
                        new List<int>() {8, 7},
                        new List<int>() {7, 3},
                        new List<int>() {3, 0}
                };
            case "Parapluie":
                return new List<List<int>>()
                {
                        new List<int>() {0, 1},
                        new List<int>() {1, 5},
                        new List<int>() {5, 8},
                        new List<int>() {8, 4},
                        new List<int>() {4, 7},
                        new List<int>() {7, 6},
                        new List<int>() {6, 3},
                        new List<int>() {3, 4},
                        new List<int>() {4, 0},
                };
            case "Spaceship":
                return new List<List<int>>()
                {
                        new List<int>() {0, 1},
                        new List<int>() {1, 2},
                        new List<int>() {2, 7},
                        new List<int>() {7, 5},
                        new List<int>() {5, 8},
                        new List<int>() {7, 3},
                        new List<int>() {3, 6},
                        new List<int>() {0, 7}
                };
            case "Pacman":
                return new List<List<int>>()
                {
                        new List<int>() {2, 4},
                        new List<int>() {4, 6},
                        new List<int>() {6, 7},
                        new List<int>() {7, 8},
                        new List<int>() {8, 5},
                        new List<int>() {5, 6},
                        new List<int>() {6, 3},
                        new List<int>() {3, 1},
                        new List<int>() {1, 2}
                };
            case "V":
                return new List<List<int>>()
                {
                        new List<int>() {2, 7},
                        new List<int>() {7, 3}
                };
            case "M":
                return new List<List<int>>()
                {
                        new List<int>() {0, 4},
                        new List<int>() {4, 2},
                        new List<int>() {2, 5},
                        new List<int>() {5, 8},
                        new List<int>() {8, 7},
                        new List<int>() {7, 6},
                        new List<int>() {6, 3},
                        new List<int>() {3, 0}
                };
            case "Maison":
                return new List<List<int>>()
                {
                        new List<int>() {1, 5},
                        new List<int>() {5, 8},
                        new List<int>() {8, 7},
                        new List<int>() {7, 6},
                        new List<int>() {6, 3},
                        new List<int>() {3, 1},
                        new List<int>() {3, 4},
                        new List<int>() {4, 5}
                };
        }
        return null;
    }
}