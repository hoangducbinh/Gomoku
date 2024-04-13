using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public int row;
    public int column;
    public Board board;
    public Sprite xSprite;
    public Sprite oSprite;
    private Image image;

    private Button button;


    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void Start()
    {
        board = FindAnyObjectByType<Board>();
    }

    public void ChangeImage(string s)
    {
        if (s == "x")
        {
            image.sprite = xSprite;
        }
        else
        {
            image.sprite = oSprite;
        }
    }
    public void OnClick()
    {
        ChangeImage(board.currentTurn);
       if( board.Check(this.row, this.column))
        {
            Debug.Log("Thang !");
        }

        
        if (board.currentTurn == "x")
        {
            board.currentTurn = "o";
        }
        else
        {
            board.currentTurn = "x";
        }

    }
}
