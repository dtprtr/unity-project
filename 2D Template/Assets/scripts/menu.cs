using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
   public void Play()
   {
       SceneManager.LoadScene("level_work");
   }
    public void Quit()
    {
         Application.Quit();
        Debug.Log("Quiting...");
    }
}
