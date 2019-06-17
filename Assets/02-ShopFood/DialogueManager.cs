using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
	public Animator animator;

	private Queue<string> sentences;

	void Start () {
		sentences = new Queue<string> ();
	}//end Start


	public void StartDialogue(Dialogue dialogue){

		animator.SetBool ("IsOpen", true);

		Debug.Log ("Starting conversation with " + dialogue.name);
		nameText.text = dialogue.name;

		sentences.Clear ();

		foreach (string sentence in dialogue.sentences) {
			sentences.Enqueue (sentence);
		}
	}//end StartDialogue

	public void DisplayNextSentence(){
		if (sentences.Count == 0) {
			EndDialogue ();
			return;
		}

		string sentence = sentences.Dequeue ();
		Debug.Log (sentence);

		dialogueText.text = sentence;
		StopAllCoroutines ();
		StartCoroutine (TypeSentence (sentence));

	}//end DisplayNextSentence

	IEnumerator TypeSentence(string sentence){
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()) {
			dialogueText.text += letter;
			yield return null;
		}
	}//end 

	void EndDialogue(){
		Debug.Log ("End of conversation");
		animator.SetBool ("IsOpen", false);
	}

}//end class
