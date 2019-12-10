using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Wisp
{
    public class TextBoxManager : MonoBehaviour
    {
        public GameObject textBox;

        public Text theText;

        public TextAsset textFile;
        public string[] textLines;

        public string nextSceneTitle;

        public int currentLine;
        public int endAtLine;

        // Start is called before the first frame update
        void Start()
        {

            if (textFile != null)
            {
                textLines = textFile.text.Split('\n');
            }

            if (endAtLine == 0)
            {
                endAtLine = textLines.Length - 1;
            }
        }

        //This code is from a tutorial, but is fundamentally flawed.
        // it walks off the end of the array.
        void Update()
        {
            if (currentLine < endAtLine)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    currentLine++;
                }

                theText.text = textLines[currentLine];
            }
            if (currentLine == endAtLine)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene(nextSceneTitle);
                }
            }
        }

    }
}