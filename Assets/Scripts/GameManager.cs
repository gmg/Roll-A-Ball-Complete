using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private int count;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log("Too many Game Managers. Cleaning up.");
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }
    private void OnEnable()
    {
        PickUp.OnPickUpCollected += PickUpCollected;
    }
    private void OnDisable()
    {
        PickUp.OnPickUpCollected -= PickUpCollected;
    }

    public void PickUpCollected()
    {
        count = count + 1;
        SetCountText();
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }
}
