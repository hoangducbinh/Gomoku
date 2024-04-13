using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour

{
    
    public GameObject cellPrefab;
    public string currentTurn = "x";
    
    private string[,] matrix;
   

    public Transform board;
    public GridLayoutGroup gridLayout;
    public int boardSize;
    public void Awake()
    {
        
    }
    public void Start()
    {
        matrix = new string[boardSize + 1, boardSize + 1];
        gridLayout.constraintCount = boardSize;   
        CreateBoard();
    }

    private  void CreateBoard()
    {
        for (int i = 1; i <= boardSize; i++)
        {
            for(int j = 1; j <= boardSize; j++)
            {
                GameObject cellTransform = Instantiate(cellPrefab, board);
                Cell cell = cellTransform.GetComponent<Cell>();
                cell.row = i;
                cell.column = j;
                matrix[i, j] = "";
            }
        }
    }
    public bool Check(int row, int column)
    {
        matrix[row, column] = currentTurn;
        bool result = false;
        int count = 0;
        // check hang doc
        for (int i = row - 1; i >=1; i--)
        {
            if (matrix[i, column] == currentTurn)
            {
                count ++;
            }
            else
            {
                break;
            }
        }
        for (int i = row + 1; i <= boardSize; i++)
        {
            if (matrix[i, column] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        
        if (count + 1 >= 5)
        {
            result = true;

        }


        // check hang ngang
        count = 0;
        for (int i = column - 1; i >= 1; i--) //trai
        {
            if (matrix[row , i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        for (int i = column + 1; i <= boardSize; i++) // phai
        {
            if (matrix[row ,i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }

        if (count + 1 >= 5)
        {
            result = true;

        }

        // cheo 1
        count = 0;
        for (int i = column - 1; i >= 1; i--) //cheo tren trai
        {
            if (matrix[row - (column -i), i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        for (int i = column + 1; i <= boardSize; i++) //cheo duoi phai
        {
            if (matrix[row + (column - i), i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        if (count + 1 >= 5)
        {
            result = true;

        }


        // cheo 2
        count = 0;
        for (int i = column + 1; i <= boardSize; i++) //cheo tren phai
        {
            if (matrix[row - (column - i), i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        for (int i = column - 1; i >= 1; i--) //cheo duoi trai
        {
            if (matrix[row + (column - i), i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        if (count + 1 >= 5)
        {
            result = true;

        }



        return result;

        

    }
}
