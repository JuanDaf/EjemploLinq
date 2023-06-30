using System;

LinqQuery lq =  new LinqQuery();

//PrintPersons(lq.OnlyFristLetterLastName('A'));

//PrintPersons(lq.SelectColorEye("Green"));

//PrintEyeColors(lq.GroupXColors());

PrintEmailsValue(lq.DiccionarioDeLibrosXLetter(),'t');

void PrintPersons(IEnumerable<Persons> persons){
    Console.WriteLine("{0,-10} {1,10}{2,40}{3,30}{4,15} \n", "Frist_name","Last_name","Email", "City","Eye Color");
    foreach(var item in persons){
        Console.WriteLine("{0,-10} {1,10}{2,40}{3,30}{4,15}", item.first_name ,item.last_name, item.email, item.city, item.eye_color);
    }
} 

void PrintEyeColors(IEnumerable<IGrouping<string, Persons>> persons){
    foreach(var group in persons){
        Console.WriteLine($"Group Color: {group.Key}");
        Console.WriteLine("{0,-10} {1,10}{2,40}{3,30}{4,15} \n", "Frist_name","Last_name","Email", "City","Eye Color");
        foreach(var item in group){
            Console.WriteLine("{0,-10} {1,10}{2,40}{3,30}{4,15}", item.first_name ,item.last_name, item.email, item.city, item.eye_color);
        }
    }
} 

void PrintEmailsValue(ILookup<char, Persons> persons, char partemail)
{
    Console.WriteLine("{0,-10} {1,10}{2,40}{3,30}{4,15} \n", "Frist_name","Last_name","Email", "City","Eye Color");
    foreach(var item in persons[partemail])
    {
         Console.WriteLine("{0,-10} {1,10}{2,40}{3,30}{4,15}", item.first_name ,item.last_name, item.email, item.city, item.eye_color);
    }
}