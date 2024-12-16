// See https://aka.ms/new-console-template for more information
using System.IO;
using UniversityClasses;


string path = "..\\..\\..\\data.txt";   // fails data.txt atrodas mapē MD1
var dm = new UniversityList();
dm.CreateTestData();
Console.WriteLine(dm.Print());
dm.Save(path);
dm.Reset();
Console.WriteLine(dm.Print());
dm.Load(path);
Console.WriteLine(dm.Print());
Console.ReadLine();

// Izmantotie materiāli:
//  kursa materiāli (prezentācijas & piemēri, kas pieejami e-studijās)
//  Microsoft resursi par klases DateOnly lietošanu (https://learn.microsoft.com/en-us/dotnet/standard/datetime/how-to-use-dateonly-timeonly)
//  Micorsoft resursi par klases Random lietošanu (https://learn.microsoft.com/en-us/dotnet/api/system.random?view=net-8.0)