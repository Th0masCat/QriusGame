using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST, DRAW }

public class BattleSystem : MonoBehaviour
{
	public QuizManager quiz;

	Unit playerUnit;
	Unit enemyUnit;

	public Transform playerBattleStation;
	public Transform enemyBattleStation;

	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

	public GameObject playerPrefab;
	public GameObject enemyPrefab;

	public Text dialogueText;
	
	public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
		state = BattleState.START;
		StartCoroutine(SetupBattle());
    }

	IEnumerator SetupBattle()
	{
		
		playerUnit = playerPrefab.GetComponent<Unit>();
		enemyUnit = enemyPrefab.GetComponent<Unit>();

		dialogueText.text = "A wild " + enemyUnit.unitName + " approaches...";
		
		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);

		yield return new WaitForSeconds(2f);

		state = BattleState.PLAYERTURN;
		StartCoroutine(PlayerTurn());
	}

	IEnumerator PlayerAttack()
	{
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP);
		dialogueText.text = "The attack is successful!";

		yield return new WaitForSeconds(2f);

		if(isDead)
		{
			state = BattleState.WON;
			EndBattle();
		} else if (quiz.questionCount == quiz.unansweredQuestions.Count)
        {
			state = BattleState.DRAW;
			EndBattle();
        }else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator EnemyTurn()
	{
		dialogueText.text = enemyUnit.unitName + " attacks!";

		yield return new WaitForSeconds(1f);

		bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

		playerHUD.SetHP(playerUnit.currentHP);

		yield return new WaitForSeconds(1f);

		if(isDead)
		{
			state = BattleState.LOST;
			EndBattle();
		}
		else if (quiz.questionCount == quiz.unansweredQuestions.Count)
		{
			state = BattleState.DRAW;
			EndBattle();
		}
		else
		{
			state = BattleState.PLAYERTURN;
		    StartCoroutine(PlayerTurn());
		}

	}

	void EndBattle()
	{
		if(state == BattleState.WON)
		{
			dialogueText.text = "You won the battle!";
		} else if (state == BattleState.LOST)
		{
			dialogueText.text = "You were defeated.";
		} else if(state == BattleState.DRAW)
        {
			dialogueText.text = "Draw";
		}
		SceneManager.LoadScene(0);
	}

	IEnumerator PlayerTurn()
	{
		dialogueText.text = "Choose an option:";

		yield return new WaitForSeconds(1f);

		quiz.SetCurrentQuestion();
	}

	IEnumerator IncorrectOption()
	{
		playerUnit.TakeDamage(5);

		playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "Wrong Answer!";

		yield return new WaitForSeconds(2f);

		state = BattleState.ENEMYTURN;
		StartCoroutine(EnemyTurn());
	}



	public void Button1()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		if (quiz.currentQuestion.correctOption == 1)
		{
			StartCoroutine(PlayerAttack());
			Debug.Log("True");
		}
		else
		{
			Debug.Log("Incorrect");
			StartCoroutine(IncorrectOption());
		}
	}

	public void Button2()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		if (quiz.currentQuestion.correctOption == 2)
		{
			StartCoroutine(PlayerAttack());
			Debug.Log("True");
		}
		else
		{
			Debug.Log("Incorrect");
			StartCoroutine(IncorrectOption());
		}
	}

	public void Button3()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		if (quiz.currentQuestion.correctOption == 3)
		{
			StartCoroutine(PlayerAttack());
			Debug.Log("True");
		}
		else
		{
			Debug.Log("Incorrect");
			StartCoroutine(IncorrectOption());
		}
	}

	public void Button4()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		if (quiz.currentQuestion.correctOption == 4)
		{
			StartCoroutine(PlayerAttack());
			Debug.Log("True");
		}
		else
		{
			Debug.Log("Incorrect");
			StartCoroutine(IncorrectOption());
		}
	}

}
