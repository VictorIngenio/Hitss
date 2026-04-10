using CRMHitssBack.Models.Entities;

namespace CRMHitssBack.Repository.ClienteRep
{
    public interface IClienteRepository
    {
        Cliente? CrearClienteRep(Cliente cliente);
        IEnumerable<Cliente> TraerClientesRep();
    }
}
