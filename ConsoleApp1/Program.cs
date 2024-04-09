namespace OrganizarFotos;

class Program
{
    static void Main(string[] args)
    {
        string rutaFotos2021 = @"D:\Acceso Rapido\Imagenes\2021";
        string rutaFotos2022 = @"D:\Acceso Rapido\Imagenes\2022";
        string rutaFotos2023 = @"D:\Acceso Rapido\Imagenes\2023";
        string rutaFotos2024 = @"D:\Acceso Rapido\Imagenes\2024";
        RecolectorDeImagenes(rutaFotos2021);
        RecolectorDeImagenes(rutaFotos2022);
        RecolectorDeImagenes(rutaFotos2023);
        RecolectorDeImagenes(rutaFotos2024);
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
