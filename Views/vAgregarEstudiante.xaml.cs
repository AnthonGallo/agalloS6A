using agalloS6A.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace agalloS6A.Views;

public partial class vAgregarEstudiante : ContentPage
{
	public vAgregarEstudiante()
	{
		InitializeComponent();
	}

    private async void btnAgregarEstudiante_Clicked(object sender, EventArgs e)
    {
        try
        {
            var nuevoEstudiante = new Estudiante
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Edad = int.Parse(txtEdad.Text) // Aseg�rate de validar el input
            };

            string json = JsonConvert.SerializeObject(nuevoEstudiante);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            var response = await client.PostAsync("http://localhost:5250/api/estudiante", content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("�xito", "Estudiante agregado correctamente", "OK");
                await Navigation.PushAsync(new vCrud());
            }
            else
            {
                await DisplayAlert("Error", $"C�digo: {response.StatusCode}", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}