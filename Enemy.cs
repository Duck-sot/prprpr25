using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX;


namespace prprpr25
{
    public class Enemy
    {
        private Texture2D texture; 
        private Microsoft.Xna.Framework.Rectangle hitbox; 
        private Microsoft.Xna.Framework.Vector2 position; 
        private float speed; 
        

        public Enemy(Texture2D texture){
            this.texture = texture;
            Random rand = new Random(); 
            int size = rand.Next(10,50);
            speed = rand.NextFloat(4,50);
            position.X = rand.NextFloat(0,750);
            position.Y = -50; 
            hitbox = new ((int)position.X,(int)position.Y,size,size);
        }
        public void Update(){
            position.Y +=speed*1f/60f;
            hitbox.Location= position.ToPoint();
        }
        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture,hitbox,Microsoft.Xna.Framework.Color.PaleVioletRed);
        }
        public Microsoft.Xna.Framework.Rectangle Hitbox{
            get{return hitbox; }

        }
    }
}