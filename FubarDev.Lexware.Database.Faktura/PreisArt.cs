using System.ComponentModel;

namespace FubarDev.Lexware.Database.Faktura
{
    public enum PreisArt
    {
        Stammdatenpreis,
        Manuell,
        Aktionspreis,

        [EditorBrowsable(EditorBrowsableState.Never)]
        Kundenpreis,
    }
}