using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public TextMeshProUGUI level1;
    public TextMeshProUGUI level2;
    public TextMeshProUGUI level3;
    public Image highlight;

    private int pos = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pos = (pos + 1) % 3;


            if (pos == 0)
            {
                // Get the current position of the TextMeshPro object
                Vector3 textPos = level1.transform.position;

                // Set the image's x position to the text's x position while keeping the y value of the image the same
                highlight.rectTransform.position = new Vector3(textPos.x, highlight.rectTransform.position.y, highlight.rectTransform.position.z);
            }
            if (pos == 1)
            {
                // Get the current position of the TextMeshPro object
                Vector3 textPos = level2.transform.position;

                // Set the image's x position to the text's x position while keeping the y value of the image the same
                highlight.rectTransform.position = new Vector3(textPos.x, highlight.rectTransform.position.y, highlight.rectTransform.position.z);
            }
            if (pos == 2)
            {
                // Get the current position of the TextMeshPro object
                Vector3 textPos = level3.transform.position;

                // Set the image's x position to the text's x position while keeping the y value of the image the same
                highlight.rectTransform.position = new Vector3(textPos.x, highlight.rectTransform.position.y, highlight.rectTransform.position.z);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (pos == 0)
            {
                SceneManager.LoadScene(1);
            }

            if (pos == 1)
            {
                SceneManager.LoadScene(2);
            }

            if (pos == 2)
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
