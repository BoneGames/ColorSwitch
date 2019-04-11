using UnityEngine;
using UnityEngine.Events;

namespace ColorSwitch
{
    public class Player : MonoBehaviour
    {
        public float jumpForce = 10f;

        public Rigidbody2D rigid;
        public SpriteRenderer rend;

        public Color[] colors = new Color[4];

        public UnityEvent onGameOver;

        private Color currentColor;
        

        void Start()
        {
            RandomizeColor();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
            {
                rigid.velocity = Vector2.up * jumpForce;
            }
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            string name = col.name;
            switch (name)
            {
                case "ColorChanger":
                RandomizeColor();
                Destroy(col.gameObject);
                return;

                case "Star":
                GameManager.Instance.scoreAmount += 100;
                Destroy(col.gameObject);
                return;

                case "OffScreen":
                onGameOver.Invoke();
                return;
            }

            SpriteRenderer spriteRend = col.GetComponent<SpriteRenderer>();
            if (spriteRend != null &&
               spriteRend.color != rend.color)
            {
                Debug.Log("GAME OVER!");
                onGameOver.Invoke();
            }
        }

        

        void RandomizeColor()
        {
            Color startCol = rend.color;
            int index = Random.Range(0, 4);
            if(colors[index] == startCol)
            {
                RandomizeColor();
                return;
            }
            rend.color = colors[index];
        }
    }
}