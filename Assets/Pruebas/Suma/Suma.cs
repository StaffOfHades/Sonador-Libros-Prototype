using UnityEngine;
using System.Collections;
//using System.Collections.Generic;
using UnityEngine.UI;

public class Suma : MonoBehaviour {

	public Sprite Buena;
	public Sprite Mala;
	public Sprite ImagenBoton;
	public Button Revisar;

	public Text variable1_text;
	public Text variable2_text;
	public InputField resultado_text;

	private int variable1;
	private int variable2;
	private int resultado;

	// Use this for initialization
	void Start () {
		GenerarValores ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GenerarValores(){
		variable1 = Random.Range (1, 20);
		variable2 = Random.Range (1, 50);
		variable1_text.text = variable1.ToString ();
		variable2_text.text = variable2.ToString ();
		Revisar.image.sprite = ImagenBoton;
		resultado_text.text = "";
			
	}//end generarValores()

	public void sumar(){
		//variable1 = int.Parse (variable1_text.text.ToString ());
		//variable2 = int.Parse (variable2_text.text.ToString ());
		resultado = variable1 + variable2;
		resultado_text.text = resultado.ToString ();
	}//end sumar()

	public void EvaluarDatos(){
		int temp = int.Parse (resultado_text.text.ToString());
		resultado = variable1 + variable2;
		if (temp != resultado) {
			Revisar.image.sprite = Mala;
		} else {
			Revisar.image.sprite = Buena;
		}

	}//end EvaluarDatos()


}
