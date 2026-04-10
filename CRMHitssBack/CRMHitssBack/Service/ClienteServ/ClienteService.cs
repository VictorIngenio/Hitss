using CRMHitssBack.Models.Entities;
using CRMHitssBack.Repository.ClienteRep;

namespace CRMHitssBack.Service.ClienteServ
{
    public class ClienteService(IClienteRepository repository) : IClienteService
    {
        private readonly IClienteRepository _repository = repository;

        public Cliente? CrearClienteServ(Cliente cliente)
        {
            try
            {
                return _repository.CrearClienteRep(cliente);
            }
            catch (Exception e)
            {
                Console.WriteLine("CrearClienteServ: {mensaje}", e.Message);
                return null;
            }
        }

        public IEnumerable<Cliente> TraerClientesServ()
        {
            try
            {
                return _repository.TraerClientesRep();
            }
            catch (Exception e)
            {
                Console.WriteLine("TraerClienteServ: {mensaje}", e.Message);
                return [];
            }
        }
    }
}
