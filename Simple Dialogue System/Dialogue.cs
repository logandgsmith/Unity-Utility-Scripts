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
    private Hashtable labels;

    private const string portraitPath = "Portraits/";
    private const string defaultImage = "walter";

    // Start is called before the first frame update
    private void Start()
    {
        lineNumber = 0;
        labels = new Hashtable();

        if (script == null)
        {
            Debug.Log("No script loaded");
            nextLine = "[testOne] No script loaded";
        }
        else
        {
            //Load Script
            lines = script.text.Split(new[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            nextLine = lines[lineNumber];

            //Collect labels
            for(int i = 0; i < lines.Length; i++)
            {
                if(lines[i].Substring(0, 1) == "*" && lines[i] != "*END*")
                {
                    int length = lines[i].LastIndexOf('*');
                    Debug.Log(lines[i].Substring(1, length - 1));
                    labels.Add(lines[i].Substring(1, length - 1), i);
                }
            }
        }
        
    }

    //Used for reading from a character script, invoke to advance the script!
    public void SayNextLine()
    {
        //End of script
        if (nextLine.Substring(0, 5) == "[end]")
        {
            Debug.Log("End of Script");
            HideBox();

            return;
        }

        //Say Nothing
        if (nextLine.Substring(0, 7) == "[break]")
        {
            HideBox();
            AdvanceLineNumber(1);

            return;
        }

        ParseLine(nextLine);
        AdvanceLineNumber(1);  
    }

    //Used for saying One Off Remarks that don't fit into the character script
    public IEnumerator SayOneOff(string label)
    {
        int index;
        string line;

        Debug.Log("Label: " + label);

        //Parse the Line
        index = ((int) labels[label]) + 1;
        while ((line = lines[index++]) != "*END*" )
        { 
            ParseLine(line);
            yield return new WaitForSeconds(2);
        }

        HideBox();
    }

    //Advance the script line number by a certain amount
    public void AdvanceLineNumber(int advanceBy)
    {
        lineNumber += advanceBy;
        if (lineNumber < lines.Length)
            nextLine = lines[lineNumber];
        else
            nextLine = "[end]";
    }

    //Parses a given line for the '[character] message' syntax
    //DOES NOT CHECK FOR [] OR ** CODES, THAT IS HANDLED ELSEWHERE!
    private void ParseLine(string line)
    {
        //Tag not found
        Debug.Log(line);
        int index = line.IndexOf(']');
        if (index == -1)
        {
            Debug.Log("Check script format. Should be like '[name] message' on each line. " +
                "Pauses are '[break] #comment' and the end should be '[end] #comment'");
            HideBox();

            return;
        }

        //Split Message
        string charName = "", message = "";
        charName = line.Substring(1, index - 1);
        if (index + 1 < line.Length)
            message = line.Substring(index + 1);
        else
            message = "Out of Bounds";

        //Try to fetch image
        Sprite fetchedImage = Resources.Load<Sprite>(portraitPath + charName);
        if (fetchedImage == null)
        {
            fetchedImage = Resources.Load<Sprite>(portraitPath + defaultImage);
            message = "If you see me, something has gone wrong in fetching your portrait. Check your script at line " + (lineNumber + 1);
        }

        UpdateBox(fetchedImage, message, charName);
    }

    //Updates the box
    private void UpdateBox(Sprite fetchedImage, string message, string charName)
    {
        //Update DialogueBox
        dialogueBox.transform.GetChild(1).GetComponent<Image>().sprite = fetchedImage;
        dialogueBox.transform.GetChild(2).GetComponent<Text>().text = message;
        dialogueBox.transform.GetChild(3).GetComponent<Text>().text = charName;

        //Display Box
        if (!dialogueBox.activeSelf)
            dialogueBox.SetActive(true);
    }

    //Hides the box when there's no dialogue
    private void HideBox()
    {
        if (dialogueBox.activeSelf)
            dialogueBox.SetActive(false);
    }
}
