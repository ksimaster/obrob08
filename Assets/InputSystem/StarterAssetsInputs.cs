using UnityEngine;
using UnityEngine.InputSystem;

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		public GameObject pauseMenu;
        public GameObject mainMenu;
        public GameObject winMenu;
        public GameObject deathMenu;
        public GameObject shopMenu;
        public GameObject settingMenu;
        public GameObject rewardMenu;

        [Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if (cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			Debug.Log("Jump");
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnMenu(InputValue value)
		{
            if (!mainMenu.activeSelf && !winMenu.activeSelf && !deathMenu.activeSelf && !shopMenu.activeSelf && !settingMenu.activeSelf && !rewardMenu.activeSelf)
            {
                var newActiveState = !pauseMenu.activeSelf;
                pauseMenu.SetActive(newActiveState);
                SetCursorState(!newActiveState);
                Time.timeScale = newActiveState ? 0 : 1;
                Cursor.visible = newActiveState;
            }
        }

        public void OnMenuButton()
        {
            if (!mainMenu.activeSelf && !winMenu.activeSelf && !deathMenu.activeSelf && !shopMenu.activeSelf && !settingMenu.activeSelf && !rewardMenu.activeSelf)
            {
                var newActiveState = !pauseMenu.activeSelf;
                pauseMenu.SetActive(newActiveState);
                SetCursorState(!newActiveState);
                Time.timeScale = newActiveState ? 0 : 1;
                Cursor.visible = newActiveState;
            }
        }

        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		}

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		//public void OnApplicationFocus(bool hasFocus)
		//{
		//	SetCursorState(cursorLocked);
		//}

		public void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
            //Cursor.visible = !newState;

        }

	}

}