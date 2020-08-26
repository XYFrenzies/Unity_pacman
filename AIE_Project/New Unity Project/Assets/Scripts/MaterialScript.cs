using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScript : MonoBehaviour
{

    private Color[] colours;

    private Renderer render;

    public float transitionTime;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();

        colours = new Color[6];

        colours[0] = Color.white;

        colours[1] = Color.black;

        colours[2] = Color.red;

        colours[3] = Color.green;

        colours[4] = Color.blue;

        colours[5] = Color.magenta;

        //start our coroutine when the game starts

        StartCoroutine(ColourChange());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ColourChange()
    {
        while (true)
        {
            Color newColour = colours[(Random.Range(0, 5))]; // Assign newColor to a random color from our array

            float transitionRate = 0; //Create and set transitionRate to 0. This is necessary for our next while loop to function

            /* 1 is the highest value that the Color.Lerp function uses for

             * transitioning between two colors. This while loop will execute

             * until transitionRate is incremented to 1 or higher

             */

            while (transitionRate < 1)

            {

                //this next line is how we change our material color property. We Lerp between the current color and newColor

                render.material.SetColor("_Color", Color.Lerp(render.material.color, newColour, Time.deltaTime * transitionRate));

                transitionRate += Time.deltaTime / transitionTime; // Increment transitionRate over the length of transitionTime

                yield return null; // wait for a frame then loop again
            }
        }
    }
}
