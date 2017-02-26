using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	
	private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, corridor_0};
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if 		(myState == States.cell) 		{state_cell();}
		else if (myState == States.sheets_0) 	{state_sheets_0();}
		else if (myState == States.lock_0) 		{state_lock_0();}
		else if (myState == States.sheets_1) 	{state_sheets_1();}
		else if (myState == States.lock_1) 		{state_lock_1();}
		else if (myState == States.mirror)		{state_mirror();}
		else if (myState == States.cell_mirror)	{state_cell_mirror();}
		else if (myState == States.corridor_0)	{state_corridor_0();}
	}
	
	#region State handler methods
	void state_cell () {
		text.text = "Du sitzt im Gefängnis, " +
					"es ist kalt und du bist hungrig. " +
					"Du merkst, du musst hier raus. " +
					"Die Tür ist von außen abgeschlossen, " +
					"du hast deine dreckigen Bettlaken " +
					"und einen Spiegel an der Wand.\n\n" +
					"Drücke B um die Bettlaken anzusehen, " +
					"S für den Spiegel oder T für das Türschloss.";
					
		if (Input.GetKeyDown(KeyCode.B)) 		{myState = States.sheets_0;}
		else if (Input.GetKeyDown(KeyCode.S)) {myState = States.mirror;}
		else if (Input.GetKeyDown(KeyCode.T)) {myState = States.lock_0;}
	}
	
	void state_mirror () {
		text.text = "Der dreckige alte Spiegel sieht aus, als würde er nur " +
			"sehr locker an der Wand hängen.\n\n" +
				"Drücke N um den Spiegel zu nehmen oder drücke Z um dich zurück weiter in deiner Zelle umzusehen.";
		
		if (Input.GetKeyDown(KeyCode.N)) {myState = States.cell_mirror;}
		else if (Input.GetKeyDown(KeyCode.Z)) {myState = States.cell;}
	}
	
	void state_cell_mirror () {
		text.text = "Du bist immer noch in dieser kleinen Zelle und willst entkommen. " +
					"Es liegen immer noch die dreckigen Bettlaken auf dem Bett, es ist  " +
					"eine helle Stelle an der Wand wo der Spiegel war und die Türe ist immer noch verschlossen.\n\n" +
					"Drücke B um dir die Bettlaken anzusehen oder T um das Türschloss zu betrachten.";
		
		if (Input.GetKeyDown(KeyCode.B)) {myState = States.sheets_1;}
		else if (Input.GetKeyDown(KeyCode.T)) {myState = States.lock_1;}
	}	
	
	void state_sheets_0 () {
		text.text = "Es sieht so aus, als hättest du " +
					"letzte Nacht mit ein paar " +
					"Silberfischchen gekuschelt. " +
					"Wie bist du nur in diese Lage  " +
					"gekommen? Naja, nichts wie raus " +
					"hier.\n\n" +
					"Drücke Z um dich zurück weiter in deiner Zelle " +
					"umzusehen.";
		
		if (Input.GetKeyDown(KeyCode.Z)) {myState = States.cell;}
	}
	
	void state_sheets_1 () {
		text.text = "Mit dem Spiegel in deiner Hand sieht dein Bett auch nicht schöner aus, " +
					"es sei denn du möchtest dich selbst bemitleiden!\n\n" +
					"Drücke Z um dich zurück weiter in deiner Zelle " +
					"umzusehen.";
		
		if (Input.GetKeyDown(KeyCode.Z)) {myState = States.cell_mirror;}
	}
	
	void state_lock_0 () {
		text.text = "Das Türschloss ist ein Zahlen-" +
					"Kombinationsschloss, aber du " +
					"hast keine Ahnung, wie ist richtige " +
					"Kombination ist. Du wünschtest du " +
					"würdest wissen, wie der Code ist.\n\n" +
					"Drücke Z um dich zurück weiter in deiner Zelle " +
					"umzusehen.";
		
		if (Input.GetKeyDown(KeyCode.Z)) {myState = States.cell;}
	}
	
	void state_lock_1 () {
		text.text = "Du schiebst den Spiegel vorsichtig und leise zwischen den Gitterstäben durch " +
					"und drehst ihn, um das Türschloss außen zu sehen. Zum Glück kannst ein paar Fingerabdrücke " +
					"sehen. Du drückst die schmutzigen Tasten und hörst ein Klicken.\n\n" +
					"Drücke A um die Türe aufzumachen oder drücke Z um dich zurück weiter in deiner Zelle umzusehen.";
		
		if (Input.GetKeyDown(KeyCode.A)) {myState = States.corridor_0;}
		else if (Input.GetKeyDown(KeyCode.Z)) {myState = States.cell_mirror;}
	}
	
	void state_corridor_0 () {
		text.text = "Du betrittst einen langen Korridor.\n\n" +
					"Drücke S um erneut zu spielen! :)";
		
		if (Input.GetKeyDown(KeyCode.S)) {myState = States.cell;}
	}
	
	#endregion
}
