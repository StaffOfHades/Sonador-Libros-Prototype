using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Operation : MonoBehaviour {

	public Sprite buenaImage;
	public Sprite malaImage;
	public Sprite imagenBoton;
	public Button revisarPagar;

	public InputField cost1_text;
	public InputField cost2_text;
	public InputField cost3_text;
	public InputField howmany1_text;
	public InputField howmany2_text;
	public InputField howmany3_text;
	public InputField pagar_text;

	private int cost1;
	private int cost2;
	private int cost3;
	private int howmany1;
	private int howmany2;
	private int howmany3;
	private int pagar;

	private int resultado;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void sumar(){
		
	}//end sumar

	public void EvaluarDatos(){
		// Campos que llena el usuario
		cost1 = int.Parse (cost1_text.text.ToString ());
		cost2 = int.Parse (cost2_text.text.ToString ());
		cost3 = int.Parse (cost3_text.text.ToString ());
		howmany1 = int.Parse (howmany1_text.text.ToString ());
		howmany2 = int.Parse (howmany2_text.text.ToString ());
		howmany3 = int.Parse (howmany3_text.text.ToString ());

		// Total a pagar
		pagar = int.Parse (pagar_text.text.ToString ());

		// Comprobación resultado
		resultado = cost1 * howmany1 + cost2 * howmany2 + cost3 * howmany3;

		Debug.Log (pagar);
		Debug.Log (resultado);

		if (pagar != resultado) {
			revisarPagar.image.sprite = malaImage;
		} else {
			revisarPagar.image.sprite = buenaImage;
		}

	}//end EvaluarDatos()

}//end class
