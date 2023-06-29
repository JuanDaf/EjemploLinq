public class LinqQuery{

    List<Personas> ColecccionPersonas =  new List<Personas>();
    public LinqQuery(){
        using(StreamReader rd =  new StreamReader("datos.json")){
            string json = rd.ReadToEnd();
            this.ColecccionPersonas = System.Text.Json.JsonSerializer.Deserialize<List<Personas>>
            (json, new System.Text.Json.JsonSerializerOptions(){ PropertyNameCaseInsensitive = true });
        }
    }

    public IEnumerable<Personas> OnlyFristWordLastName(){
        return ColecccionPersonas.Where(p => p.last_name[0].Equals('A')).Take(50);
    }


}