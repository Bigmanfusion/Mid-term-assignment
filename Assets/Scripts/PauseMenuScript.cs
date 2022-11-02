using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject menu;
    public TextMeshProUGUI testingText;
    public KeyCode testingKey; 

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(testingKey))
       {
            testingText.text = "Down";
            //testingText.color = Color.red;
            //Debug.Log("Down");

       }
       else if (Input.GetKey(testingKey))
       {
            testingText.text = "Hold";
           //testingText.color = Color.magenta;
            //Debug.Log("Hold");
        }
       else if (Input.GetKeyUp(testingKey))
       {
            testingText.text = "Up";
            //testingText.color = Color.yellow;
           // testingText.color = new Color(0.6f,0.3f, 0.
            //Debug.Log("Up");
        }
       else
       {
       
       }
       if (Input.GetButtonDown("Cancel"))
       {
            //Will only open menu
            //menu.SetActive(true);

            //Will open menu if it's close
          menu.SetActive(!menu.activeInHierarchy);
    
    
            //Nothing here
            //This would be every frame the key 
       }
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
