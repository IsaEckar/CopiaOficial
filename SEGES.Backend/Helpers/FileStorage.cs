using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace SEGES.Backend.Helpers
{
    public class FileStorage : IFileStorage
    {
        private readonly Cloudinary _cloudinary;

        public FileStorage(IConfiguration configuration)
        {

            Account account = new Account(
                configuration["Cloudinary:CloudName"],
                configuration["Cloudinary:ApiKey"],
                configuration["Cloudinary:ApiSecret"]);

            _cloudinary = new Cloudinary(account);
        }

        public async Task RemoveFileAsync(string path, string containerName)
        {
            // No es necesario para Cloudinary, ya que Cloudinary se encarga de la gestión de archivos.
            // Puedes implementar este método según sea necesario.
        }

        public async Task<string> SaveFileAsync(byte[] content, string extention, string containerName)
        {
            using (var stream = new MemoryStream(content))
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(Guid.NewGuid().ToString(), stream),
                    PublicId = null, // Cloudinary genera automáticamente un PublicId único si no se proporciona uno
                    Folder = containerName, // Opcional: Puedes especificar una carpeta en Cloudinary para almacenar los archivos
                    Format = extention.Replace(".", ""), // La extensión debe ser sin el punto
                    Overwrite = false, // Si ya existe un archivo con el mismo nombre, no lo sobrescribe
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                return uploadResult.SecureUrl.ToString();
            }
        }
    }
}



