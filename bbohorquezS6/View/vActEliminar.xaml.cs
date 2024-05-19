using bbohorquezS6.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace bbohorquezS6.View;

public partial class vActEliminar : ContentPage
{
    public vActEliminar(Estudiante datos)
    {
        InitializeComponent();
        txtCodigo.Text = datos.Id.ToString();
        txtNombre.Text = datos.Nombre;
        txtApellido.Text = datos.Apellido;
        txtEdad.Text = datos.Edad.ToString();
        HttpClient _httpClient = new HttpClient();

    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {

            var id = int.Parse(txtCodigo.Text);
            var nombre = txtNombre.Text;
            var apellido = txtApellido.Text;
            var edad = txtEdad.Text;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(edad))
            {
                DisplayAlert("Alerta", "Por favor, completa todos los campos.", "Cerrar");
                return;
            }

            var url = $"http://192.168.100.35:8080/moviles/post.php?id={id}&nombre={nombre}&apellido={apellido}&edad={edad}";
            HttpRequestMessage request = new(HttpMethod.Put, url);
            using (HttpClient client = new HttpClient())
            {
                var response = client.Send(request);
                DisplayAlert("Alert", "Registro actualizado", "OK");
                Navigation.PushAsync(new vEstudiante());
                
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", "No se pudo actualizar el registro", "Cerrar");
        }

    }


    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            HttpClient cliente = new HttpClient();
            int id = int.Parse(txtCodigo.Text);
            
            cliente.DeleteAsync($"http://192.168.100.35:8080/moviles/post.php?id={id}");
            DisplayAlert("Alert", "Registro eliminado", "OK");
            Navigation.PushAsync(new vEstudiante());

        }
        catch (Exception ex)
        {

            DisplayAlert("Error", "No se pudo eliminar el registro", "Cerrar");
        }
    }
}