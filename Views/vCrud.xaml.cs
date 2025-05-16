using agalloS6A.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace agalloS6A.Views;

public partial class vCrud : ContentPage
{
    private const string URL = "http://localhost:5250/api/estudiante";
    private HttpClient cliente = new HttpClient();
    private ObservableCollection<Estudiante> _estudianteTeam;
    public vCrud()
	{
		InitializeComponent();
        mostrarEstudiante();
	}

    public async void mostrarEstudiante()
    {
        var content = await cliente.GetStringAsync(URL);
        List<Estudiante> lista = JsonConvert.DeserializeObject<List<Estudiante>>(content);
        _estudianteTeam = new ObservableCollection<Estudiante>(lista);
        lvEstudiantes.ItemsSource = _estudianteTeam;
    }
}