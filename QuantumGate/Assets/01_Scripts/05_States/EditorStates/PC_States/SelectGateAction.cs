using System;
using UnityEngine;
using SerializableClass;

namespace PC_States
{//99999
    public class SelectGateAction : EditionState
    {
        private GateObject _selectedGate;
        private EditorState _previousState;


		public SelectGateAction(Editor context, GateObject selectedGate, EditorState previousState)
            : base(context)
        {
			//_nextGate = nextGate;
            _selectedGate = selectedGate;
            _previousState = previousState;
        }

        public override void OnEnter()
        {
			Debug.Log("SelectGateAction"+ _selectedGate.gateStruct.col);
            _selectedGate.Select();//aaaaaaaaaaaaaaaaaaaaaa
			//_nextGate.Select();
            PositionPanel();
            context.ShowActionsGatePanel(true);
        }

        public override void Update()
        {
            base.Update();
            PositionPanel();
        }
		public override void OnExit()
		{
			GateObject gateObject = _selectedGate.GetComponent<GateObject>();

			//gateObject.Deselect ();
			context.ShowActionsGatePanel(false);

		}

			


        public override void OnBackButton() { context.CurrentState = _previousState; }

        public override void OnInsertGateClick()
        {
            QCS.Circuit.GateStruct gateStruct = _selectedGate.gateStruct;

            int row = gateStruct.row;
            int col = gateStruct.col;

            context.CurrentState = new SelectGateToInsert(context, row, col, _previousState);
        }

        public override void OnDeleteGateClick()
        {
            QCS.Circuit.GateStruct gateStruct = _selectedGate.gateStruct;

            int row = gateStruct.row;
            int col = gateStruct.col;

            context.currentCircuit.RemoveGate(row, col);

            context.CurrentState = _previousState;
        }

        public override void OnMoveGateClick()
        {
            context.CurrentState = new MoveGate(context, _selectedGate, _previousState);
        }

		/// <summary>
		///  Fonction qui permet de selectionner les tuyaux lors du résultat afin de savoir ceux qui sont liés au tuyau demandé
		/// </summary>
        public override void OnProcessCircuitClick()
        {
            QCS.Circuit.GateStruct gateStruct = _selectedGate.gateStruct;
			int col = gateStruct.col;// ne pas toucher
			int numTuyau = col +1;
			int code = context.TuyauxLiee ();
			int cas = context.isRelated (code);
			int choix = context.Choice (numTuyau,cas);
			Debug.Log ("numTuyau :"+numTuyau+" code:"+ code + " cas: "+ cas +"choix: " + choix);
			int i = 0;
			int row = context.currentCircuit.NbRow;


			Debug.Log ("ligne"+ row);
			Debug.Log ("col"+ context.currentCircuit.NbCol);
			if(choix == 12){
				for (i = 0; i < row; i++) {
					context.gridBoard.GetGateObject (i, 0).Select();
					context.gridBoard.GetGateObject (i, 1).Select();
				}
			}

			if(choix == 2){
				for (i = 0; i < row; i++) {
					context.gridBoard.GetGateObject (i, 1).Select();

				}
			}

			if(choix == 1){
				for (i = 0; i < row; i++) {
					context.gridBoard.GetGateObject (i, 0).Select();
				}
			}

			if(choix == 3){
				for (i = 0; i < row; i++) {
					context.gridBoard.GetGateObject (i, 2).Select();
				}
			}

			if(choix == 123){
				for (i = 0; i < row; i++) {
					context.gridBoard.GetGateObject (i, 0).Select();
					context.gridBoard.GetGateObject (i, 1).Select();
					context.gridBoard.GetGateObject (i, 2).Select();
				}
			}

			if(choix == 23){
				for (i = 0; i < row; i++) {
					context.gridBoard.GetGateObject (i, 1).Select();
					context.gridBoard.GetGateObject (i, 2).Select();
				}
			}

			context.CurrentState = new ShowResult(context, row, col, _previousState, _selectedGate);
        }

        public void PositionPanel()
        {
            Vector3 screenPos = context.cam.WorldToScreenPoint(_selectedGate.pipes[0].transform.position);
            screenPos.y -= 40;
            screenPos.z = 0;
            context.SetActionGatePanelPosition(screenPos);
        }


    }
}
