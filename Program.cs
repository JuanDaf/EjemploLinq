using System;

LinqQuery lq =  new LinqQuery();

PrintPersons(lq.OnlyFristLetterLastName('A'));

PrintPersons(lq.SelectColorEye("Green"));

PrintEyeColors(lq.GroupXColors());

void PrintPersons(IEnumerable<Personas> personas){
    Console.WriteLine("{0,-10} {1,10}{2,40}{3,30}{4,15} \n", "Frist_name","Last_name","Email", "City","Eye Color");
    foreach(var item in personas){
        Console.WriteLine("{0,-10} {1,10}{2,40}{3,30}{4,15}", item.first_name ,item.last_name, item.email, item.city, item.eye_color);
    }
} 

void PrintEyeColors(IEnumerable<IGrouping<string, Personas>> personas){
    foreach(var group in personas){
        Console.WriteLine($"Group Color: {group.Key}");
        Console.WriteLine("{0,-10} {1,10}{2,40}{3,30}{4,15} \n", "Frist_name","Last_name","Email", "City","Eye Color");
        foreach(var item in group){
            Console.WriteLine("{0,-10} {1,10}{2,40}{3,30}{4,15}", item.first_name ,item.last_name, item.email, item.city, item.eye_color);
        }
    }
} 