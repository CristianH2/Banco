using Banco.Core.Repositorio.Entidades;
using Banco.Core.Repositorio.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Banco.Repsositorio.MongoDb.Daos
{
    internal class ClienteRepo : IClienteRepositorio
    {
        private readonly IMongoCollection<ClienteEntidad> _collection;

        /// <summary>
        /// Configuracion de la mongodb en el constructor
        /// </summary>
        /// <param name="configurations"></param>
        public ClienteRepo(IConfiguration configurations)
        {
            var conectionString = configurations.GetConnectionString("MongoDb");
            var mongoClient = new MongoClient(conectionString);
            var nombreDeLaDb = conectionString?.Split("/").Last().Split("?").First();
            var mongoDatabase = mongoClient.GetDatabase(nombreDeLaDb);
            _collection = mongoDatabase.GetCollection<ClienteEntidad>("Clientes");
        }

        public async Task<int> AgregarAsync(ClienteEntidad item)
        {
            item.Id = (int)await _collection.CountDocumentsAsync(_ => true) + 1;
            await _collection.InsertOneAsync(item);

            return item.Id;
        }

        public async Task<ClienteEntidad> ObtenerAsync(string clienteId)
        {
            if (int.TryParse(clienteId, out int id))
                return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            else
                return await _collection.Find(x => x.EncodedKey == clienteId).FirstOrDefaultAsync();
        }

        public async Task<ClienteEntidad> ObtenerPorCorreoAsync(string correo)
        {
           return await _collection.Find(x => x.Correo == correo).FirstOrDefaultAsync();
        }

        public async Task<ClienteEntidad> ObtenerPorCurpAsync(string curp)
        {
            return await _collection.Find(x => x.Curp == curp).FirstOrDefaultAsync();
        }
    }
}
