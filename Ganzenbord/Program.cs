// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

/*
De speciale plaatsen zijn:
• 23 gevangenis: Het spel is over.
• 63 is finish. Het spel is gewonnen.(Realiseer eerst dat 64, 65, 66, 67
• ook is toegestaan om te winnen.)
• 25 en 45 is terug naar start.
• 10, 20, 30, 40, 50 en 60 houdt in dat je het geworpen aantal nog een
• keer loopt. Deze staat in de beschrijving.


Middel niveau
• Realiseer dat dat je dan niet uit mag en dat je het aantal teveel geworpen ogen terug moet
vanaf 63, is Lastiger
• Probeer met meerdere spelers te spelen.

Lastig niveau
Realiseer de officiële regels met meerdere spelers. De officiële regels zijn:
• 6, brug: Ga verder naar 12
• 19, herberg: Een beurt overslaan
• 31, put: Wie hier komt moet er blijven tot een andere speler er komt.
• Degene die er het eerst was speelt dan verder.
• 42, doolhof: Terug naar 39
• 52, gevangenis: drie beurten overslaan
• 58, dood: Terug naar start
• 63, einde: Wie hier als eerste komt heeft gewonnen
*/




string throwCommand;
int spotNum = 0;
int throwResult;
Play();


void Play()
{
    string spotnumConsole = spotNum == 0 ? "Start" : spotNum.ToString();
    Console.Write($"You're on {spotnumConsole}, throw the dice(g): ");
    throwCommand = Console.ReadLine().Trim().ToLower();
    if (throwCommand == "g")
    {
        throwResult = throwDice();
        spotNum = spotNum + throwResult;
        Console.WriteLine($"\nYou threw {throwResult}, you're on {spotNum}");
        spotNum = applyRules(spotNum);
    }
    ContinueNextStep();
}

void ContinueNextStep()
{
    Play();
}


int applyRules(int spotNumBase)
{
    string special = "Special spot";
    int newSpotNum;
    switch (spotNumBase)
    {
        case 6:
            Console.WriteLine($"{special} (tile {spotNumBase}): Bridge!! Take 6 extra steps for free");
            newSpotNum = 12;
            break;
        case 10:
        case 20:
        case 30:
        case 40:
        case 50:
        case 60:
            Console.WriteLine($"{special} (tile {spotNumBase}):\nDeca-number!! The number you threw counts dubbel. Take twice the amount of steps");
            newSpotNum = spotNum + throwResult;
            break;
        case 23:
            Console.WriteLine($"{special} (tile {spotNumBase}):\nPrison :(\n--GAME OVER--\n");
            newSpotNum = 0;
            break;
        case 25:
        case 45:
            Console.WriteLine($"{special} (tile {spotNumBase}):\nGo back to Start <-");
            newSpotNum = 0;
            break;
        case 63:
        case 64:
        case 65:
        case 66:
        case 67:
            Console.WriteLine($"You finished (tile {spotNumBase}):\nCONGRATSSS!\n\n Let's start a new game!");
            newSpotNum = 0;
            break;
        default:
            Console.Write("All is normal. ");
            newSpotNum = spotNumBase;
            break;
    }
    return newSpotNum;
}


int throwDice()
{
    Random randomDice = new Random();
    int dice = randomDice.Next(1, 6);
    return dice;
}



