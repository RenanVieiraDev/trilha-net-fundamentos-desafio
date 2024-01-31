namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo() //Insere o veiculo na lista de carros estacionados
        {
            Console.Write("Digite a placa do veículo para estacionar:");
            string carPlate  = Console.ReadLine();
            this.veiculos.Add(carPlate);
        }

        public void RemoverVeiculo()
        {
            Console.Write("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                bool validacaoFormatoHorasExiteWhile = true;
                decimal horas = 0;
                while (validacaoFormatoHorasExiteWhile)     //Verifica se o valor digitado realmente é numerico, só sai do laço se o numero for numerico.
                {
                    Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    string quantidadePermanencia = Console.ReadLine();
                    bool validacaoHorasNumericas = decimal.TryParse(quantidadePermanencia, out var conversaoHoras);
                    if (validacaoHorasNumericas)
                    {
                        validacaoFormatoHorasExiteWhile = false;
                        horas = conversaoHoras;
                    }
                    else 
                    {
                        Console.WriteLine("Por favor, Digite um valor numerico!");
                    }
                }
                Console.Clear();
                this.veiculos.Remove(placa); //<< Remove o veiculo
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {this.precoInicial + this.precoPorHora * horas}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos() //Apresenta a lista completa de todos os veiculos estacionados
        {
            // Verifica se há veículos no estacionamento
            if (this.veiculos.Any())
            {
                
                Console.WriteLine("Os veículos estacionados são:");
                int countCar = 1;
                foreach (var veiculo in this.veiculos)
                {
                    Console.WriteLine($"[{countCar}] PLACA: {veiculo}");
                    countCar++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
