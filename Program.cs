

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
            Console.WriteLine("0 - wyjdz z programu, 1 - wypisz wartosci w rejestrach, 2 - MOV, 3 - ADD, 4 - SUB, 5 - XCHG, 6 - INC, 7 - DEC");

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

                case 5:
                    Xchg(registers, registers_names);
                    break;
                    
                case 6:
                    Inc(registers, registers_names);
                    break;

                case 7:
                    Dec(registers, registers_names);
                    break;
            }
        }
    }

    string RegisterCheck()
    {
        string x = Console.ReadLine();
        while ((x.Length != 2) || (x[0] < '0' || (x[0] > '9' && x[0] < 'A') || x[0] > 'F') || (x[1] < '0' || (x[1] > '9' && x[1] < 'A') || x[1] > 'F'))
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

        Console.Write("Pierwsza liczba: ");
        string x = NameCheck();
        int a = 0;
        while (registers_names[a] != x)
        {
            a++;
        }
        string first = registers[a];

        Console.Write("Druga liczba: ");
        string y = NameCheck();
        int b = 0;
        while (registers_names[b] != y)
        {
            b++;
        }
        string second = registers[b];


        int value1 = Int32.Parse(first, System.Globalization.NumberStyles.HexNumber);
        int value2 = Int32.Parse(second, System.Globalization.NumberStyles.HexNumber);

        


        int value =value1 + value2;


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

    void Xchg (string[] registers, string[] registers_names)
        {
            Console.Write("Podaj nazwe pierwszego rejestru: ");
            string first = NameCheck();
            Console.WriteLine("Podaj nazwe drugiego rejestru: ");
            string second = NameCheck();

            int x = -1;

            switch (first)
            {
                case "AL" :
                    x = 0;
                    break;
            
                case "AH" :
                    x = 1;
                    break;

            
                case "BL" :
                    x = 2;
                    break;

                case "BH" :
                    x = 3;
                    break;
            
                case "CL" :
                    x = 4;
                    break;
            
                case "CH" :
                    x = 5;
                    break;
            
                case "DL" :
                    x = 6;
                    break;
            
                case "DH" :
                    x = 7;
                    break;
            }

            int y = -1;

            switch (second)
            {
                case "AL" :
                    y = 0;
                    break;
            
                case "AH" :
                    y = 1;
                    break;

            
                case "BL" :
                    y = 2;
                    break;

                case "BH" :
                    y = 3;
                    break;
            
                case "CL" :
                    y = 4;
                    break;
            
                case "CH" :
                    y = 5;
                    break;
            
                case "DL" :
                    y = 6;
                    break;
            
                case "DH" :
                    y = 7;
                    break;
            }

            string val = registers[x];
            registers[x] = registers[y];
            registers[y] = val;
            
            Console.WriteLine($"Po zamianie wartości w rejestrach {registers_names[x]} = {registers[x]}, a {registers_names[y]} = {registers[y]}");
        }

    void Not(string[] registers, string[] registers_names)   //nie działa
    {
        Console.Write("Podaj nazwę rejestru: ");
        string register = NameCheck();

        string x = "-1";

        switch (register)
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
    
        
        string binaryText = Convert.ToString(Convert.ToInt32(x, 16), 2);
        char[] a = new char[8] {'1', '1', '1', '1', '1', '1', '1', '1'};

    for (int i = 0; binaryText.Length > i ; i++)
    {
            if (binaryText[i] == '1')
            {
                a[8 - binaryText.Length + i] = '0';
            }
            else
            {
                a[8 - binaryText.Length + i] = '1';
            }
    }
    //int x = 2;
    //string hex = Convert.ToInt32(a, x).value.ToString("X");
    
    }

    void Inc(string[] registers, string[] registers_names)
    {
        Console.Write("Podaj nazwe rejestru: ");
        string register = NameCheck();

        int a = 0;
        while (registers_names[a] != register)
            a++;
    
        string first = registers[a];

        if (registers[a] == "FF")
            registers[a] = "00";
        else
        {
        int value = Int32.Parse(first, System.Globalization.NumberStyles.HexNumber);
        value++;
        string hex = value.ToString("X");
        registers[a] = hex;

        if (hex.Length == 1)
            registers[a] = "0" + hex;
        }

        System.Console.WriteLine($"Nowa wartość rejestru {registers_names[a]} = {registers[a]}");
    }

    void Dec(string[] registers, string[] registers_names)
    {
        Console.Write("Podaj nazwe rejestru: ");
        string register = NameCheck();

        int a = 0;
        while (registers_names[a] != register)
            a++;
    
        string first = registers[a];

        if (registers[a] == "00")
            registers[a] = "FF";
        else
        {
        int value = Int32.Parse(first, System.Globalization.NumberStyles.HexNumber);
        value--;
        string hex = value.ToString("X");
        registers[a] = hex;

        if (hex.Length == 1)
            registers[a] = "0" + hex;
        }

        System.Console.WriteLine($"Nowa wartość rejestru {registers_names[a]} = {registers[a]}");

    }

    void And(string[] registers, string[] registers_names)  //nie ma
    {
        Console.Write("Wartość pierwszego rejestru: ");
        string first = NameCheck();
        Console.Write("Wartość drugiego rejestru: ");
        string second = NameCheck();

        int a = 0;
        while (registers_names[a] != register)
            a++;
    
        string first = registers[a];

        int b = 0;
        while (registers_names[b] != register)
            b++;
    
        string second = registers[b];

        int value1 = Int32.Parse(first, System.Globalization.NumberStyles.HexNumber);
        int value2 = Int32.Parse(second, System.Globalization.NumberStyles.HexNumber);

        





    }

    void Or(string[] registers, string[] registers_names)  //nie ma
    {

    }

    void Xor(string[] registers, string[] registers_names)  //nie ma
    {

    }