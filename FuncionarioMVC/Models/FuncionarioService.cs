namespace FuncionarioMVC
{
    public class FuncionarioService
    {
        private readonly ApplicationDBContext _dbContext;

        public FuncionarioService()
        {
            _dbContext = GeradorDeServicos.CarregarContexto();
        }

        public List<Funcionario> Listar()
        {
            var funcionarios = _dbContext.Funcionarios.ToList();

            return funcionarios;
        }

        public Funcionario BuscarParaEditar(int id)
        {
            var funcionario = _dbContext.Funcionarios.First(f => f.Id == id);

            return funcionario;
        }

        public void Salvar(Funcionario funcionario)
        {
            if (funcionario.Id == 0)
            {
                _dbContext.Funcionarios.Add(funcionario);
            }
            else
            {
                Funcionario funcionaroDoBanco = _dbContext.Funcionarios.First(registro => registro.Id == funcionario.Id);

                funcionaroDoBanco.Nome = funcionario.Nome;
                funcionaroDoBanco.Salario = funcionario.Salario;
                funcionaroDoBanco.Cpf = funcionario.Cpf;
            }

            _dbContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            Funcionario funcionarioReturned = _dbContext.Funcionarios.First(f => f.Id == id);

            _dbContext.Funcionarios.Remove(funcionarioReturned);

            _dbContext.SaveChanges();
        }
    }
}
