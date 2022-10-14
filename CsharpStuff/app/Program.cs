using Raylib_cs;
using System;
using System.Numerics;


namespace HelloWorld
{
    static class Program
    {
        public static void Main()
        {
            string Score = "0";
            Raylib.InitWindow(800, 480, "Snake");
            int GameState = 0;
            Raylib.SetTargetFPS(60);
            int FacingTo = 0;

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
                else {
                    Raylib.ClearBackground(Color.BLACK);

                    // Main game

                    Vector2 SHpos = new Vector2(330, Raylib.GetScreenHeight()/2);
                    Raylib.DrawRectangle((int)(SHpos.X), (int)(SHpos.Y), 30, 30, Color.YELLOW);
                    Rectangle Head = new Rectangle((int)(SHpos.X), (int)(SHpos.Y), 30, 30);
                    Raylib.DrawRectangleLinesEx(Head, (float)3.5, Color.ORANGE);

                    if (FacingTo == 0) {
                        SHpos = new Vector2(SHpos.X + 1.0/60.0, SHpos.Y);
                    }

                }


                Raylib.EndDrawing();

            }
            Raylib.CloseWindow();
        }
    }
}
