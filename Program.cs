//Porter Rasmussen, 11/11/26, Lab 9 Maze #2
Console.Clear();

//Setup
Console.WriteLine("This is a program that will give you a maze, and allow you to navigate it using the arrow keys. When you get to the '*' you win! Press any key to begin. ");
Console.ReadKey(true);
Console.Clear();
string[] mapArray = File.ReadAllLines("map.txt");
for (int i = 0; i<mapArray.Length; i++)
{
    Console.WriteLine(mapArray[i]);
}
int cursorX = 0;
int cursorY = 0;
Console.SetCursorPosition(cursorX,cursorY);

//Play the game
bool gameWon = false;
while (gameWon != true)
{
    MakeMovementWork();
    if (mapArray[cursorY][cursorX] == '#')
    {
        gameWon = true;
        Console.Clear();
        Console.WriteLine("Hooray! You did it!");
    }
}


void MakeMovementWork()
{

    ConsoleKey key = Console.ReadKey(true).Key;

    if (key == ConsoleKey.RightArrow)
    {
        if (cursorX < 53 && mapArray[cursorY][cursorX + 1] != '*')
        {
            cursorX++;
            Console.SetCursorPosition(cursorX,cursorY);
        }
    }
    else if (key == ConsoleKey.LeftArrow)
    {
        if (cursorX > 0 && mapArray[cursorY][cursorX - 1] != '*')
        {
            cursorX--;
            Console.SetCursorPosition(cursorX,cursorY);
        }
    }
    else if (key == ConsoleKey.UpArrow)
    {
        if (cursorY > 0 && mapArray[cursorY - 1][cursorX] != '*')
        {
            cursorY--;
            Console.SetCursorPosition(cursorX,cursorY);
        }
    }
    else if (key == ConsoleKey.DownArrow)
    {
        if (cursorY<20 && mapArray[cursorY + 1][cursorX] != '*')
        {    
            cursorY++;
            Console.SetCursorPosition(cursorX,cursorY);
        }
    }
}
