namespace FuncionarioMVC
{
    public class GeradorDeServicos
    {
        public static ServiceProvider ServiceProvider;

        public static ApplicationDBContext CarregarContexto()
        {
            return ServiceProvider.GetService<ApplicationDBContext>();
        }
    }
}
