using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI points_txt;
    public int points_number = 0;

    public int playerLife = 3;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        points_txt.text = points_number.ToString(); // testar depois se fica melhor aqui!
    }

    public void PointSystem(int point)
    {
        points_number += point;
    }

    }
