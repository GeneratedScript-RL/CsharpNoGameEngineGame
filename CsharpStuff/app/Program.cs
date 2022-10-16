using Raylib_cs;
using System;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.KeyboardKey;
using static Raylib_cs.Color;
using System.Threading.Tasks;
namespace Snake
{

    
    class Program
    {
        
        public Vector2 GetV2Pos() {
                System.Random random = new System.Random(); 
                int PosXNew = random.Next(1, Raylib.GetScreenWidth());
                int PosYNew = random.Next(1, Raylib.GetScreenHeight());
                return new Vector2(PosXNew, PosYNew);
            }

        public static void Main()
        {

            

            bool IsFood = false;
            string Score = "0";
            Raylib.InitWindow(800, 480, "Snake");
            int GameState = 0;
            Raylib.SetTargetFPS(60);
            int FacingTo = 0;
            Vector2 SHpos = new Vector2(330, Raylib.GetScreenHeight()/2);
            Vector2 OrginPos = new Vector2(330, Raylib.GetScreenHeight()/2);

            System.Random random = new System.Random(); 
            int PosXNew = random.Next(1, Raylib.GetScreenWidth());
            int PosYNew = random.Next(1, Raylib.GetScreenHeight());

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                if (GameState == 0) {

                    Raylib.ClearBackground(Color.BLACK);

                    Raylib.DrawText("SCORE: " + Score, 330, 20, 20, Color.GREEN);

                    Raylib.DrawRectangle(330, Raylib.GetScreenHeight()/2, 115, 30, Color.BLACK);
                    Raylib.DrawText("START", 330, Raylib.GetScreenHeight()/2, 30, Color.WHITE);

                    Rectangle rect = new Rectangle(330, Raylib.GetScreenHeight()/2, 115, 30);

                    // Gui handling

                    if(Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON)) {
                        Vector2 mousePos = new Vector2(Raylib.GetMousePosition().X, Raylib.GetMousePosition().Y);
                    
                        if (Raylib.CheckCollisionPointRec(mousePos, rect)) {
                            Raylib.BeginDrawing();
                            GameState = 1;
                            Raylib.EndDrawing();
                        }

                    }

                }
                else if (GameState == 1) {
                    Raylib.ClearBackground(Color.BLACK);

                    // Main game

                    
                    Raylib.DrawRectangle((int)(SHpos.X), (int)(SHpos.Y), 30, 30, Color.YELLOW);
                    Rectangle Head = new Rectangle((int)(SHpos.X), (int)(SHpos.Y), 30, 30);
                    Raylib.DrawRectangleLinesEx(Head, (float)3.5, Color.ORANGE);


                    // Controls 
                    if (FacingTo == 0) {
                        SHpos.X += 80.0f*Raylib.GetFrameTime();

                    }
                    else if (FacingTo == 1) {
                        SHpos.X -= 80.0f*Raylib.GetFrameTime();

                    }
                    else if (FacingTo == 2) {
                        SHpos.Y += 80.0f*Raylib.GetFrameTime();

                    }
                    else if (FacingTo == 3) {
                        SHpos.Y -= 80.0f*Raylib.GetFrameTime();

                    }

                    if (IsKeyDown(KEY_W)) {
                        FacingTo = 3;
                    }
                    if (IsKeyDown(KEY_S)) {
                        FacingTo = 2;
                    }
                    if (IsKeyDown(KEY_A)) {
                        FacingTo = 1;
                    }
                    if (IsKeyDown(KEY_D)) {
                        FacingTo = 0;
                    }

                    //Controls ^^

                    if ((int)SHpos.X >= (int)Raylib.GetScreenWidth() || (int)SHpos.X <= 0 || (int)SHpos.Y <= 0 || (int)SHpos.Y >= (int)Raylib.GetScreenHeight()) {
                        GameState = 2;
                    }

                    if (IsFood == false) {
                        Raylib.DrawRectangle(PosXNew, PosYNew, 30, 30, Color.RED);
                        IsFood = true;
                    }

                }
                else if (GameState == 2) {
                    Raylib.ClearBackground(Color.BLACK);
                    Raylib.DrawText("SCORE: " + Score, 330, 20, 20, Color.GREEN);
                    Raylib.DrawText("YOU LOST", 315, Raylib.GetScreenHeight()/2, 30, Color.RED);
                    Raylib.DrawText("Retry?", 340, (Raylib.GetScreenHeight()/2)+60, 30, Color.YELLOW);
                    Rectangle RetryButton = new Rectangle(340, (Raylib.GetScreenHeight()/2)+60, 120, 30);

                    if(Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON)) {
                        Vector2 mousePos = new Vector2(Raylib.GetMousePosition().X, Raylib.GetMousePosition().Y);
                    
                        if (Raylib.CheckCollisionPointRec(mousePos, RetryButton)) {
                            GameState = 1;
                            SHpos = OrginPos;
                        }
                    }

                }

                Raylib.EndDrawing();

            }
            Raylib.CloseWindow();
        }
    }
}
