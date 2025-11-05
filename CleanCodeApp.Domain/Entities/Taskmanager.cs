
namespace CleanCodeApp.Domain.Entities;

public partial class Taskmanager
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int EstadoId { get; set; }

    public virtual TaskEstado Estado { get; set; } = null!;
}
