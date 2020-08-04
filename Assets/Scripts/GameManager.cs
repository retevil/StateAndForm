using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager GM;

    public KeyCode forward { get; set; }
    public KeyCode backward { get; set; }
    public KeyCode left { get; set; }
    public KeyCode right { get; set; }
    public KeyCode jump { get; set; }

    private void Awake()
    {
        
        this.initializeGM();
        this.setKeys();


     

    }

    private void initializeGM()
    {

        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);

            GM = this;
        }
        else if (GM != this)
        {
            Destroy(gameObject);
        }
    }

    private void setKeys()
    {
     /*Assign each keycode when the game starts.
        * Loads data from PlayerPrefs so if a user quits the game,
        * their bindings are loaded next time. Default values
        * are assigned to each Keycode via the second parameter
        * of the GetString() function
        */
        this.jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space"));
        this.forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardKey", "W"));
        this.backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardKey", "S"));
        this.left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
        this.right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
