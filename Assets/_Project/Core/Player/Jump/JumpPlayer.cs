using UnityEngine;

namespace Core.PlayerJump
{
    public class JumpPlayer : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        public float JumpForce = 300f;
        //что бы эта переменная работала добавьте тэг "Ground" на вашу поверхность земли

        private bool _isGrounded;

        void FixedUpdate()
        {
            JumpLogic();
        }

        private void JumpLogic()
        {
            if (Input.GetAxis("Jump") > 0)
            {
                if (_isGrounded)
                {
                    // Обратите внимание что я делаю на основе Vector3.up а не на основе transform.up
                    // если наш персонаж это шар -- его up может быть в том числе и вниз и влево и вправо. 
                    // Но нам нужен скачек только вверх! Потому и Vector3.up
                    _rb.AddForce(Vector3.up * JumpForce);
                }
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            IsGroundedUpate(collision, true);
        }

        void OnCollisionExit(Collision collision)
        {
            IsGroundedUpate(collision, false);
        }

        private void IsGroundedUpate(Collision collision, bool value)
        {
            if (collision.gameObject.tag == ("Ground"))
            {
                _isGrounded = value;
            }
        }
    }
}
