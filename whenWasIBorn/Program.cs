﻿// See https://aka.ms/new-console-template for more information

//Variables

DateTime today = DateTime.Now;
DateTime parsedInputDate;
string inputDate = null;
string onlyDate = null;
bool passedChecks = false;

// Ask for date of birth
Console.WriteLine("Ange ditt födelsedatum i formatet: YYYY-MM-DD");


// Make sure inputs are valid and legit before continue to calculations
while (!passedChecks) {


    // Save input to string
    inputDate = Console.ReadLine();


    // Check if inputDate is in valid format
    if (DateTime.TryParseExact(inputDate,"yyyy-MM-dd",null,System.Globalization.DateTimeStyles.None, out parsedInputDate)){

    // Remove timestamp and only keep date
    onlyDate = parsedInputDate.ToString("yyyy-MM-dd");
    }
    else
    {
        Console.WriteLine("Du måste ange ett korrekt formaterat datum, likt exemplet");
        passedChecks = false;
        //Proceed with code
        continue;
    }
    // Check if date is older than today
    if (parsedInputDate < today)
    {
        passedChecks = true;
    }
    else
    {
        Console.WriteLine("Ange ett datum som är tidigare än idag.");
        passedChecks = false;
         
    }

}

//Calculations

// Split input string into century, year, month and day
string century = onlyDate.Substring(0, 2);
string year = onlyDate.Substring(2, 2);
string month = onlyDate.Substring(5, 2);
string day = onlyDate.Substring(8, 2);

// Convert from string to int
int numCentury = int.Parse(century);
int numYear = int.Parse(year);
int numMonth = int.Parse(month);
int numDay = int.Parse(day);
int weekDay;

// Day of week array
string[] dayOfWeek = { "Söndag", "Måndag", "Tisdag","Onsdag", "Torsdag", "Fredag","Lördag" };

if (numMonth < 3)
{
    numMonth = numMonth +12;
    numYear =  numYear - 1;
}

// Get formula

int q = numDay;
int m = numMonth;
int k = numYear % 100;
int j = numYear / 100;
int h = q + 13 * (m + 1) / 5 + k + k / 4 + j / 4 + 5 * j;

h = h % 7;
// Write day of week
Console.WriteLine(dayOfWeek[h]);