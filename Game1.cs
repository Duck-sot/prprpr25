using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace prprpr25;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Player player;
    private Texture2D spaceShip; 
    private List<Enemy> enemies = new List<Enemy>();
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        spaceShip = Content.Load<Texture2D>(assetName:"spaceShip");

        player = new Player(spaceShip, new Vector2(380,350),50);
        

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        
        player.Update();
        foreach(Enemy enemy in enemies){
            enemy.Update();
        }
        EnemyBulletColition();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(26, 40, 48));

        _spriteBatch.Begin();
        player.Draw(_spriteBatch);
        foreach(Enemy enemy in enemies){
        enemy.Draw(_spriteBatch);
        }
        SpawnEnemy();
        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
    private void SpawnEnemy(){
        Random rand = new  Random();
        int value = rand.Next(1,101);
        int SpawnChance = 5; 
        if(value<=SpawnChance){
            enemies.Add(new Enemy(spaceShip));
        }
    }

    private void EnemyBulletColition(){
        for(int  i = 0; i < enemies.Count; i++){
            for (int j = 0; j < player.Bullets.Count; j++){
                if(enemies[i].Hitbox.Intersects(player.Bullets[j].Hitbox)){
                    enemies.RemoveAt(i);
                    player.Bullets.RemoveAt(j);
                    i--;
                    j--;
                }
                
            }
        }
    }
}
