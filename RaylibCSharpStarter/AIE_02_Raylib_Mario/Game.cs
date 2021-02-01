using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_02_Raylib_Mario
{
    class Game
    {
        public int windowWidth = 800;
        public int windowHeight = 450;
        public string windowTitle = "Mario Walkthrough";

        Texture2D marioTexture;
        float marioXPos = 400;
        float marioYPos = 200;
        float marioWidth = 32;
        float marioHeight = 32;

        Texture2D crateTexture;
        float crateXPos = 0
        float crateYPos = 428
        float crateWidth = 32
        float crateHeight = 32
        

        float marioSpeed = 3;
        float gravity = 10;

        float jumpForce = 20;
        float resetJumpForce = 20;

        //hello

        public void LoadGame()
        {
            // TODO: Load game assets here
            marioTexture = Raylib.LoadTexture("./assets/mario_1.png");
            crateTexture = Raylib.LoadTexture("./assets/crate_1.png");
        }

        public void Update(float deltaTime)
        {
            // move mario
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                marioXPos -= marioSpeed;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                marioXPos += marioSpeed;
            }
            // teleport mario from one side of the screen to the other
            if ( marioXPos > windowWidth )
            {
                marioXPos = 0;
            }
            if (marioXPos < 0)
            {
                marioXPos = windowWidth;
            }
            // mario jump
            if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
            {
                marioYPos -= jumpForce;
                jumpForce -= 1;
                else (jumpForce = 10)
                {
                    jumpForce = resetJumpForce;
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
                    {
                        marioYPos -= jumpForce;
                        jumpForce -= 1;
                    }
                }
            }

            //make mario fall
            marioYPos += gravity;

            if( marioYPos > windowHeight )
            {
                marioYPos = windowHeight;
                jumpForce = resetJumpForce;
            }
            if( marioYPos > crateYPos )
            {
                marioYPos = crateYPos;
                jumpForce = resetJumpForce;
            }
            
        }

        public void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RAYWHITE);

            // TODO: Drawing related logic here

            // draws some text
            Raylib.DrawText("Mario", 10, 10, 32, Color.DARKGRAY);

            // draws a rotating texture in center of screen
            RayLibExt.DrawTexture(marioTexture, marioXPos, marioYPos, marioWidth, marioHeight,
                Color.WHITE, 0, 0.5f, 1.0f);

            RayLibExt.DrawTexture(crateTexture, crateXPos, crateYPos, crateWidth, crateHeight,
                Color.WHITE, 0, 0.5f, 1.0f);

            Raylib.EndDrawing();
        }
    }
}
