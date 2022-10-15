string[] registers = new string[8];

Console.Write("Podaj zawartość rejestru AL: ");
registers[0] = RegisterCheck();
Console.Write("Podaj zawartość rejestru AH: ");
registers[1] = RegisterCheck();
Console.Write("Podaj zawartość rejestru BL: ");
registers[2] = RegisterCheck();
Console.Write("Podaj zawartość rejestru BH: ");
registers[3] = RegisterCheck();
Console.Write("Podaj zawartość rejestru CL: ");
registers[4] = RegisterCheck();
Console.Write("Podaj zawartość rejestru CH: ");
registers[5] = RegisterCheck();
Console.Write("Podaj zawartość rejestru DL: ");
registers[6] = RegisterCheck();
Console.Write("Podaj zawartość rejestru DH: ");
registers[7] = RegisterCheck();

Console.WriteLine($"AL= {registers[0]}, AH= {registers[1]}, BL= {registers[2]}, BH= {registers[3]}, CL= {registers[4]}, CH= {registers[5]}, DL= {registers[6]}, DH= {registers[7]}");

string RegisterCheck()
{
    string x = Console.ReadLine();
    while ((x[0] < '0' || (x[0] > '9' && x[0] < 'A') || x[0] > 'F') /*2 przypadek*/ || (x[1] < '0' || (x[1] > '9' && x[1] < 'A') || x[1] > 'F') /*3 przypadek*/ || (x.Length != 2))
    {
        Console.Write("Blednie podana wartosc. Podaj zawartosc rejestru: ");
        x = Console.ReadLine();
    }
    return x;
}

