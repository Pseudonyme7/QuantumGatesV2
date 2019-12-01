using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Etat pour montrer le résultat du circuit quantique jusqu'a la ligne _row.
/// </summary>
namespace Smartphone_States
{
    public class ShowResult : EditorState
    {
        /// <summary>
        /// Numero de la ligne
        /// </summary>
		private int _row;
		private int _col;
        /// <summary>
        /// Etat precedent
        /// </summary>
        private EditorState _previousState;
		private GateObject _selectedGate;

        /// <summary>
        /// </summary>
        /// <param name="context">Le SandBoxManager qui est le contexte du jeu</param>
        /// <param name="row">Numero de la ligne où l'evaluation du circuit s'arrete</param>
        /// <param name="previousState">Etat precedent</param>
		public ShowResult(Editor context, int row, int col, EditorState previousState) : base(context)
		{
			_row = row;
			_col = col;
			_previousState = previousState;

		}

		public override void OnEnter()
		{

			string res, res1, realres, test1;
			int taille, cas, codeLiaison, choix = 0, numTuyau;
		
			Debug.Log("ShowResult");
			test1 = context.currentCircuit.Evaluate(_row).ToString();
			Debug.Log("teeeest"+ test1);
			res = context.currentCircuit.Evaluate(_row).ToString();

			numTuyau = _col + 1;
			codeLiaison = context.TuyauxLiee();//MARCHE BIEN
			cas = context.isRelated (codeLiaison);// MARCHE BIEN
			choix = context.Choice (numTuyau, cas);//MARCHE BIEN


			res1 = context.ApplyingChoiceOnRes(res, choix);

			realres = context.ApplyTextMeshPro(res1);



			//Affichage des données manipulées dans la console afin d'avoir une idée de ce qui est fait
			//Debug.Log("chaine1 ="+ res1);
			//Debug.Log("chaine2 ="+ realres);

			context.SetResultText (realres );






			// Section qui sert a redimensionner le nuage en fonction de la taille du resultat à afficher
			taille = res.Length;
			if(taille > 50){
				context.SetresultPanelScale(new Vector3(1.0f, 1.0f, 1.0f)*1.1f);
				context.SetResultSize(25);
			}
			if(taille > 30 && taille <= 50){
				context.SetresultPanelScale(new Vector3(1.0f, 1.0f, 1.0f));
				context.SetResultSize(30);
			}
			if(taille <= 30){
				context.SetresultPanelScale(new Vector3(1.0f, 1.0f, 1.0f)*0.7f);//taille du nuage
				context.SetResultSize(50);// Modification du text de la boite des resultats
			}



			//Debug.Log("taille ="+ taille);// message de test pour afficher la taille du résultat dans la console

			context.ShowResultPanel(true);

		}

        public override void OnExit() {
            context.gridBoard.DeselectRow(_row);
            context.ShowResultPanel(false);
        }

        public override void OnBackResultClick() { context.CurrentState = _previousState; }

        public override void OnBackButton() { OnBackResultClick(); }
    }
}
