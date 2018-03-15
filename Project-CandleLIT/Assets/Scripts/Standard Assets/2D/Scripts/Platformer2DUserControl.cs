using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private selectplayer selectplayer;
        private Flashlight fl;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            selectplayer = GetComponent<selectplayer>();
            fl = GetComponent<Flashlight>();
        }


        private void Update()
        {
            if (selectplayer.isPlayer1)
            {
                if (!m_Jump)
                {
                    // Read the jump input in Update so button presses aren't missed.
                    m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
                }
            }
            else if(selectplayer.isPlayer2)
            {
                if (!m_Jump)
                {
                    // Read the jump input in Update so button presses aren't missed.
                    m_Jump = CrossPlatformInputManager.GetButtonDown("p2jump");
                }
            }
        }


        private void FixedUpdate()
        {
            if (selectplayer.isPlayer1)
            {
                // Read the inputs.
                bool crouch = Input.GetKey(KeyCode.LeftControl);
                float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
                // Pass all parameters to the character control script.
                m_Character.Move(h, crouch, m_Jump);
                m_Jump = false;
                if (Input.GetKey("f"))
                {
                    fl.ToggleLight();
                }
            }
            else if(selectplayer.isPlayer2)
            {
                // Read the inputs.
                bool crouch = Input.GetKey(KeyCode.LeftControl);
                float h = CrossPlatformInputManager.GetAxisRaw("P2Horizontal");
                // Pass all parameters to the character control script.
                m_Character.Move(h, crouch, m_Jump);
                m_Jump = false;
                if (Input.GetKey("k"))
                {
                    fl.ToggleLight();
                }
            }
        }
    }
}
