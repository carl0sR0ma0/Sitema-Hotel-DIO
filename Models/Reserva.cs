namespace Hotel.Models
{
    public class Reserva
    {
        
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva()
        { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao numero de hospedes sendo recebido
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("A quantidade de hóspedes não pode exceder a capacidade da suite");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária 
            decimal valor = 0, percentual = 0;
            // Cálculo: DiasReservados x Suite.ValorDiaria
            valor = DiasReservados * Suite.ValorDiaria;
            
            // Regra: Caso os dias reservados forem maior ou igual a 10, conceceder um desconto de 10%

            if (DiasReservados >= 10)
            {
                percentual = 10m / 100m;
                valor = valor - (percentual * valor);
            }
            return valor;
        }
    }
}
