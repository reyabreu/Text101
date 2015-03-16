using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;

public class TextController : MonoBehaviour
{
	public Text text;

	private enum States
	{
		start,
		cell,
		mirror,
		cell_mirror,
		cell_door,
		floor,
		closet_door,
		in_closet,
		courtyard,
		sheets_0,
		sheets_1,
		lock_0,
		lock_1,
		corridor_0,
		corridor_1,
		corridor_2,
		corridor_3,
		stairs_0,
		stairs_1,
		stairs_2,
		freedom
	}
	
	private States nextState;

	// Use this for initialization
	void Start ()
	{
		//print ("next state start");
		this.SetNextState (States.start);
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (nextState) {
		case States.start:
			this.start ();
			break;
		case States.cell:
			this.cell ();
			break;
		case States.sheets_0:
			this.sheets_0 ();
			break;
		case States.mirror:
			this.mirror ();
			break;
		case States.lock_0:
			this.lock_0 ();
			break;
		case States.cell_mirror:
			this.cell_mirror ();
			break;
		case States.sheets_1:
			this.sheets_1 ();
			break;
		case States.lock_1:
			this.lock_1 ();
			break;
		case States.cell_door:
			this.cell_door ();
			break;
		case States.corridor_0:
			this.corridor_0 ();
			break;
		case States.corridor_1:
			this.corridor_1 ();
			break;
		case States.corridor_2:
			this.corridor_2 ();
			break;
		case States.corridor_3:
			this.corridor_3 ();
			break;
		case States.stairs_0:
			this.stairs_0 ();
			break;
		case States.stairs_1:
			this.stairs_1 ();
			break;
		case States.stairs_2:
			this.stairs_2 ();
			break;
		case States.floor:
			this.floor ();
			break;
		case States.closet_door:
			this.closet_door ();
			break;
		case States.in_closet:
			this.in_closet ();
			break;
		case States.courtyard:
			this.courtyard ();
			break;
		case States.freedom:
			this.freedom ();
			break;
		default:
			break;
		}	

	}
	
	private void SetNextState (States newState)
	{
		//Load text from disk
		TextAsset cellText = Resources.Load (newState.ToString()) as TextAsset;
		this.text.text = cellText.text;
		this.nextState = newState;
	}

	private void start ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			//print ("next state cell");
			this.SetNextState (States.cell);
		}		
	}

	private void cell ()
	{
		if (Input.GetKeyDown (KeyCode.S)) {
			this.SetNextState (States.sheets_0);
		} else if (Input.GetKeyDown (KeyCode.M)) {
			this.SetNextState (States.mirror);
		} else if (Input.GetKeyDown (KeyCode.L)) {
			this.SetNextState (States.lock_0);
		}
	}

	private void sheets_0 ()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
			this.SetNextState (States.cell);
		}
	}

	private void sheets_1 ()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
			this.SetNextState (States.cell_mirror);
		}
	}

	private void mirror ()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
			this.SetNextState (States.cell);
		}
		if (Input.GetKeyDown (KeyCode.T)) {
			this.SetNextState (States.cell_mirror);
		}

	}

	private void cell_mirror ()
	{
		if (Input.GetKeyDown (KeyCode.S)) {
			this.SetNextState (States.sheets_1);
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			this.SetNextState (States.lock_1);
		}	
	}

	private void lock_0 ()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
			this.SetNextState (States.cell);
		}

	}
	
	private void lock_1 ()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
			this.SetNextState (States.cell_mirror);
		}
		if (Input.GetKeyDown (KeyCode.O)) {
			this.SetNextState (States.cell_door);
		}
		
	}

	private void cell_door ()
	{
		if (Input.GetKeyDown (KeyCode.W)) {
			this.SetNextState (States.corridor_0);
		}		
	}

	private void corridor_0 ()
	{
		if (Input.GetKeyDown (KeyCode.S)) {
			this.SetNextState (States.stairs_0);
		}
		if (Input.GetKeyDown (KeyCode.F)) {
			this.SetNextState (States.floor);
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			this.SetNextState (States.closet_door);
		}
	}

	private void stairs_0 ()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
			this.SetNextState (States.corridor_0);
		}
	}

	private void stairs_1 ()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
			this.SetNextState (States.corridor_1);
		}
	}

	private void closet_door ()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
			this.SetNextState (States.corridor_0);
		}
	}

	private void floor ()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
			this.SetNextState (States.corridor_0);
		}
		if (Input.GetKeyDown (KeyCode.H)) {
			this.SetNextState (States.corridor_1);
		}
	}

	private void corridor_1 ()
	{
		if (Input.GetKeyDown (KeyCode.S)) {
			this.SetNextState (States.stairs_1);
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			this.SetNextState (States.in_closet);
		}
	}

	private void corridor_2 ()
	{
		if (Input.GetKeyDown (KeyCode.S)) {
			this.SetNextState (States.stairs_2);
		}
	}

	private void stairs_2 ()
	{
		if (Input.GetKeyDown (KeyCode.P)) {
			this.SetNextState (States.cell);
		}
	}

	private void in_closet ()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
			this.SetNextState (States.corridor_2);
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			this.SetNextState (States.corridor_3);
		}
	}

	private void corridor_3 ()
	{
		if (Input.GetKeyDown (KeyCode.S)) {
			this.SetNextState (States.courtyard);
		}
		if (Input.GetKeyDown (KeyCode.U)) {
			this.SetNextState (States.in_closet);
		}
	}

	private void courtyard ()
	{
		if (Input.GetKeyDown (KeyCode.F)) {
			this.SetNextState (States.freedom);
		}
	}

	private void freedom ()
	{
		if (Input.GetKeyDown (KeyCode.P)) {
			this.SetNextState (States.cell);
		}
	}
	
}
