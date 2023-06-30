public class LinqQuery{

    List<Persons> ColecccionPersonas =  new List<Persons>();
    public LinqQuery(){
        using(StreamReader rd =  new StreamReader("datos.json")){
            string json = rd.ReadToEnd();
            this.ColecccionPersonas = System.Text.Json.JsonSerializer.Deserialize<List<Persons>>
            (json, new System.Text.Json.JsonSerializerOptions(){ PropertyNameCaseInsensitive = true });
        }
    }
    //Operadores de agrgacion 
    public IEnumerable<Persons> OnlyFristLetterLastName(char letter){
        return ColecccionPersonas.Where(p => p.last_name[0].Equals(letter)).Take(50);
    }

    public IEnumerable<Persons> SelectColorEye(string letter){
        return ColecccionPersonas.Where(p => p.eye_color.Equals(letter)).OrderBy(p=> p.first_name);
    }
    
    //Operadores de agrupamiento
    public IEnumerable<IGrouping<string,Persons>> GroupXColors(){
        return ColecccionPersonas.GroupBy(p => p.eye_color).Take(10);
    }

    public ILookup<char, Persons> DiccionarioDeLibrosXLetter(){
		return ColecccionPersonas.ToLookup(p => p.email[p.email.Length - 1], p=> p);
	}
}