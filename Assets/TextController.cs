using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour
{

	public Text text;
	private enum States { cell, bed, book_0, lock_0, cell_lockpick, 
						lock_1, book_1, freedom, toilet, toilet_1, corridor_0, corridor_1, stairs_0, stairs_1,
						wherehouse, open_cell, open_cell_1 
						};
	private States myState;

	// Use this for initialization
	void Start ()
	{
		myState = States.cell;
	}

	// Update is called once per frame
	void Update ()
	{
		print (myState);
		if (myState == States.cell) {
			cell ();
		} else if (myState == States.book_0) {
			book_0 ();
		} else if (myState == States.lock_0) {
			lock_0 ();
		} else if (myState == States.cell_lockpick) {
			cell_lockpick ();
		} else if (myState == States.book_1) {
			book_1 ();
		} else if (myState == States.lock_1) {
			lock_1 ();
		} else if (myState == States.toilet_1) {
			toilet_1 ();
		} else if (myState == States.bed) {
			bed_0 ();
		} else if (myState == States.toilet) {
			toilet ();
		} else if (myState == States.corridor_0) {
			corridor_0 ();
		} else if (myState == States.stairs_0) {
			stairs_0 ();
		} else if (myState == States.open_cell) {
			open_cell ();
		} else if (myState == States.stairs_1) {
			stairs_1 ();
		} else if (myState == States.corridor_1) {
			corridor_1 ();
		} else if (myState == States.wherehouse) {
			wherehouse ();
		}


	}

	void cell ()
	{
		text.text = "What? Where am I, is this a prison cell? " +
					"There is a... book on the bed and a toilet. " +
					"The door is clrearly sealed from the outside. There's no one watching...\n\n" +
					"Press B to look at the book, D to look down the bed, " +
					"press L to look at the lock, T to look at the toilet(eww)";


		if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.book_0;
		} else if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.lock_0;
		} else if (Input.GetKeyDown (KeyCode.T)) {
			myState = States.toilet;
		} else if (Input.GetKeyDown (KeyCode.D)) {
			myState = States.bed;
		} 
	}


	void book_0 () {
			text.text = "This book has a lot of information on string theory." +
						" Now I know a bit more about the universe and higher dimensions... " +
						"I still need to escape though... \n\n"
						+ "Press R to go back searching.";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}

	void lock_0 () {
		text.text = "The lock is a bit rusty... maybe if I had a lockpick or something similar...\n\n" + 
					"Press R to go back searching."; 
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}

	void toilet () {
		text.text = "Hmm, the toilet is dirty and stinky. Don't barf don't barf... \n\n" +
					"Press R to go back searching.";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}

	void bed_0 () {
		text.text = "You see a rat... dust and wait there is a hairclip?! I may be able to open the lock with this."
					+ "Press R to go back searching.";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_lockpick;
		}
	}


	//Now you have something to break the lock.
	void cell_lockpick () {
		text.text = "Now I have a lockpick... Let's see how I can use it. " + 
			"Press B to look at the book again, press L to look at the lock, " + 
			"press T to look at the toilet(why would you do that though?).";

		if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.book_1;

		} else if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.lock_1;
		} else if (Input.GetKeyDown(KeyCode.T)) {
			myState = States.toilet_1;
		}
		
	}

	void book_1 () {
		text.text = "It's still a physics book... Wonder if it may be of some use later... \n\n" + 
					"I'll grab it just in case. \n\n" + 
					"Press R to return";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_lockpick;

		}
	}

	void lock_1 ()
	{
		text.text = "*You used the hairclip* Is this working? I hear a click!\n\n" +
					"Press C to continue";
		if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.corridor_0;
		}
	}

	void toilet_1 () {
		text.text = "Really? The toilet again?\n\n" +
					"Press R to return";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_lockpick;
		}
		
	}

	void corridor_0 () {
		text.text = "I'm Free! But I still need to get out of this prison..." +
					"No one's here but me, the other cells are empty." + 
					"There are stairs, an open door that seems like is the wherehouse, and an open cell.\n\n" +
					"Press S to go to the stairs, C to look at the cell or W to look at the werehouse.";
		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.stairs_0;
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.open_cell;
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			myState = States.wherehouse;
		}

	}

	void stairs_0 () {

		text.text = "I can hear the guards over there, maybe I shouldn't go over there yet.\n\n" +
					"Press R to return to the corridor";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.corridor_0;
		}
		
	}

	void wherehouse () { 
		
		text.text = "Looking at all this stuff... there is a janitor uniform and a map of the prison.\n\n" +
					"With this I may be able to pass by the guards." +
					"Press R to return to the corridor";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.corridor_1;
		}
	}

	void open_cell () {
		text.text = "Nothing interesting here... \n\n" + 
					"Press R to return to the corridor";
			if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.corridor_0;
		}
		
	}



	void corridor_1 () {
		text.text = "Now I have the janitor's uniform, I may be able to pass through the guards with this...\n\n" +
					"Press S to go to the stairs";
		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.stairs_1;
		}

	}

	void stairs_1 () {
			text.text = "With the janitors uniform I passed through... I even lighted a smoke that was in a pocket to make it look more natural.\n\n" +
						"To be continued... Press P to play again.";
		if (Input.GetKeyDown (KeyCode.P)) {
			myState = States.cell;
		}
		}



} 

