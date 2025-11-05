
namespace CleanCodeApp.Domain.Entities;

public partial class TaskEstado
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Taskmanager> Taskmanagers { get; set; } = new List<Taskmanager>();
}
