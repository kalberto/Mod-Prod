using UnityEngine;
using System.Collections;

public class Personagem : MonoBehaviour
{
    // Private properties ALL PRIVATE 
    private float life;
    private static Personagem instance;

    // Setters And Getters (to change the private properties)
    public float Life
    {
        get
        {
            return life;
        }

        set
        {
            life = value;
        }
    }
    public static Personagem Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject auxObj = Object.FindObjectOfType(typeof(Personagem)) as GameObject;
                if (instance != null)
                    instance = auxObj.GetComponent<Personagem>();
                else
                {
                    GameObject go = new GameObject("Personagem");
                    DontDestroyOnLoad(go);
                    go.AddComponent<Personagem>();
                    instance = go.GetComponent<Personagem>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    //Function to ajust the player life
    void AjustLife(float p_value)
    {
        Life = p_value;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Draw on the screen
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), "Vida: " + Life);
    }
}
