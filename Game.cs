// Include code libraries you need below (use the namespace).
using Raylib_cs;
using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        bool isClownPresent = false;
        int pupilPositionModifierX = 0;
        int pupilPositionModifierY = 0;
        int clownWidthCount = 1;
        int clownHeightCount = 1;
        float positionOfClownX = 400;
        float positionOfClownY = 300;




        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Interatction");
            Window.SetSize(800, 600);

            Window.TargetFPS = 60;
            
            
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            //Track Mouse Location
            float mouseX = Input.GetMouseX();
            float mouseY = Input.GetMouseY();
            
            




            if (isClownPresent)
            {
                Window.ClearBackground(Color.Black);


                if (Input.IsKeyboardKeyReleased(KeyboardInput.Left))
                {
                    clownWidthCount--;
                }
                if (Input.IsKeyboardKeyReleased(KeyboardInput.Right))
                { 
                    clownWidthCount++;
                }

                if (Input.IsKeyboardKeyReleased(KeyboardInput.Up))
                {
                    clownHeightCount--;
                }
                if (Input.IsKeyboardKeyReleased(KeyboardInput.Down))
                {
                    clownHeightCount++;
                }


                //Page Swap Button
                Draw.LineColor = Color.Black;
                Draw.FillColor = Color.DarkGray;
                Draw.Square(765, 0, 35);
                Draw.FillColor = Color.Red;
                Draw.Square(775, 0, 25);

                if (mouseX > 765 && mouseX <= 800 && mouseY <= 25)
                {
                    Draw.FillColor = new Color(255, 150, 150);
                    Draw.Square(775, 0, 25);
                }


                //Clown Amount
                for (int i = 0; i < clownWidthCount; i++)
                {
                    for (int j = 0; j < clownHeightCount; j++)
                    {
                        positionOfClownX = i * 100;
                        positionOfClownY = j * 100;


                        //Special Clown
                        //Follow Mouse to top left.
                        if (mouseX <= 400 && mouseY <= 300)
                        {
                            pupilPositionModifierX = -5;
                            pupilPositionModifierY = -5;
                        }
                        //Follow mouse to top right.
                        if (mouseX >= 401 && mouseY <= 300)
                        {
                            pupilPositionModifierX = 5;
                            pupilPositionModifierY = -5;
                        }
                        //Follow mouse to bottom right.
                        if (mouseX >= 301 && mouseY >= 301)
                        {
                            pupilPositionModifierX = 5;
                            pupilPositionModifierY = 5;
                        }
                        //Follow mouse to bottom left.
                        if (mouseX <= 400 && mouseY >= 301)
                        {
                            pupilPositionModifierX = -5;
                            pupilPositionModifierY = 5;
                        }



                        DrawClown(100 + positionOfClownX, 150 + positionOfClownY);
                        Draw.FillColor = Color.Black;
                        Draw.Circle(100 + positionOfClownX - 15, 150 + positionOfClownY - 90, 15);
                        Draw.FillColor = Color.Black;
                        Draw.Circle(100 + positionOfClownX + 15, 150 + positionOfClownY - 90, 15);
                        Draw.FillColor = Color.White;
                        Draw.Circle(100 + positionOfClownX - 15 + pupilPositionModifierX, 150 + positionOfClownY - 90 + pupilPositionModifierY, 5);
                        Draw.Circle(100 + positionOfClownX + 15 + pupilPositionModifierX, 150 + positionOfClownY - 90 + pupilPositionModifierY, 5);
                        Draw.FillColor = Color.Red;
                        Draw.Circle(100 + positionOfClownX, 150 + positionOfClownY - 80, 7);

                        DrawClown(700 + -(positionOfClownX), 450 + -(positionOfClownY));
                        Draw.FillColor = Color.Black;
                        Draw.Circle(700 + -(positionOfClownX) - 15, 450 + -(positionOfClownY) - 90, 15);
                        Draw.FillColor = Color.Black;
                        Draw.Circle(700 + -(positionOfClownX) + 15, 450 + -(positionOfClownY) - 90, 15);
                        Draw.FillColor = Color.White;
                        Draw.Circle(700 + -(positionOfClownX) - 15 + pupilPositionModifierX, 450 + -(positionOfClownY) - 90 + pupilPositionModifierY, 5);
                        Draw.Circle(700 + -(positionOfClownX) + 15 + pupilPositionModifierX, 450 + -(positionOfClownY) - 90 + pupilPositionModifierY, 5);
                        Draw.FillColor = Color.Red;
                        Draw.Circle(700 + -(positionOfClownX), 450 + -(positionOfClownY) - 80, 7);


                    }

                    if (Input.IsMouseButtonDown(MouseInput.Right))
                    {
                        DrawClown(mouseX, mouseY);
                    }

                
                }

               

                if (Input.IsMouseButtonDown(MouseInput.Right))
                {
                    positionOfClownX = mouseX;
                    positionOfClownY = mouseY;
                }

                if (Input.IsMouseButtonReleased(MouseInput.Left) && mouseX > 775 && mouseX <= 800 && mouseY > 0 && mouseY <= 25)
                {
                    isClownPresent = false;
                }
            }

            else
            {
                //Page Swap Button
                Draw.LineColor = Color.Black;
                Draw.FillColor = Color.DarkGray;
                Draw.Square(0, 0, 35);
                Draw.FillColor = Color.Red;
                Draw.Square(0, 0, 25);

                if (mouseX > 0 && mouseX <= 25 && mouseY <= 25)
                {
                    Draw.FillColor = new Color(255, 150, 150);
                    Draw.Square(0, 0, 25);
                }

                if (Input.IsMouseButtonDown(MouseInput.Left))
                {
                    Draw.LineColor = Color.White;
                    Draw.FillColor = Color.White;
                    Draw.Square(mouseX, mouseY, 10);
                }
            }

            if (Input.IsMouseButtonReleased(MouseInput.Left) && mouseX > 0 && mouseX <= 25 && mouseY > 0 && mouseY <= 25)
            {
                isClownPresent = true;
            }
            
        }

        void DrawClown(float x, float y)
        {
            //Clown Hair
            Draw.FillColor = Color.Blue;
            Draw.Circle(x - 37, y - 85, 25);
            Draw.Circle(x + 37, y - 85, 25);
            Draw.Circle(x - 40, y - 100, 25);
            Draw.Circle(x + 40, y - 100, 25);
            Draw.Circle(x - 32, y - 112, 25);
            Draw.Circle(x + 32, y - 112, 25);

            //Clown Head
            Draw.FillColor = Color.White;
            Draw.Ellipse(x, y - 85, 70, 75);

            //Clown Smile
            Draw.FillColor = Color.Magenta;
            Draw.LineColor = Color.White;
            Draw.Circle(x, y - 80, 15);
            Draw.FillColor = Color.White;
            Draw.Rectangle(x - 25, y - 84, 50, 10);
            
            Draw.LineColor = Color.Black;

            //Clown Torso
            Draw.FillColor = Color.Yellow;
            Draw.Quad(x - 35, y - 55, x + 35, y - 55, x + 40, y + 45, x - 40, y + 45);

            //Clown Puffs
            Draw.FillColor = Color.Magenta;
            Draw.Circle(x, y - 35, 10);
            Draw.Circle(x, y - 5, 10);
            Draw.Circle(x, y + 25, 10);

            //Clown Neck Fluff
            Draw.FillColor = Color.Red;
            Draw.Rectangle(x - 40, y - 65, 80, 15);

            //Clown eyeballs
            Draw.FillColor = Color.Black;
            Draw.Circle(x - 15, y - 90, 15);
            Draw.FillColor = Color.Black;
            Draw.Circle(x + 15, y - 90, 15);

            //Clown Pupil
            Draw.FillColor = Color.White;
            Draw.Circle(x - 15, y - 90, 5);
            Draw.FillColor = Color.White;
            Draw.Circle(x + 15, y - 90, 5);

            //Clown Nose
            Draw.FillColor = Color.Red;
            Draw.Circle(x, y - 80, 7);

        }
    }
}
