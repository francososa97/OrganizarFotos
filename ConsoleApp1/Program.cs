namespace OrganizarFotos;

class Program
{
    static void Main(string[] args)
    {
        string rutaFotos = @"D:\Acceso Rapido\Imagenes\a organizar";
        RecolectorDeImagenes(rutaFotos);
    }

    private static void RecolectorDeImagenes(string rutaFotos)
    {
        string[] fotos = Directory.GetFiles(rutaFotos);

        foreach (string foto in fotos)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(foto);
                DateTime fechaCreacion = fileInfo.CreationTime; // Utilizar CreationTime o LastWriteTime según tus necesidades

                string año = fechaCreacion.Year.ToString();
                string rutaCarpetaAño = Path.Combine(rutaFotos, año);
                if (!Directory.Exists(rutaCarpetaAño))
                {
                    Directory.CreateDirectory(rutaCarpetaAño);
                }

                string nombreArchivo = Path.GetFileName(foto);
                string rutaDestino = Path.Combine(rutaCarpetaAño, nombreArchivo);

                if (File.Exists(rutaDestino))
                {
                    File.Copy(foto, rutaDestino, true);
                    File.Delete(foto);
                }
                else
                {
                    File.Move(foto, rutaDestino);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al organizar la foto {foto}: {ex.Message}");
            }
        }
    }
}
