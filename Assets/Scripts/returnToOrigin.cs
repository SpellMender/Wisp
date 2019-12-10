using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Wisp
{
    public class returnToOrigin : MonoBehaviour
    {
        public GameObject textBox = null;

        public Text theText = null;

        public TextAsset textFile = null;
        public string[] textLines;

        public int currentLine;
        public int endAtLine;

        public bool isReading = false;

        public int signIndex = 0;

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
        void Update()
        {
            if (isReading)
            {
                textBox.SetActive(true);
                signIndex = GameController.instance.signProgress;
                theText.text = textLines[signIndex];
            }
            else
            {
                textBox.SetActive(false);
            }

            ////This code is from a tutorial, but is fundamentally flawed.
            //// it walks off the end of the array.
            //theText.text = textLines[currentLine];

            //if (Input.GetKeyDown(KeyCode.Return))
            //{
            //    currentLine += 1;
            //}

            //if (currentLine > endAtLine)
            //{
            //    textBox.SetActive(false);
            //}
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag.Contains("returnBound"))
            {
                gameObject.transform.position = Vector2.zero;
            }
            if (collision.collider.tag.Contains("Door"))
            {
                if (GameController.instance.doorTalkEnabled)
                {
                    GameController.instance.doorTalkEnabled = false;
                    SceneManager.LoadScene("DoorDialogue");
                }
                else
                    SceneManager.LoadScene("Door Puzzle");
            }
            if (collision.collider.tag.Contains("Return"))
            {
                GameController.instance.signProgress = 0;
                SceneManager.LoadScene("Maze");
            }
            if (collision.collider.tag.Contains("Progress"))
            {
                Progress();
            }
            if (collision.collider.tag.Contains("Reset"))
            {
                ResetDoor();
            }
            if (collision.collider.tag.Contains("Left"))
            {
                switch (GameController.instance.signProgress)
                {
                    case 1:
                        Progress();
                        break;
                    case 6:
                        Progress();
                        break;
                    default:
                        ResetDoor();
                        break;
                }
            }
            if (collision.collider.tag.Contains("Right"))
            {
                switch (GameController.instance.signProgress)
                {
                    case 1:
                        ResetDoor();
                        break;
                    case 6:
                        ResetDoor();
                        break;
                    default:
                        Progress();
                        break;
                }
            }

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            isReading = true;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            isReading = false;
        }
        private void Progress()
        {
            if (GameController.instance.signProgress < endAtLine)
            {
                gameObject.transform.position = Vector2.zero;
                GameController.instance.signProgress++;
            }
            else if (GameController.instance.signProgress == endAtLine)
                SceneManager.LoadScene("FinalScene");
        }
        private void ResetDoor()
        {
            GameController.instance.signProgress = 0;
            gameObject.transform.position = Vector2.zero;
        }
    }
}