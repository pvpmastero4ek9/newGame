using UnityEngine;

namespace Core.PlayerMove
{
    //эта строчка гарантирует что наш скрипт не завалится ести на плеере будет отсутствовать компонент Rigidbody
    [RequireComponent(typeof(Rigidbody))]
    public class MovePlayer : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        // т.к. логика движения изменилась мы выставили меньшее и более стандартное значение
        public float Speed = 5f;
        
        void FixedUpdate()
        {
            //обратите внимание что все действия с физикой 
            //желательно делать в FixedUpdate, а не в Update
            // в даном случае допустимо использовать это здесь, но можно и в Update.
            // но раз уж вызываем здесь, то 
            // двигать будем используя множитель fixedDeltaTimе 
            MovementLogic();
        }
        
        private void MovementLogic()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");

            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            // что бы скорость была стабильной в любом случае
            // и учитывая что мы вызываем из FixedUpdate мы умножаем на fixedDeltaTimе
            transform.Translate(movement * Speed * Time.fixedDeltaTime);
        }
    }
}
