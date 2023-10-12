using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueManager4 : MonoBehaviour
{
    public string[] myDialogue;

    public Text unknownText;
    public Text youText;

    private int myCounter;

    private float textSpeed;
    private int characterIndex;

    private GameObject unknownDialogue;
    private GameObject youDialogue;
    private GameObject nextButton;
    private GameObject sceneButton;
    private GameObject tutorial;
    private GameObject okButton;
    private GameObject continueButton;
    private GameObject NoThanks;
    private GameObject BarUp;
    private GameObject BarDown;
    private GameObject BarLeft;
    private GameObject BarRight;
    private GameObject FinLeft;
    private GameObject FinRight;

    private GameObject BalaShark01;
    private GameObject BalaShark02;
    private GameObject BalaShark03;
    private GameObject Player01;
    private GameObject Player02;
    private GameObject Player03;
    private GameObject Player04;

    private bool goNext = false;

    public Animator animator;
    public Animator animator2;

    void Start()
    {
        // Find game objects using tag
        unknownDialogue = GameObject.FindGameObjectWithTag("unknownDialogue");
        youDialogue = GameObject.FindGameObjectWithTag("youDialogue");
        nextButton = GameObject.FindGameObjectWithTag("nextButton");
        sceneButton = GameObject.FindGameObjectWithTag("sceneButton");
        tutorial = GameObject.FindGameObjectWithTag("Tutorial");
        okButton = GameObject.FindGameObjectWithTag("Ok");
        continueButton = GameObject.FindGameObjectWithTag("continueButton");
        NoThanks = GameObject.FindGameObjectWithTag("NoThanks");
        BarUp = GameObject.FindGameObjectWithTag("BarUp");
        BarDown = GameObject.FindGameObjectWithTag("BarDown");
        BarLeft = GameObject.FindGameObjectWithTag("BarLeft");
        BarRight = GameObject.FindGameObjectWithTag("BarRight");
        FinLeft = GameObject.FindGameObjectWithTag("FinLeft");
        FinRight = GameObject.FindGameObjectWithTag("FinRight");

        // Find Audio using tag
        BalaShark01 = GameObject.FindGameObjectWithTag("BalaShark01");
        BalaShark02 = GameObject.FindGameObjectWithTag("BalaShark02");
        BalaShark03 = GameObject.FindGameObjectWithTag("BalaShark03");
        Player01 = GameObject.FindGameObjectWithTag("Player01");
        Player02 = GameObject.FindGameObjectWithTag("Player02");
        Player03 = GameObject.FindGameObjectWithTag("Player03");
        Player04 = GameObject.FindGameObjectWithTag("Player04");
        
        //Hide game objects
        unknownDialogue.SetActive(false);
        youDialogue.SetActive(false);
        nextButton.SetActive(false);
        sceneButton.SetActive(false);
        tutorial.SetActive(false);
        okButton.SetActive(false);
        continueButton.SetActive(false);
        NoThanks.SetActive(false);
        BarUp.SetActive(false);
        BarDown.SetActive(false);
        BarRight.SetActive(false);
        BarLeft.SetActive(false);
        FinLeft.SetActive(false);
        FinRight.SetActive(false);

        //Hide audio
        BalaShark01.SetActive(false);
        BalaShark02.SetActive(false);
        BalaShark03.SetActive(false);
        Player01.SetActive(false);
        Player02.SetActive(false);
        Player03.SetActive(false);
        Player04.SetActive(false);

        // Controlling the text as they appear on the screen
        textSpeed = 0.01f;
        characterIndex = 0;
        myCounter = 0;
    }   

    IEnumerator DisplayText()
    {
        while (1 == 1)
        {
            yield return new WaitForSeconds(textSpeed);

            if (characterIndex > myDialogue[myCounter].Length)
            {
                //Hide the next button if conversation is happening
                if (myCounter!= 6)
                {
                    nextButton.SetActive(true);
                }

                continue;
            }

            if(unknownDialogue.activeSelf)
            {
                unknownText.text = myDialogue[myCounter].Substring(0, characterIndex);
            }

             if(youDialogue.activeSelf)
            {
                youText.text = myDialogue[myCounter].Substring(0, characterIndex);
            }

            characterIndex++;
        }
    }

    public void StartDialogue()
    {
        animator.SetTrigger("Bars_In");
        animator2.SetTrigger("Bars_In");
        DialogueOne();
        Debug.Log("Dialogue");
    }

   
    public void nextDialogue()
    {
       goNext = true;
       if(goNext==true && myCounter < myDialogue.Length)
       {
            if (characterIndex < myDialogue[myCounter].Length)
            {
                characterIndex = myDialogue[myCounter].Length;
            }
            else if (myCounter < myDialogue.Length -1)
            {
                myCounter++;
                characterIndex = 0;
            } 

            goNext = false;
       }

       if (myCounter == 2 | myCounter == 4)
       {
            youDialogue.SetActive(false);
            unknownDialogue.SetActive(true);
       }

       if (myCounter == 1 | myCounter == 3 | myCounter == 5 )
       {
            youDialogue.SetActive(true);
            unknownDialogue.SetActive(false);
       }

       if (myCounter == 6)
       {
            nextButton.SetActive(false);
            Player03.SetActive(false);
            Player04.SetActive(true);

       }

       if (myCounter == 1)
       {
            BalaShark01.SetActive(false);
            Player01.SetActive(true);
       }

       if (myCounter == 2)
       {
            BalaShark02.SetActive(true);
            Player01.SetActive(false);
       }

       if (myCounter == 3)
       {
            BalaShark02.SetActive(false);
            Player02.SetActive(true);
       }

       if (myCounter == 4)
       {
            BalaShark03.SetActive(true);
            Player02.SetActive(false);
       }

       if (myCounter == 5)
       {
            BalaShark03.SetActive(false);
            Player03.SetActive(true);
       }
    }

    void DialogueOne()
    {
        unknownDialogue.SetActive(true);
        youDialogue.SetActive(false);
        BalaShark01.SetActive(true);
        StartCoroutine(DisplayText());
        sceneButton.SetActive(true);
    }

    public void closeDialogue()
    {
        youDialogue.SetActive(false);
        unknownDialogue.SetActive(false);
        nextButton.SetActive(false);
        sceneButton.SetActive(false);
        animator.SetTrigger("Bars_Out");
        animator2.SetTrigger("Bars_Out");
        tutorial.SetActive(true);
        okButton.SetActive(true);
        NoThanks.SetActive(true);
    }

    public void closeTutorial()
    {
        tutorial.SetActive(false);
        okButton.SetActive(false);
        continueButton.SetActive(true);
        NoThanks.SetActive(false);
        BarUp.SetActive(true);
        BarDown.SetActive(true);
        BarRight.SetActive(true);
        BarLeft.SetActive(true);
        FinLeft.SetActive(true);
        FinRight.SetActive(true);
    }
}