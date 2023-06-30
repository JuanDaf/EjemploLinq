public class LinqQuery{

    List<Personas> ColecccionPersonas =  new List<Personas>();
    public LinqQuery(){
        using(StreamReader rd =  new StreamReader("datos.json")){
            string json = rd.ReadToEnd();
            this.ColecccionPersonas = System.Text.Json.JsonSerializer.Deserialize<List<Personas>>
            (json, new System.Text.Json.JsonSerializerOptions(){ PropertyNameCaseInsensitive = true });
        }
    }

    public IEnumerable<Personas> OnlyFristLetterLastName(char letter){
        return ColecccionPersonas.Where(p => p.last_name[0].Equals(letter)).Take(50);
    }

    public IEnumerable<Personas> SelectColorEye(string letter){
        return ColecccionPersonas.Where(p => p.eye_color.Equals(letter)).OrderBy(p=> p.first_name);
    }

    public IEnumerable<IGrouping<string,Personas>> GroupXColors(){
        return ColecccionPersonas.GroupBy(p => p.eye_color).Take(10);
    }

}