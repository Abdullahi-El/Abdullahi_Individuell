
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Välkommen till vår räkneapplikation!");


app.MapGet("/add", (int num1, int num2) => AddNumbers(num1, num2));
app.MapGet("/subtract", (int num1, int num2) => SubtractNumbers(num1, num2));
app.MapGet("/division", (int num1, int num2) => DivideNumbers(num1, num2));
app.MapGet("/multiplication", (int num1, int num2) => MultiplyNumbers(num1, num2));

app.MapGet("/encryptNumbers", (string numbers) => EncryptNumbers(numbers));
app.MapGet("/decryptNumbers", (string numbers) => DecryptNumbers(numbers));



app.Run();

string AddNumbers(int num1, int num2)
{
    return $"Summan av {num1} och {num2} = {num1 + num2}.";
}

string SubtractNumbers(int num1, int num2)
{
    return $"Skillnaden mellan {num1} och {num2} = {num1 - num2}.";
}

string DivideNumbers(int num1, int num2)
{
    if (num2 == 0)
        return "Division med noll är inte tillåten.";
    return $"Kvoten av {num1} och {num2} = {num1 / num2}.";
}

string MultiplyNumbers(int num1, int num2)
{
    return $"Produkten av {num1} och {num2} ={num1 * num2}.";
}

string EncryptNumbers(string numbers)
{
    return string.Concat(numbers.Select(c => EncryptDigit(c)));
}

string DecryptNumbers(string numbers)
{
    return string.Concat(numbers.Select(c => DecryptDigit(c)));
}

char EncryptDigit(char digit)
{
    if (!char.IsDigit(digit)) return digit; // Säkerställer att bara siffror behandlas
    int shift = 3;
    int encryptedDigit = ((digit - '0' + shift) % 10) + '0';
    return (char)encryptedDigit;
}

char DecryptDigit(char digit)
{
    if (!char.IsDigit(digit)) return digit; // Säkerställer att bara siffror behandlas
    int shift = 3;
    int decryptedDigit = ((digit - '0' - shift + 10) % 10) + '0';
    return (char)decryptedDigit;
}

//hej//