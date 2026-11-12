//Porter Rasmussen, 11/11/26, Lab 9 Maze #2
Console.Clear();

//Setup
Console.WriteLine("This is a program that will give you a maze, and allow you to navigate it using the arrow keys.");
Console.WriteLine("Each ^ is worth 100 points. Each $ is worth 200 points.");
Console.WriteLine("Watch out for the bad guys (%)! You'll loose if they get you!");
Console.WriteLine("When you get to the '#' you win! Press any key to begin. ");
Console.ReadKey(true);
Console.Clear();
Random rand = new Random();
string[] mapArray = File.ReadAllLines("map.txt");
for (int i = 0; i<mapArray.Length; i++)
{
    Console.WriteLine(mapArray[i]);
}
int cursorX = 0;
int cursorY = 0;
int score = 0;
Console.SetCursorPosition(0, mapArray.Length);
Console.Write($"Score: {score}");
Console.SetCursorPosition(cursorX, cursorY);


//Play the game
bool gameWon = false;
bool gameLost = false;
while (gameWon != true && gameLost != true)
{
    MakeMovementWork();
    BadGuyMove();
    CheckForTreasure();
    if (score >= 1000) OpenDoor();
    if (mapArray[cursorY][cursorX] == '#')
    {
        gameWon = true;
        Console.Clear();
        Console.WriteLine($"Hooray! You did it! Your total score is: {score}.");
    }
    if (mapArray[cursorY][cursorX] == '%')
    {
        gameLost = true;
        Console.Clear();
        Console.WriteLine("You lost! Better luck next time!");
    }
}

void OpenDoor()
{
    char[] row = mapArray[10].ToCharArray();
    row[18] = ' ';
    mapArray[10] = new string(row);
    Console.SetCursorPosition(18, 10);
    Console.Write(' ');

    row = mapArray[9].ToCharArray();
    row[18] = ' ';
    mapArray[9] = new string(row);
    Console.SetCursorPosition(18, 9);
    Console.Write(' ');

    row = mapArray[11].ToCharArray();
    row[18] = ' ';
    mapArray[11] = new string(row);
    Console.SetCursorPosition(18, 11);
    Console.Write(' ');
    Console.SetCursorPosition(cursorX, cursorY);
}


void MakeMovementWork()
{

    ConsoleKey key = Console.ReadKey(true).Key;

    if (key == ConsoleKey.RightArrow)
    {
        if (cursorX < 53 && mapArray[cursorY][cursorX + 1] != '*' && mapArray[cursorY][cursorX + 1] != '|')
        {
            cursorX++;
            Console.SetCursorPosition(cursorX,cursorY);
        }
    }
    else if (key == ConsoleKey.LeftArrow)
    {
        if (cursorX > 0 && mapArray[cursorY][cursorX - 1] != '*' && mapArray[cursorY][cursorX - 1] != '|')
        {
            cursorX--;
            Console.SetCursorPosition(cursorX,cursorY);
        }
    }
    else if (key == ConsoleKey.UpArrow)
    {
        if (cursorY > 0 && mapArray[cursorY - 1][cursorX] != '*' && mapArray[cursorY - 1][cursorX] != '|')
        {
            cursorY--;
            Console.SetCursorPosition(cursorX,cursorY);
        }
    }
    else if (key == ConsoleKey.DownArrow)
    {
        if (cursorY<20 && mapArray[cursorY + 1][cursorX] != '*' && mapArray[cursorY + 1][cursorX] != '|')
        {    
            cursorY++;
            Console.SetCursorPosition(cursorX,cursorY);
        }
    }
}
void CheckForTreasure()
{
    if (mapArray[cursorY][cursorX] == '^')
    {
        score +=100;

        char[] row = mapArray[cursorY].ToCharArray();
        row[cursorX] = ' ';
        mapArray[cursorY] = new string(row);
        Console.SetCursorPosition(cursorX, cursorY);
        Console.Write(' ');

        Console.SetCursorPosition(0, mapArray.Length);
        Console.Write($"Score: {score}");
        Console.SetCursorPosition(cursorX, cursorY);
    }
    if (mapArray[cursorY][cursorX] == '$')
    {
        score +=200;

        char[] row = mapArray[cursorY].ToCharArray();
        row[cursorX] = ' ';
        mapArray[cursorY] = new string(row);
        Console.SetCursorPosition(cursorX, cursorY);
        Console.Write(' ');

        Console.SetCursorPosition(0, mapArray.Length);
        Console.Write($"Score: {score}");
        Console.SetCursorPosition(cursorX, cursorY);
    }
}

void BadGuyMove()
{
    for (int y = 0; y < mapArray.Length; y++)
    {
        for (int x = mapArray[y].Length - 1; x > 0; x--)
        {
            if (mapArray[y][x] == '%')
            {
                int direction = rand.Next(4);

                switch (direction)
                {
                    case 0: if (mapArray[y][x + 1] == ' '&& x < mapArray[y].Length - 1)
                    {
                        char[] row = mapArray[y].ToCharArray();
                        row[x] = ' ';
                        row[x + 1] = '%';
                        mapArray[y] = new string(row);
                        Console.SetCursorPosition(x, y);
                        Console.Write(' ');
                        Console.SetCursorPosition(x + 1, y);
                        Console.Write('%');
                    }; break; // right
                    case 1: if (mapArray[y][x - 1] == ' ' && x>0)
                    {
                        char[] row = mapArray[y].ToCharArray();
                        row[x] = ' ';
                        row[x - 1] = '%';
                        mapArray[y] = new string(row);
                        Console.SetCursorPosition(x, y);
                        Console.Write(' ');
                        Console.SetCursorPosition(x - 1, y);
                        Console.Write('%');
                    }; break; // left
                    case 2: if (mapArray[y-1][x] == ' ' && y < mapArray.Length - 1)
                    {
                        char[] currentRow = mapArray[y].ToCharArray();
                        char[] nextRow = mapArray[y - 1].ToCharArray();
                        currentRow[x] = ' ';
                        nextRow[x] = '%';
                        mapArray[y] = new string(currentRow);
                        mapArray[y - 1] = new string(nextRow);
                        Console.SetCursorPosition(x, y);
                        Console.Write(' ');
                        Console.SetCursorPosition(x, y-1);
                        Console.Write('%');
                    }; break; // up
                    case 3: if (mapArray[y+1][x] == ' ' && y>0)
                    {
                        char[] currentRow = mapArray[y].ToCharArray();
                        char[] nextRow = mapArray[y + 1].ToCharArray();
                        currentRow[x] = ' ';
                        nextRow[x] = '%';
                        mapArray[y] = new string(currentRow);
                        mapArray[y + 1] = new string(nextRow);
                        Console.SetCursorPosition(x, y);
                        Console.Write(' ');
                        Console.SetCursorPosition(x, y+1);
                        Console.Write('%');
                    }; break; // down
                }
                
            }
        }
    }
    Console.SetCursorPosition(cursorX, cursorY);
}
