int InputNumericValue(string msg)
{
    Console.Write(msg);
    string inputText = Console.ReadLine();
    int inputValue = Convert.ToInt32(inputText);
    return inputValue;
}

string InputTextValue(string msg)
{
    Console.Write(msg);
    string inputText = Console.ReadLine();
    return inputText;
}

int RandomNumber()
{
    int RNumber = new Random().Next(1, 21);
    return RNumber;
}

string GenarateString()
{
    var chars = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюяABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789/*-+";
    int RNumber = RandomNumber();
    var stringChars = new char[RNumber];
    var random = new Random();

    for (int i = 0; i < stringChars.Length; i++)
    {
        stringChars[i] = chars[random.Next(chars.Length)];
    }

    var finalString = new String(stringChars);
    return finalString;
}

string[] CreateStringArray(int LengthStringArray)
{
    bool auto = false;
    if (LengthStringArray == 0)
    {
        LengthStringArray = RandomNumber();
    }
    string[] textArray = new string[LengthStringArray];
    int count = 1;
    for (int i = 0; i < LengthStringArray; i++)
    {
        if (auto)
        {
            textArray[i] = GenarateString();
        }
        else
        {
            count = i + 1;
            string textValue = InputTextValue("Введите значение элемента № " + count + " из " + LengthStringArray + " или пустое значение, чтобы весь массив наполнился случайными значениями слуайной длины: ");
            if (String.IsNullOrEmpty(textValue))
            {
                textArray[i] = GenarateString();
                auto = true;
            }
            else
            {
                textArray[i] = textValue;
            }
        }
    }
    return textArray;
}

string[] CreateSmallArray(string[] textArray)
{
    string[] SmallArray = new string[textArray.Length];
    for (int i = 0; i < SmallArray.Length; i++)
    {
        if (textArray[i].Length > 3)
        {
            SmallArray[i] = null;
        }
        else
        {
            SmallArray[i] = textArray[i];
        }
    }
    return SmallArray;
}

void PrintArray(string[] textArray)
{
    Console.Write("[");
    for (int i = 0; i < textArray.Length; i++)
    {
        if (i == textArray.Length - 1)
        {
            Console.Write("“" + textArray[i] + "”]");
        }
        else
        {
            Console.Write("“" + textArray[i] + "”, ");
        }
    }
}

void PrintSmallArray(string[] SmallArray)
{
    Console.Write("[");
    int count = 0;
    for (int i = 0; i < SmallArray.Length; i++)
    {
        if (String.IsNullOrEmpty(SmallArray[i]))
        {

        }
        else
        {
            if (count == 0)
            {
                Console.Write("“" + SmallArray[i] + "”");
                count++;
            }
            else
            {
                Console.Write(", “" + SmallArray[i] + "”");
            }
        }
    }

    Console.Write("]");
}

int LengthStringArray = InputNumericValue("Введите размер текстового массива. Если введете 0, то сгенерим размер случайным образом от 1 до 20: ");
string[] textArray = CreateStringArray(LengthStringArray);
string[] SmallArray = CreateSmallArray(textArray);
PrintArray(textArray);
Console.Write("   -->   ");
PrintSmallArray(SmallArray);
