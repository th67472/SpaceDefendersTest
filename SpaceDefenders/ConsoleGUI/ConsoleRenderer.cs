using System;
using SpaceDefenders;

namespace ConsoleGUI
{
    public class ConsoleRenderer : IRenderer
    {
        int XSize, YSize;
        char[,] Field;

        public ConsoleRenderer(int xSize, int ySize)
        {
            XSize = xSize; YSize = ySize;
            Field = new char[xSize, ySize];
            Clear();
        }

        public void Clear() {
            for (int x = 0; x < XSize; x++) {
                for (int y = 0; y < YSize; y++) {
                    Field[x, y] = ' ';
                }
            }
        }

        public void PutCharAt(Position position, char c) {
            Field[position.X, position.Y] = c;
        }

        public void Display() {
            Console.Clear();

            for (int y = YSize - 1; y >= 0; y--)
            {
                Console.Write("|");
                for (int x = 0; x < XSize; x++)
                {
                    Console.Write(Field[x,y]);
                }
                Console.Write("|\n");
            }
        }

    }
}
