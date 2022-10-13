using Raylib_cs;

namespace HelloWorld
{
    static class Program
    {
        public static void Main()
        {
            string Score = "0";
            Raylib.InitWindow(800, 480, "Hello World");

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                Raylib.DrawText("SCORE: " + Score, 330, 20, 30, Color.BLACK);

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}