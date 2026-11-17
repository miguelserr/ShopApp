using System;
using System.IO;

namespace ShopApp.Services;

public class DatabaseRutaService : IDatabaseRutaService
{
    public string get(string nombreArchivo)
    {
        var rutaDirectorio = Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData);

        return Path.Combine(rutaDirectorio, nombreArchivo);
    }
}