namespace OrganizarFotos;

class Program
{
    static void Main(string[] args)
    {
        // Ruta del directorio que contiene las fotos
        string rutaFotos = @"D:\Acceso Rapido\Imagenes\Varios";

        // Obtenemos la lista de todas las fotos en el directorio
        string[] fotos = Directory.GetFiles(rutaFotos);

        // Iteramos sobre cada foto
        foreach (string foto in fotos)
        {
            try
            {
                // Obtenemos la fecha de creación de la foto
                DateTime fechaCreacion = File.GetCreationTime(foto);

                // Obtenemos el año de la fecha de creación
                string año = fechaCreacion.Year.ToString();

                // Creamos la carpeta del año si no existe
                string rutaCarpetaAño = Path.Combine(rutaFotos, año);
                if (!Directory.Exists(rutaCarpetaAño))
                {
                    Directory.CreateDirectory(rutaCarpetaAño);
                }

                // Movemos la foto a la carpeta del año correspondiente
                string nombreArchivo = Path.GetFileName(foto);
                string rutaDestino = Path.Combine(rutaCarpetaAño, nombreArchivo);
                File.Move(foto, rutaDestino);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al organizar la foto {foto}: {ex.Message}");
            }
        }

        Console.WriteLine("Proceso completado. Se han creado carpetas por año y organizado las fotos dentro de esas carpetas.");
        Console.ReadLine();
    }
}
