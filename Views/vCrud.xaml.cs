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

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new vAgregarEstudiante());
    }

    private void lvEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objEstudiante = (Estudiante)e.SelectedItem;
        Navigation.PushAsync(new vActEliminarEstudiante(objEstudiante));
    }
}