using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextAsset script;
    /* 
     * The dialogueBox is made of the following 
     * public Sprite SpeechBox;
     * public Sprite Portrait;
     * public Text Speech;
     * public Text CharName
     */
    public GameObject dialogueBox;

    private int lineNumber;
    private string nextLine;
    private string[] lines;

    private const string portraitPath = "Portraits/";
    private const string defaultImage = "walter";

    // Start is called before the first frame update
    private void Start()
    {
        lineNumber = 0;

        if (script == null)
        {
            Debug.Log("No script loaded");
            nextLine = "[testOne] No script loaded";
        }
        else
        {
            lines = script.text.Split('\n');
            Debug.Log(lines[lineNumber]);
            nextLine = lines[lineNumber];
        }
        
    }

    public void SayNextLine()
    {
        //End of script
        if (nextLine.Substring(0, 5) == "[end]")
        {
            Debug.Log("End of Script");
            if (dialogueBox.activeSelf)
                dialogueBox.SetActive(false);

            return;
        }

        //Say Nothing
        if (nextLine.Substring(0, 7) == "[break]")
        {
            Debug.Log("Nothing to say");
            if (dialogueBox.activeSelf)
                dialogueBox.SetActive(false);

            //Update nextLine
            lineNumber++;
            if (lineNumber < lines.Length)
                nextLine = lines[lineNumber];
            else
                nextLine = "";

            return;
        }

        //Tag not found
        int index = nextLine.IndexOf(']');
        if (index == -1)
        {
            Debug.Log("Check script format. Should be like '[name] message' on each line. " +
                "Pauses are '[break] #comment' and the end should be '[end] #comment'");
            return;
        }

        //Split Message
        string charName = "", message = "";
        charName = nextLine.Substring(1, index - 1);
        if (index + 1 < nextLine.Length)
            message = nextLine.Substring(index + 1);
        else
            message = "Out of Bounds";

        //Try to fetch image
        Sprite fetchedImage = Resources.Load<Sprite>(portraitPath + charName);
        if (fetchedImage == null)
        {
            fetchedImage = Resources.Load<Sprite>(portraitPath + defaultImage);
            message = "If you see me, something has gone wrong in fetching your portrait. Check your script at line " + (lineNumber + 1);
        }

        //Update DialogueBox
        dialogueBox.transform.GetChild(1).GetComponent<Image>().sprite = fetchedImage;
        dialogueBox.transform.GetChild(2).GetComponent<Text>().text = message;
        dialogueBox.transform.GetChild(3).GetComponent<Text>().text = charName;

        //Display Box
        if (!dialogueBox.activeSelf)
            dialogueBox.SetActive(true);

        //Update nextLine
        lineNumber++;
        if (lineNumber < lines.Length)
            nextLine = lines[lineNumber];
        else
            nextLine = "[break]";
    }
}
