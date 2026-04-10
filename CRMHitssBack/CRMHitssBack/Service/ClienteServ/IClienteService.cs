using CRMHitssBack.Models.Entities;

namespace CRMHitssBack.Service.ClienteServ
{
    public interface IClienteService
    {
        Cliente? CrearClienteServ(Cliente cliente);
        IEnumerable<Cliente> TraerClientesServ();
    }
}
