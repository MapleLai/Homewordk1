using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	int [,] checkerboard = new int[3,3];
	int player = 0;


	// Use this for initialization
	void Start () {
		player = 0;
		for (int i = 0; i < 3; i++)
			for (int j = 0; j < 3; j++)
				checkerboard [i, j] = -1;
	}

	void OnGUI(){
		int is_over = check ();

		if (is_over != -1) {
			if (is_over == 0)
				GUI.Label (new Rect(370,50,100,50),"Player X wins!");
			if (is_over == 1)
				GUI.Label (new Rect(370,50,100,50),"Player O wins!");
		}
		else {
			GUI.Label (new Rect(370,50,100,50),"TicTacToe");
		}

		if (GUI.Button (new Rect (600, 320, 100, 50), "Reset")) {
			player = 0;
			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 3; j++)
					checkerboard [i, j] = -1;
		}

		for (int i = 0; i < 3; i++)
			for (int j = 0; j < 3; j++) {
				if (checkerboard [i, j] == 0)
					GUI.Button (new Rect (250 + i * 100, 70 + j * 100, 100, 100), "X");
				else if (checkerboard [i, j] == 1)
					GUI.Button (new Rect (250 + i * 100, 70 + j * 100, 100, 100), "O");
				else if (GUI.Button (new Rect (250 + i * 100, 70 + j * 100, 100, 100), "")) {
					if (is_over == -1) {
						checkerboard [i, j] = player;
						if (player == 0)
							player = 1;
						else
							player = 0;
					}
				}
			}
		
	}

	int check(){
		for (int i = 0; i < 3; i++)
			if (checkerboard [i, 0] != -1 && 
				checkerboard [i, 0] == checkerboard [i, 1] && 
				checkerboard [i, 1] == checkerboard [i, 2])
				return checkerboard [i, 0];

		for (int i = 0; i < 3; i++)
			if (checkerboard [0, i] != -1 && 
				checkerboard [0, i] == checkerboard [1, i] && 
				checkerboard [1, i] == checkerboard [2, i])
				return checkerboard [0, i];

		if (checkerboard [1, 1] != -1 &&
		     checkerboard [0, 0] == checkerboard [1, 1] &&
		     checkerboard [1, 1] == checkerboard [2, 2])
			return checkerboard [1, 1]; 

		if (checkerboard [1, 1] != -1 &&
			checkerboard [0, 2] == checkerboard [1, 1] &&
			checkerboard [1, 1] == checkerboard [2, 0])
			return checkerboard [1, 1]; 

		return -1;
	}
}