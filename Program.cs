string[] registers = new string[8];
string[] registers_names = new string[8];

registers_names[0] = "AL";
registers_names[1] = "AH";
registers_names[2] = "BL";
registers_names[3] = "BH";
registers_names[4] = "CL";
registers_names[5] = "CH";
registers_names[6] = "DL";
registers_names[7] = "DH";

registers[0] = "01";
registers[1] = "02";
registers[2] = "03";
registers[3] = "04";
registers[4] = "05";
registers[5] = "06";
registers[6] = "07";
registers[7] = "08";

//pobieram wartości rejestrów

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

ReadRegisters(registers);

Choose(registers);





//-------------- funkcje pomocnicze ------------------

void Choose(string[] registers)
{
    while (true)
    {
        Console.WriteLine(" ");
        Console.WriteLine("Wybierz jakie polecenie ma zostac wykonane:");
        Console.WriteLine("0 - wyjdz z programu");
        Console.WriteLine("1 - wypisz wartosci w rejestrach");
        Console.WriteLine("2 - MOV");
        Console.WriteLine("3 - ADD");
        Console.WriteLine("4 - SUB");

        int num = int.Parse(Console.ReadLine());

        if (num == 0)
        {
            break;
        }

        switch (num)
        {
            case 1:
                ReadRegisters(registers);
                break;

            case 2:
                Mov(registers);
                break;

            case 3:
                Add(registers, registers_names);
                break;

            case 4:
                Sub(registers, registers_names);
                break;
        }
    }
}

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

void Mov (string[] registers)
{
    Console.Write("Podaj nazwę pierwszego rejestru: ");
    string first = NameCheck();
    Console.Write("Podaj nazwę drugiego rejestru: ");
    string second = NameCheck();

    string x = "0";

    switch (first)
    {
        case "AL" :
            x = registers[0];
            break;
        
        case "AH" :
            x = registers[1];
            break;

        
        case "BL" :
            x = registers[2];
            break;

        case "BH" :
            x = registers[3];
            break;
        
        case "CL" :
            x = registers[4];
            break;
        
        case "CH" :
            x = registers[5];
            break;
        
        case "DL" :
            x = registers[6];
            break;
        
        case "DH" :
            x = registers[7];
            break;
    }

    switch (second)
    {
        case "AL" :
            registers[0] = x;
            break;
        
        case "AH" :
            registers[1] = x;
            break;

        
        case "BL" :
            registers[2] = x;
            break;

        case "BH" :
            registers[3] = x;
            break;
        
        case "CL" :
            registers[4] = x;
            break;
        
        case "CH" :
            registers[5] = x;
            break;
        
        case "DL" :
            registers[6] = x;
            break;
        
        case "DH" :
            registers[7] = x;
            break;
    }



}


string NameCheck()
{
    string x = Console.ReadLine();
    while((!(x[0] >= 'A' && x[0] <= 'D')) || (x[1] != 'H' && x[1] != 'L') || x.Length != 2) 
    {
        Console.Write("Blednie podana nazwa. Podaj nazwe rejestru: ");
        x = Console.ReadLine();
    }
    return x;
}

void ReadRegisters(string[] registers)
{
    Console.WriteLine($"AL= {registers[0]}, AH= {registers[1]}, BL= {registers[2]}, BH= {registers[3]}, CL= {registers[4]}, CH= {registers[5]}, DL= {registers[6]}, DH= {registers[7]}");
    Thread.Sleep(1000);
}
    
void Add(string[] registers, string[] registers_names)
{

    Console.Write("Pierwszy skladnik dodawania: ");
    string x = NameCheck();
    int a = 0;
    while (registers_names[a] != x)
    {
        a++;
    }
    string first = registers[a];

    Console.Write("Drugi skladnik dodawania: ");
    string y = NameCheck();
    int b = 0;
    while (registers_names[b] != y)
    {
        b++;
    }
    string second = registers[b];


    int value1 = Int32.Parse(first, System.Globalization.NumberStyles.HexNumber);
    int value2 = Int32.Parse(second, System.Globalization.NumberStyles.HexNumber);

    int value = value1 + value2;


    string hex = value.ToString("X");
   

    

    registers[a] = hex;

    Console.WriteLine($"Po dodaniu rejestru {registers_names[a]} = {first} do rejestru {registers_names[b]} = {second} otrzymujemy {registers[a]}. ");
}

void Sub(string[] registers, string[] registers_names)
{
    Console.Write("Odjemna: ");
    string x = NameCheck();
    int a = 0;
    while (registers_names[a] != x)
    {
        a++;
    }
    string first = registers[a];

    Console.Write("Odjemnik: ");
    string y = NameCheck();
    int b = 0;
    while (registers_names[b] != y)
    {
        b++;
    }
    string second = registers[b];

    int value1 = Int32.Parse(first, System.Globalization.NumberStyles.HexNumber);
    int value2 = Int32.Parse(second, System.Globalization.NumberStyles.HexNumber);

    if (value1 < value2 )
        Console.WriteLine("Nie obsluguje liczb ujemnych");

    else
    {
        int value = value1 - value2;

        string hex = value.ToString("X");

        registers[a] = hex;

        Console.WriteLine($"Odjemna ({registers_names[a]}) = {first}, odjemnik ({registers_names[b]}) = {second}, roznica ({registers_names[a]}) = {hex}.");

    }
    

}