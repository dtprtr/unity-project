using UnityEngine;
using TMPro;

public class Finishline : MonoBehaviour
{
    public TextMeshProUGUI winText;
    public GameObject player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
 
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Win();
        }
        
    }
    private void Win()
    {
        Destroy(player);
        winText.gameObject.SetActive(true);
        Debug.Log("You Win!");
    }
}
