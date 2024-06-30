using loja.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace loja.services
{
    public class FornecedorService
    {
        private readonly List<FornecedorModel> _fornecedores = new List<FornecedorModel>();

        public Task<List<FornecedorModel>> GetAllFornecedoresAsync()
        {
            return Task.FromResult(_fornecedores);
        }

        public Task<FornecedorModel> GetFornecedorByIdAsync(int id)
        {
            var fornecedor = _fornecedores.Find(f => f.Id == id);
            return Task.FromResult(fornecedor);
        }

        public Task AddFornecedorAsync(FornecedorModel fornecedor)
        {
            _fornecedores.Add(fornecedor);
            return Task.CompletedTask;
        }

        public Task UpdateFornecedorAsync(FornecedorModel fornecedor)
        {
            var existingFornecedor = _fornecedores.Find(f => f.Id == fornecedor.Id);
            if (existingFornecedor != null)
            {
                existingFornecedor.Nome = fornecedor.Nome;
                existingFornecedor.Cnpj = fornecedor.Cnpj;
                existingFornecedor.Endereco = fornecedor.Endereco;
                existingFornecedor.Telefone = fornecedor.Telefone;
            }
            return Task.CompletedTask;
        }

        public Task DeleteFornecedorAsync(int id)
        {
            var fornecedor = _fornecedores.Find(f => f.Id == id);
            if (fornecedor != null)
            {
                _fornecedores.Remove(fornecedor);
            }
            return Task.CompletedTask;
        }
    }
}
