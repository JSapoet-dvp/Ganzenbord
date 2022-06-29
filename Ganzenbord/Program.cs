using Ganzenbord;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, welcome!");


/*
De speciale plaatsen zijn:
• X 23 (now 58) gevangenis: Het spel is over
• X 63 is finish. Het spel is gewonnen.(Realiseer eerst dat 64, 65, 66, 67 ook is toegestaan om te winnen.)
• X 25 en 45 is terug naar start.
• X 10, 20, 30, 40, 50 en 60 houdt in dat je het geworpen aantal nog een keer loopt. Deze staat in de beschrijving.


Middel niveau
• X Realiseer dat dat je dan niet uit mag en dat je het aantal teveel geworpen ogen terug moet vanaf 63, is Lastiger
• X Probeer met meerdere spelers te spelen.

Lastig niveau
Realiseer de officiële regels met meerdere spelers. De officiële regels zijn:
• X 6, brug: Ga verder naar 12
• X 19, herberg: Een beurt extra
• 31, put: Wie hier komt moet er blijven tot een andere speler er komt.
• Degene die er het eerst was speelt dan verder.
• 42, doolhof: Terug naar 39
• 52, gevangenis: drie beurten overslaan
• X 58, dood: Terug naar start
• X 63, einde: Wie hier als eerste komt heeft gewonnen

TODO: 
- Special tile after deca-numb moet ook werken (25, 45)
*/




string throwCommand;
int turn = 2;
bool extraTurn = false;
int throwResult;


Console.Write("Hello player 1, please type your name: ");
string name1 = Console.ReadLine().Trim();
Console.Write("Hello player 2, please type your name: ");
string name2 = Console.ReadLine().Trim();
Player p1 = new Player(name1, 0);
Player p2 = new Player(name2, 0);
Console.WriteLine($"Let's play, {p1.Name} and {p2.Name}!");

ContinueNextTurn();


void Play(int spotNum)
{
    string spotnumConsole = spotNum == 0 ? "Start" : spotNum.ToString();
    Console.Write($"You're on {spotnumConsole}, throw the dice(t): ");
    throwCommand = Console.ReadLine().Trim().ToLower();
    if (throwCommand == "t")
    {
        throwResult = throwDice();
        spotNum = spotNum + throwResult;
        Console.WriteLine($"\nYou threw {throwResult}, you're on {spotNum}");
        spotNum = applyRules(spotNum);
        if (turn == 1)
        {
            p1.SpotNum = spotNum;
        } else {
            p2.SpotNum = spotNum;
        }
    } else {
        Console.WriteLine("You didn't type 't'. Sorry, you lost your turn..");
    }
    ContinueNextTurn();
}


void ContinueNextTurn()
{
    if (!extraTurn)
    {
        turn = turn == 1 ? 2 : 1;
    }
    else
    {
        turn = turn == 1 ? 1 : 2;
    }
    string turnName = turn == 1 ? p1.Name : p2.Name;
    Console.WriteLine($"\n\n{turnName}, it's your turn now.");
    int whichSpotNumTurn = turn == 1 ? p1.SpotNum : p2.SpotNum;
    Play(whichSpotNumTurn);
}


int applyRules(int spotNumBase)
{
    string special = "Special spot";
    int newSpotNum;
    bool win;
    extraTurn = false;
    switch (spotNumBase)
    {
        case 6:
            Console.WriteLine($"{special} (tile {spotNumBase}): Bridge!! Take 6 extra steps for free");
            newSpotNum = 12;
            break;
        case 19:
            Console.WriteLine($"{special} (tile {spotNumBase}): You get an extra turn!!");
            extraTurn = true;
            newSpotNum = spotNumBase;
            break;
        case 10:
        case 20:
        case 30:
        case 40:
        case 50:
        case 60:
            Console.WriteLine($"{special} (tile {spotNumBase}):\nDeca-number!! The number you threw counts dubbel. Take twice the amount of steps");
            newSpotNum = spotNumBase + throwResult;
            if (newSpotNum == 63)
            {
                Console.WriteLine($"You're on 63 now, you finished (tile {spotNumBase}):\nCONGRATSSS, you won!");
                win = true;
                GetScore(win);
                newSpotNum = 0;
            }
            break;
        case 25:
        case 45:
            Console.WriteLine($"{special} (tile {spotNumBase}):\nGo back to Start <-");
            newSpotNum = 0;
            break;
        case 58:
            Console.WriteLine($"{special} (tile {spotNumBase}):\nPrison :( Sorry, you lost!\n--GAME OVER--\n");
            win = false;
            GetScore(win);
            return 0;
        case 63:
            Console.WriteLine($"You finished (tile {spotNumBase}):\nCONGRATSSS, you won!");
            win = true;
            GetScore(win);
            newSpotNum = 0;
            break;
        case > 63:
            Console.WriteLine($"{ special} (tile {spotNumBase}):\nToo far! Go back the amount of steps you passed the finish tile 63");
            newSpotNum = 63 - (spotNumBase - 63);
            break;
        default:
            Console.Write("All is normal. ");
            newSpotNum = spotNumBase;
            break;
    }
    return newSpotNum;
}

void GetScore(bool winner)
{
    if (turn == 1 && winner) p1.Score++;
    if (turn == 2 && winner) p2.Score++;
    if (turn == 1 && !winner) p2.Score++;
    if (turn == 2 && !winner) p1.Score++;
    Console.WriteLine($"SCORE:\n-{p1.Name}: {p1.Score}\n-{p2.Name}: {p2.Score}\n\nLet's start a new game!");
    p1.SpotNum = 0;
    p2.SpotNum = 0;
}


int throwDice()
{
    Random randomDice = new Random();
    int dice = randomDice.Next(1, 7);
    return dice;
}



