using CRMHitssBack.Models.Context;
using CRMHitssBack.Models.Entities;

namespace CRMHitssBack.Repository.ClienteRep
{
    public class ClienteRepository(ClienteContext context) : IClienteRepository
    {
        private readonly ClienteContext _context = context;

        public Cliente? CrearClienteRep(Cliente cliente)
        {
            try
            {
                _context.Cliente.Add(cliente);
                _context.SaveChanges();

                return cliente;
            }
            catch (Exception e)
            {
                Console.WriteLine("CrearClienteRep: {mensaje}", e.Message);
                return null;
            }
        }

        public IEnumerable<Cliente> TraerClientesRep()
        {
            try
            {
                return from resp in _context.Cliente select resp;
            }
            catch (Exception e)
            {
                Console.WriteLine("TraerClientesRep: {mensaje}", e.Message);
                return [];
            }
        }
    }
}
