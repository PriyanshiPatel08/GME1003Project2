using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GME1003Project2
{
    public class Ball
    {
        private float x;
        private float y;
        private float speed;
        private bool isMovingRight;
        private float size;
        private Color color;

        public Ball(float x, float y, float speed)
        {
            this.x = x;
            this.y = y;
            this.speed = speed;
            this.isMovingRight = true;
            this.size = 20.0f;
            this.color = Color.Red;
        }

        public float GetSpeed()
        {
            return speed;
        }

        public bool GetIsMovingRight()
        {
            return isMovingRight;
        }

        public float GetSize()
        {
            return size;
        }

        public void ChangeSize(float change)
        {
            size += change;
            if (size < 10.0f) size = 10.0f;
            if (size > 40.0f) size = 40.0f;
        }

        public void Update(GameTime gameTime, int screenWidth, int screenHeight)
        {
            if (isMovingRight)
            {
                x += speed;
            }
            else
            {
                x -= speed;
            }

            if (x < size)
            {
                x = size;
                isMovingRight = true;
            }
            if (x > screenWidth - size)
            {
                x = screenWidth - size;
                isMovingRight = false;
            }

            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Space))
            {
                ChangeSize(2.0f);
            }
            if (keyboard.IsKeyDown(Keys.LeftShift))
            {
                ChangeSize(-2.0f);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D pixel)
        {
            spriteBatch.Draw(pixel, new Vector2(x - size, y - size), null, color, 0f, Vector2.Zero, size * 2, SpriteEffects.None, 0f);
        }
    }
}