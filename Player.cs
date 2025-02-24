
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;

namespace prprpr25
{
    public class Player
    {
        private Texture2D texture;
        private Vector2 position; 
        private Rectangle hitbox; 
        private KeyboardState newkstate;
        private KeyboardState oldkstate;
        private int hp; 
        private List<Bullet> bullets = new List<Bullet>();
        public List<Bullet> Bullets{
            get{return bullets;}
        }
        public int Hp{
            get{return hp;}
            set{hp = value;}
        }
        public Player(Texture2D texture, Vector2 position,int pixelSize,int hp){ 
            this.texture = texture;
            this.position=position;
            hitbox = new Rectangle((int)position.X,(int)position.Y,pixelSize,pixelSize);
            this.hp=hp;
        }
        public void Update(){
            newkstate = Keyboard.GetState(); 
            Move();
            Shoot();
            oldkstate = newkstate; 
            foreach(Bullet b in bullets){
                b.Update();
            }
        }
        public Rectangle Hitbox{
            get{return hitbox;}
        }

        private void Shoot(){
            
            if(newkstate.IsKeyDown(Keys.Space)&& oldkstate.IsKeyUp(Keys.Space)){
                Bullet bullet = new Bullet(texture,position);
                bullets.Add(bullet);
            }
        }
        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture,hitbox,Color.DodgerBlue);
            foreach(Bullet b in bullets){
                b.Draw(spriteBatch);
            }
        }
        private void Move(){
            if(newkstate.IsKeyDown(Keys.A)){
                position.X -= 5; 
            }
            else if(newkstate.IsKeyDown(Keys.D)){
                position.X +=5; 
            }
            if(newkstate.IsKeyDown(Keys.W)){
                position.Y -= 5; 
            }
            if(newkstate.IsKeyDown(Keys.S)){
                position.Y += 5; 
            }
            hitbox.Location = position.ToPoint(); 
        }
    }
}