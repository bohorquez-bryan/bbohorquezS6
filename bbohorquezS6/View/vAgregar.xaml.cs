using System.Net;

namespace bbohorquezS6.View;

public partial class vAgregar : ContentPage
{
	public vAgregar()
	{
		InitializeComponent();
	}

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
		try
		{

			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection(); //Contenedor temporal
			parametros.Add("nombre", txtNombre.Text);
			parametros.Add("apellido", txtApellido.Text);
			parametros.Add("edad", txtEdad.Text);
			

			cliente.UploadValues("http://192.168.100.35:8080/moviles/post.php","POST",parametros);
            DisplayAlert("Alert", "Registro agregado", "OK");
            Navigation.PushAsync(new vEstudiante());

		}
		catch (Exception ex)
		{

			DisplayAlert("Alerta", ex.Message, "Cerrar");
		}
    }
}