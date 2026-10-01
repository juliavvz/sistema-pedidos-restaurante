using System;

class Item
{
    public int id;
    public string descricao;
    public double preco;

    public Item(int id, string descricao, double preco)
    {
        this.id = id;
        this.descricao = descricao;
        this.preco = preco;
    }
}

class Pedido
{
    public int id;
    public string cliente;
    public Item[] itens = new Item[10];
    private int qtdItens = 0;

    public Pedido(int id, string cliente)
    {
        this.id = id;
        this.cliente = cliente;
    }

    public bool adicionarItem(Item item)
    {
        if (qtdItens < 10)
        {
            itens[qtdItens] = item;
            qtdItens++;
            return true;
        }
        return false;
    }

    public bool removerItem(Item item)
    {
        for (int i = 0; i < qtdItens; i++)
        {
            if (itens[i] != null && itens[i].id == item.id)
            {
                // Desloca os itens restantes para preencher o espaço livre
                for (int j = i; j < qtdItens - 1; j++)
                {
                    itens[j] = itens[j + 1];
                }
                itens[qtdItens - 1] = null;
                qtdItens--;
                return true;
            }
        }
        return false;
    }

    public double calcularTotal()
    {
        double total = 0;
        for (int i = 0; i < qtdItens; i++)
        {
            total += itens[i].preco;
        }
        return total;
    }

    public string dadosDoPedido()
    {
        string texto = $"ID: {id} | Cliente: {cliente}\nItens:\n";
        if (qtdItens == 0)
        {
            texto += "  (Nenhum item adicionado)\n";
        }
        else
        {
            for (int i = 0; i < qtdItens; i++)
            {
                texto += $"  - [ID: {itens[i].id}] {itens[i].descricao} (R$ {itens[i].preco:F2})\n";
            }
        }
        texto += $"Total: R$ {calcularTotal():F2}";
        return texto;
    }
}

class Restaurante
{
    private int proxPedido = 1;
    public Pedido[] pedidos = new Pedido[50];
    private int qtdPedidos = 0;

    public int GetProximoId() => proxPedido;

    public bool novoPedido(Pedido pedido)
    {
        if (qtdPedidos < 50)
        {
            pedidos[qtdPedidos] = pedido;
            qtdPedidos++;
            proxPedido++;
            return true;
        }
        return false;
    }

    public Pedido buscarPedido(Pedido pedido)
    {
        for (int i = 0; i < qtdPedidos; i++)
        {
            if (pedidos[i] != null && pedidos[i].id == pedido.id)
            {
                return pedidos[i];
            }
        }
        return null;
    }

    public bool cancelarPedido(Pedido pedido)
    {
        for (int i = 0; i < qtdPedidos; i++)
        {
            if (pedidos[i] != null && pedidos[i].id == pedido.id)
            {
                for (int j = i; j < qtdPedidos - 1; j++)
                {
                    pedidos[j] = pedidos[j + 1];
                }
                pedidos[qtdPedidos - 1] = null;
                qtdPedidos--;
                return true;
            }
        }
        return false;
    }
}

class Program
{
    static void Main()
    {
        Restaurante restaurante = new Restaurante();
        int opcao = -1;

        while (opcao != 0)
        {
            Console.WriteLine("\n=== COZINHA INDUSTRIAL ===");
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Criar novo pedido");
            Console.WriteLine("2. Adicionar item ao pedido");
            Console.WriteLine("3. Remover item do pedido");
            Console.WriteLine("4. Consultar pedido");
            Console.WriteLine("5. Cancelar pedido");
            Console.WriteLine("6. Listar todos os pedidos");
            Console.Write("Escolha uma opcao: ");
            
            if (!int.TryParse(Console.ReadLine(), out opcao)) continue;

            Console.WriteLine();

            switch (opcao)
            {
                case 1:
                    Console.Write("Nome do Cliente: ");
                    string nome = Console.ReadLine();
                    Pedido pNovo = new Pedido(restaurante.GetProximoId(), nome);
                    if (restaurante.novoPedido(pNovo))
                        Console.WriteLine($"Pedido #{pNovo.id} criado com sucesso!");
                    else
                        Console.WriteLine("Limite diario de 50 pedidos atingido!");
                    break;

                case 2:
                    Console.Write("ID do Pedido: ");
                    int idAdd = int.Parse(Console.ReadLine());
                    Pedido pAdd = restaurante.buscarPedido(new Pedido(idAdd, ""));
                    
                    if (pAdd != null)
                    {
                        Console.Write("ID do Item: ");
                        int idItem = int.Parse(Console.ReadLine());
                        Console.Write("Descricao do Item: ");
                        string desc = Console.ReadLine();
                        Console.Write("Preco do Item: R$ ");
                        double preco = double.Parse(Console.ReadLine());

                        Item item = new Item(idItem, desc, preco);
                        if (pAdd.adicionarItem(item))
                            Console.WriteLine("Item adicionado com sucesso!");
                        else
                            Console.WriteLine("Limite de 10 itens atingido para este pedido.");
                    }
                    else
                    {
                        Console.WriteLine("Pedido nao encontrado.");
                    }
                    break;

                case 3:
                    Console.Write("ID do Pedido: ");
                    int idRem = int.Parse(Console.ReadLine());
                    Pedido pRem = restaurante.buscarPedido(new Pedido(idRem, ""));

                    if (pRem != null)
                    {
                        Console.Write("ID do Item a ser removido: ");
                        int idItemRem = int.Parse(Console.ReadLine());
                        
                        if (pRem.removerItem(new Item(idItemRem, "", 0)))
                            Console.WriteLine("Item removido com sucesso!");
                        else
                            Console.WriteLine("Item nao encontrado neste pedido.");
                    }
                    else
                    {
                        Console.WriteLine("Pedido nao encontrado.");
                    }
                    break;

                case 4:
                    Console.Write("ID do Pedido: ");
                    int idBusca = int.Parse(Console.ReadLine());
                    Pedido pBusca = restaurante.buscarPedido(new Pedido(idBusca, ""));

                    if (pBusca != null)
                        Console.WriteLine(pBusca.dadosDoPedido());
                    else
                        Console.WriteLine("Pedido nao encontrado.");
                    break;

                case 5:
                    Console.Write("ID do Pedido a cancelar: ");
                    int idCanc = int.Parse(Console.ReadLine());
                    if (restaurante.cancelarPedido(new Pedido(idCanc, "")))
                        Console.WriteLine("Pedido cancelado com sucesso!");
                    else
                        Console.WriteLine("Pedido nao encontrado.");
                    break;

                case 6:
                    double somaGeral = 0;
                    Console.WriteLine("=== HISTORICO DE PEDIDOS DO DIA ===");
                    bool temPedidos = false;

                    for (int i = 0; i < restaurante.pedidos.Length; i++)
                    {
                        if (restaurante.pedidos[i] != null)
                        {
                            temPedidos = true;
                            double totalPedido = restaurante.pedidos[i].calcularTotal();
                            somaGeral += totalPedido;
                            Console.WriteLine($"ID: {restaurante.pedidos[i].id} | Cliente: {restaurante.pedidos[i].cliente} | Total: R$ {totalPedido:F2}");
                        }
                    }

                    if (!temPedidos)
                        Console.WriteLine("Nenhum pedido registrado.");

                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine($"SOMA GERAL DO DIA: R$ {somaGeral:F2}");
                    break;

                case 0:
                    Console.WriteLine("Saindo do sistema...");
                    break;

                default:
                    Console.WriteLine("Opcao invalida!");
                    break;
            }
        }
    }
}